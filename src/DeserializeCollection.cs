
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
        /// Deserializer for collections (arrays, lists).
        /// </summary>
        private struct DeserializeCollection : ITypeDeserializer
        {
            private readonly Deserializer _deserializer;
            private readonly ISerdeInfo _typeInfo;
            private int _index;
            private readonly int _depth;

            public DeserializeCollection(Deserializer deserializer, ISerdeInfo typeInfo)
            {
                _deserializer = deserializer;
                _typeInfo = typeInfo;
                _index = 0;
                _depth = deserializer._reader.Depth;
            }

            public int? SizeOpt => null;

            public int TryReadIndex(ISerdeInfo info)
            {
                var reader = _deserializer._reader;

                if (reader.EOF)
                {
                    throw new DeserializeException("Unexpected end of XML while reading collection.");
                }

                // Check if we've reached the end of the collection
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    return ITypeDeserializer.EndOfType;
                }

                if (reader.NodeType == XmlNodeType.Element)
                {
                    return _index;
                }

                throw new DeserializeException($"Unexpected XML node type {reader.NodeType} while reading collection.");
            }

            public (int, string?) TryReadIndexWithName(ISerdeInfo info)
            {
                return (TryReadIndex(info), null);
            }

            public void End(ISerdeInfo info)
            {
                var reader = _deserializer._reader;
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    reader.ReadEndElement();
                }
            }

            private string ReadElementContent()
            {
                var content = _deserializer._reader.ReadElementContentAsString();
                _index++;
                return content;
            }

            public bool ReadBool(ISerdeInfo info, int index) => bool.Parse(ReadElementContent());
            public byte ReadU8(ISerdeInfo info, int index) => byte.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public ushort ReadU16(ISerdeInfo info, int index) => ushort.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public uint ReadU32(ISerdeInfo info, int index) => uint.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public ulong ReadU64(ISerdeInfo info, int index) => ulong.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public sbyte ReadI8(ISerdeInfo info, int index) => sbyte.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public short ReadI16(ISerdeInfo info, int index) => short.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public int ReadI32(ISerdeInfo info, int index) => int.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public long ReadI64(ISerdeInfo info, int index) => long.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public float ReadF32(ISerdeInfo info, int index) => float.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public double ReadF64(ISerdeInfo info, int index) => double.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public decimal ReadDecimal(ISerdeInfo info, int index) => decimal.Parse(ReadElementContent(), CultureInfo.InvariantCulture);
            public char ReadChar(ISerdeInfo info, int index) => ReadElementContent()[0];
            public string ReadString(ISerdeInfo info, int index) => ReadElementContent();

            public DateTime ReadDateTime(ISerdeInfo info, int index)
                => DateTime.Parse(ReadElementContent(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

            public DateTimeOffset ReadDateTimeOffset(ISerdeInfo info, int index)
                => DateTimeOffset.Parse(ReadElementContent(), CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

            public Int128 ReadI128(ISerdeInfo info, int index)
                => Int128.Parse(ReadElementContent(), CultureInfo.InvariantCulture);

            public UInt128 ReadU128(ISerdeInfo info, int index)
                => UInt128.Parse(ReadElementContent(), CultureInfo.InvariantCulture);

            public void ReadBytes(ISerdeInfo info, int index, IBufferWriter<byte> writer)
            {
                var content = ReadElementContent();
                var bytes = Convert.FromBase64String(content);
                var span = writer.GetSpan(bytes.Length);
                bytes.CopyTo(span);
                writer.Advance(bytes.Length);
            }

            public T ReadValue<T>(ISerdeInfo info, int index, IDeserialize<T> deserialize)
                where T : class?
            {
                // XML doesn't really have lists, so lists are treated as repeated elements
                // with the type name as the element name.
                var reader = _deserializer._reader;
                reader.ReadStartElement();
                var result = deserialize.Deserialize(_deserializer);
                _deserializer._reader.ReadEndElement();
                _index++;
                return result;
            }

            public void SkipValue(ISerdeInfo info, int index)
            {
                _deserializer._reader.Skip();
                _index++;
            }
        }
    }
}
