
using System;
using System.Buffers;

namespace Serde.Xml;

partial class XmlSerializer
{
    private sealed partial class Deserializer
    {
        /// <summary>
        /// Deserializer for enums.
        /// </summary>
        private sealed class DeserializeEnum : ITypeDeserializer
        {
            private readonly Deserializer _deserializer;

            public DeserializeEnum(Deserializer deserializer)
            {
                _deserializer = deserializer;
            }

            public int? SizeOpt => 1;

            public int TryReadIndex(ISerdeInfo info)
            {
                return TryReadIndexWithName(info).Item1;
            }

            public (int, string?) TryReadIndexWithName(ISerdeInfo info)
            {
                // Read the enum value as a string. Reader should be advanced to the content.
                var value = _deserializer._reader.ReadContentAsString();

                // Try to find the index by matching the string value
                var index = info.TryGetIndex(System.Text.Encoding.UTF8.GetBytes(value));
                return (index, index == ITypeDeserializer.IndexNotFound ? value : null);
            }

            public void End(ISerdeInfo info) { }

            // For enums, these methods return the discriminant value
            public byte ReadU8(ISerdeInfo info, int index) => (byte)index;
            public ushort ReadU16(ISerdeInfo info, int index) => (ushort)index;
            public uint ReadU32(ISerdeInfo info, int index) => (uint)index;
            public ulong ReadU64(ISerdeInfo info, int index) => (ulong)index;
            public sbyte ReadI8(ISerdeInfo info, int index) => (sbyte)index;
            public short ReadI16(ISerdeInfo info, int index) => (short)index;
            public int ReadI32(ISerdeInfo info, int index) => index;
            public long ReadI64(ISerdeInfo info, int index) => index;

            // These shouldn't be called for enums
            public bool ReadBool(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read bool from enum");
            public float ReadF32(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read float from enum");
            public double ReadF64(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read double from enum");
            public decimal ReadDecimal(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read decimal from enum");
            public char ReadChar(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read char from enum");
            public string ReadString(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read string from enum");
            public DateTime ReadDateTime(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read DateTime from enum");
            public DateTimeOffset ReadDateTimeOffset(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read DateTimeOffset from enum");
            public Int128 ReadI128(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read Int128 from enum");
            public UInt128 ReadU128(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot read UInt128 from enum");
            public void ReadBytes(ISerdeInfo info, int index, IBufferWriter<byte> writer) => throw new InvalidOperationException("Cannot read bytes from enum");
            public T ReadValue<T>(ISerdeInfo info, int index, IDeserialize<T> deserialize) where T : class? => throw new InvalidOperationException("Cannot read value from enum");
            public void SkipValue(ISerdeInfo info, int index) => throw new InvalidOperationException("Cannot skip value in enum");
        }
    }
}
