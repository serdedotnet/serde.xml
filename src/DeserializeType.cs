
using System;
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace Serde.Xml;

partial class XmlSerializer
{
    private sealed partial class Deserializer
    {
        /// <summary>
        /// Deserializer for custom types (classes/structs with fields).
        /// </summary>
        private sealed class DeserializeType : ITypeDeserializer
        {
            private readonly Deserializer _deserializer;
            private int _attributeCount;
            private State _state;

            private enum State
            {
                ReadingAttributes,
                FinishedAttributes,
                ReadingElements,
            }

            /// <summary>
            /// Expects input to be positioned at the start of an element representing the type.
            /// This allows for reading the attributes or content, or skipping the whole element
            /// entirely if it's empty.
            /// </summary>
            public DeserializeType(Deserializer deserializer)
            {
                Debug.Assert(deserializer._reader.NodeType == XmlNodeType.Element);
                _deserializer = deserializer;
                _attributeCount = _deserializer._reader.AttributeCount;
                _state = _attributeCount > 0 ? State.ReadingAttributes : State.FinishedAttributes;
                if (_state == State.ReadingAttributes)
                {
                    _deserializer._reader.MoveToFirstAttribute();
                }
            }

            public int? SizeOpt => null;

            public int TryReadIndex(ISerdeInfo info)
            {
                return TryReadIndexWithName(info).Item1;
            }

            private int TryGetIndexWithAttributes(ISerdeInfo info, string attrName)
            {
                // First try to read standard property info
                var attrNameU8 = System.Text.Encoding.UTF8.GetBytes(attrName);
                var index = info.TryGetIndex(attrNameU8);
                if (index != ITypeDeserializer.IndexNotFound)
                {
                    return index;
                }

                // Search the attributes for a match
                for (int i = 0; i < info.FieldCount; i++)
                {
                    var attrs = info.GetFieldAttributes(i);
                    foreach (var attr in attrs)
                    {
                        if ((attr.AttributeType == typeof(XmlAttributeAttribute) || attr.AttributeType == typeof(XmlElementAttribute)) &&
                            attr.ConstructorArguments is [ { Value: string fieldName } ] &&
                            fieldName == attrName)
                        {
                                return i;
                        }
                    }
                }

                return ITypeDeserializer.IndexNotFound;
            }

            public (int, string?) TryReadIndexWithName(ISerdeInfo info)
            {
                var reader = _deserializer._reader;
                int index;

                // First read all attributes
                if (_state == State.ReadingAttributes)
                {
                    var attrName = reader.Name;
                    index = TryGetIndexWithAttributes(info, attrName);
                    return (index, index == ITypeDeserializer.IndexNotFound ? attrName : null);
                }

                if (reader.EOF)
                {
                    throw new DeserializeException("Unexpected end of XML while reading type.");
                }

                if (_state == State.FinishedAttributes)
                {
                    if (reader.IsEmptyElement)
                    {
                        // Consume the empty element and signal end of type
                        reader.Read();
                        return (ITypeDeserializer.EndOfType, null);
                    }
                    _state = State.ReadingElements;
                    reader.ReadStartElement(); // move to first child element
                }

                Debug.Assert(_state == State.ReadingElements);


                // Then read child elements
                if (reader.NodeType is XmlNodeType.EndElement)
                {
                    // Consume our end element before returning - deserializers are responsible
                    // for fully consuming themselves, leaving cursor after the element.
                    reader.ReadEndElement();
                    return (ITypeDeserializer.EndOfType, null);
                }

                if (reader.NodeType != XmlNodeType.Element)
                {
                    throw new DeserializeException($"Unexpected XML node type {reader.NodeType} while reading type.");
                }

                var elementName = reader.Name;
                index = TryGetIndexWithAttributes(info, elementName);
                return (index, index == ITypeDeserializer.IndexNotFound ? elementName : null);
            }

            private string ReadContent(ISerdeInfo info, int index)
            {
                var reader = _deserializer._reader;
                // If we're on an attribute, read attribute value
                if (reader.NodeType == XmlNodeType.Attribute)
                {
                    var v = reader.Value;
                    if (!reader.MoveToNextAttribute())
                    {
                        _state = State.FinishedAttributes;
                        reader.MoveToElement();
                    }
                    return v;
                }
                // Otherwise read content. We should be on an element.
                var content = reader.ReadElementContentAsString();
                return content;
            }

            public bool ReadBool(ISerdeInfo info, int index) => bool.Parse(ReadContent(info, index));
            public byte ReadU8(ISerdeInfo info, int index) => byte.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public ushort ReadU16(ISerdeInfo info, int index) => ushort.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public uint ReadU32(ISerdeInfo info, int index) => uint.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public ulong ReadU64(ISerdeInfo info, int index) => ulong.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public sbyte ReadI8(ISerdeInfo info, int index) => sbyte.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public short ReadI16(ISerdeInfo info, int index) => short.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public int ReadI32(ISerdeInfo info, int index) => int.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public long ReadI64(ISerdeInfo info, int index) => long.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public float ReadF32(ISerdeInfo info, int index) => float.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public double ReadF64(ISerdeInfo info, int index) => double.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public decimal ReadDecimal(ISerdeInfo info, int index) => decimal.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);
            public char ReadChar(ISerdeInfo info, int index) => ReadContent(info, index)[0];
            public string ReadString(ISerdeInfo info, int index) => ReadContent(info, index);

            public DateTime ReadDateTime(ISerdeInfo info, int index)
                => DateTime.Parse(ReadContent(info, index), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

            public DateTimeOffset ReadDateTimeOffset(ISerdeInfo info, int index)
                => DateTimeOffset.Parse(ReadContent(info, index), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

            public Int128 ReadI128(ISerdeInfo info, int index)
                => Int128.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);

            public UInt128 ReadU128(ISerdeInfo info, int index)
                => UInt128.Parse(ReadContent(info, index), CultureInfo.InvariantCulture);

            public void ReadBytes(ISerdeInfo info, int index, IBufferWriter<byte> writer)
            {
                var content = ReadContent(info, index);
                var bytes = Convert.FromBase64String(content);
                var span = writer.GetSpan(bytes.Length);
                bytes.CopyTo(span);
                writer.Advance(bytes.Length);
            }

            public T ReadValue<T>(ISerdeInfo info, int index, IDeserialize<T> deserialize)
                where T : class?
            {
                // TryReadIndex should have already advanced to the nested element.
                // The inner deserializer is responsible for fully consuming itself,
                // including its end element.
                return deserialize.Deserialize(_deserializer);
            }

            public void SkipValue(ISerdeInfo info, int index)
            {
                var reader = _deserializer._reader;
                if (reader.NodeType == XmlNodeType.Attribute)
                {
                    // If we're on an attribute, just skip to the next attribute
                    if (!reader.MoveToNextAttribute())
                    {
                        _state = State.FinishedAttributes;
                        reader.MoveToElement();
                    }
                    return;
                }

                _deserializer._reader.Skip();
            }
        }
    }
}
