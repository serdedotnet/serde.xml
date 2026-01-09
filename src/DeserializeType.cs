
using System;
using System.Buffers;
using System.Globalization;
using System.Xml;

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
            private int _currentAttributeIndex;
            private bool _inAttributes;

            public DeserializeType(Deserializer deserializer)
            {
                _deserializer = deserializer;
            }

            public void Initialize()
            {
                _attributeCount = _deserializer._reader.AttributeCount;
                _currentAttributeIndex = 0;
                _inAttributes = _attributeCount > 0;
            }

            public int? SizeOpt => null;

            public int TryReadIndex(ISerdeInfo info)
            {
                return TryReadIndexWithName(info).Item1;
            }

            public (int, string?) TryReadIndexWithName(ISerdeInfo info)
            {
                var reader = _deserializer._reader;
                int index;

                // First read all attributes
                if (_inAttributes && _currentAttributeIndex < _attributeCount)
                {
                    reader.MoveToAttribute(_currentAttributeIndex);
                    var attrName = reader.Name;
                    _currentAttributeIndex++;
                    if (_currentAttributeIndex >= _attributeCount)
                    {
                        _inAttributes = false;
                        reader.MoveToElement();
                    }
                    index = info.TryGetIndex(System.Text.Encoding.UTF8.GetBytes(attrName));
                    return (index, index == ITypeDeserializer.IndexNotFound ? attrName : null);
                }

                // Then read child elements
                if (reader.NodeType == XmlNodeType.EndElement || reader.EOF)
                {
                    return (ITypeDeserializer.EndOfType, null);
                }

                if (reader.NodeType != XmlNodeType.Element)
                {
                    throw new DeserializeException($"Unexpected XML node type {reader.NodeType} while reading type.");
                }

                var elementName = reader.Name;
                reader.ReadStartElement();
                index = info.TryGetIndex(System.Text.Encoding.UTF8.GetBytes(elementName));
                return (index, index == ITypeDeserializer.IndexNotFound ? elementName : null);
            }

            public void End(ISerdeInfo info)
            {
                var reader = _deserializer._reader;
                // Read the end element if we're at one
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    reader.ReadEndElement();
                }
            }

            private string ReadContent(ISerdeInfo info, int index)
            {
                var reader = _deserializer._reader;
                // If we're on an attribute, read attribute value
                if (reader.NodeType == XmlNodeType.Attribute)
                {
                    return reader.Value;
                }
                // Otherwise read content
                var content = reader.ReadContentAsString();
                // Every field should be followed by an end element with the name of the field
                var fieldName = info.GetFieldStringName(index);
                if (reader.NodeType != XmlNodeType.EndElement || reader.Name != fieldName)
                {
                    throw new DeserializeException($"Expected end element </{fieldName}> but found {reader.NodeType} with name {reader.Name}.");
                }
                reader.ReadEndElement();
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
                // TryReadIndex should have already advanced to the nested element
                var result = deserialize.Deserialize(_deserializer);
                // After the inner deserializer completes, consume the end element for the field
                _deserializer._reader.ReadEndElement();
                return result;
            }

            public void SkipValue(ISerdeInfo info, int index)
            {
                _deserializer._reader.Skip();
            }
        }
    }
}
