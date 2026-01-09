
using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Serde.Xml;

partial class XmlSerializer
{
    private sealed partial class Deserializer : IDeserializer
    {
        private readonly XmlReader _reader;
        private readonly DeserializeType _deserializeType;
        private readonly DeserializeCollection _deserializeCollection;
        private readonly DeserializeEnum _deserializeEnum;

        public Deserializer(string xml)
        {
            var stringReader = new StringReader(xml);
            _reader = XmlReader.Create(stringReader, new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true
            });
            // Move to the first content element (skip XML declaration)
            _reader.MoveToContent();
            // Read the root element start
            _reader.ReadStartElement();

            // Initialize cached deserializers
            _deserializeType = new DeserializeType(this);
            _deserializeCollection = new DeserializeCollection(this);
            _deserializeEnum = new DeserializeEnum(this);
        }

        public void Dispose()
        {
            // Read the end element of the root
            _reader.ReadEndElement();
            if (!_reader.EOF)
            {
                throw new InvalidOperationException("Deserializer disposed before reaching end of XML.");
            }
            _reader.Dispose();
        }

        /// <summary>
        /// Reads the text content of the current element.
        /// </summary>
        private string ReadElementContent()
        {
            return _reader.ReadElementContentAsString();
        }

        public bool ReadBool()
        {
            var content = ReadElementContent();
            return bool.Parse(content);
        }

        public void ReadBytes(IBufferWriter<byte> writer)
        {
            var content = ReadElementContent();
            var bytes = Convert.FromBase64String(content);
            var span = writer.GetSpan(bytes.Length);
            bytes.CopyTo(span);
            writer.Advance(bytes.Length);
        }

        public char ReadChar()
        {
            var content = ReadElementContent();
            return content[0];
        }

        public DateTime ReadDateTime()
        {
            var content = ReadElementContent();
            return DateTime.Parse(content, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }

        public decimal ReadDecimal()
        {
            var content = ReadElementContent();
            return decimal.Parse(content, CultureInfo.InvariantCulture);
        }

        public float ReadF32()
        {
            var content = ReadElementContent();
            return float.Parse(content, CultureInfo.InvariantCulture);
        }

        public double ReadF64()
        {
            var content = ReadElementContent();
            return double.Parse(content, CultureInfo.InvariantCulture);
        }

        public short ReadI16()
        {
            var content = ReadElementContent();
            return short.Parse(content, CultureInfo.InvariantCulture);
        }

        public int ReadI32()
        {
            var content = ReadElementContent();
            return int.Parse(content, CultureInfo.InvariantCulture);
        }

        public long ReadI64()
        {
            var content = ReadElementContent();
            return long.Parse(content, CultureInfo.InvariantCulture);
        }

        public sbyte ReadI8()
        {
            var content = ReadElementContent();
            return sbyte.Parse(content, CultureInfo.InvariantCulture);
        }

        public T? ReadNullableRef<T>(IDeserialize<T> deserialize) where T : class
        {
            // If the element is empty or has xsi:nil, return null
            if (_reader.IsEmptyElement)
            {
                _reader.Read(); // consume the empty element
                return null;
            }
            return deserialize.Deserialize(this);
        }

        public string ReadString()
        {
            return ReadElementContent();
        }

        public ITypeDeserializer ReadType(ISerdeInfo typeInfo)
        {
            if (typeInfo.Kind == InfoKind.List || typeInfo.Kind == InfoKind.Dictionary)
            {
                _deserializeCollection.Initialize(typeInfo);
                return _deserializeCollection;
            }
            else if (typeInfo.Kind == InfoKind.CustomType || typeInfo.Kind == InfoKind.Nullable)
            {
                _deserializeType.Initialize();
                return _deserializeType;
            }
            else if (typeInfo.Kind == InfoKind.Enum)
            {
                return _deserializeEnum;
            }
            throw new InvalidOperationException($"Unexpected type kind: {typeInfo.Kind}");
        }

        public ushort ReadU16()
        {
            var content = ReadElementContent();
            return ushort.Parse(content, CultureInfo.InvariantCulture);
        }

        public uint ReadU32()
        {
            var content = ReadElementContent();
            return uint.Parse(content, CultureInfo.InvariantCulture);
        }

        public ulong ReadU64()
        {
            var content = ReadElementContent();
            return ulong.Parse(content, CultureInfo.InvariantCulture);
        }

        public byte ReadU8()
        {
            var content = ReadElementContent();
            return byte.Parse(content, CultureInfo.InvariantCulture);
        }

        public Int128 ReadI128()
        {
            var content = ReadElementContent();
            return Int128.Parse(content, CultureInfo.InvariantCulture);
        }

        public UInt128 ReadU128()
        {
            var content = ReadElementContent();
            return UInt128.Parse(content, CultureInfo.InvariantCulture);
        }

        public DateTimeOffset ReadDateTimeOffset()
        {
            var content = ReadElementContent();
            return DateTimeOffset.Parse(content, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }
    }
}
