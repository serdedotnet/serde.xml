
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace Serde.Xml.Test;

public partial class XmlTests
{
    private const string AllInOneSerialized = """
<?xml version="1.0" encoding="utf-16"?>
<AllInOne>
  <BoolField>true</BoolField>
  <ByteField>255</ByteField>
  <UShortField>65535</UShortField>
  <UIntField>4294967295</UIntField>
  <ULongField>18446744073709551615</ULongField>
  <SByteField>127</SByteField>
  <ShortField>32767</ShortField>
  <IntField>2147483647</IntField>
  <LongField>9223372036854775807</LongField>
  <StringField>StringValue</StringField>
  <EscapedStringField>+0 11 222 333 44</EscapedStringField>
  <UIntArr>
    <unsignedInt>1</unsignedInt>
    <unsignedInt>2</unsignedInt>
    <unsignedInt>3</unsignedInt>
  </UIntArr>
  <NestedArr>
    <ArrayOfInt>
      <int>1</int>
    </ArrayOfInt>
    <ArrayOfInt>
      <int>2</int>
    </ArrayOfInt>
  </NestedArr>
  <IntImm>
    <int>1</int>
    <int>2</int>
  </IntImm>
  <Color>Blue</Color>
</AllInOne>
""";

    [Fact]
    public void AllInOneTest()
    {
        var result = XmlSerializer.Serialize(AllInOne.Sample);
        var sxs = SxsSerialize(AllInOne.Sample);
        Assert.Equal(AllInOneSerialized, sxs);
        Assert.Equal(AllInOneSerialized, result);
    }

    [Fact]
    public void AllInOneDeserializeTest()
    {
        // Use freshly serialized output to ensure format matches
        var serialized = XmlSerializer.Serialize(AllInOne.Sample);
        var deserialized = XmlSerializer.Deserialize<AllInOne>(serialized);
        Assert.Equal(AllInOne.Sample, deserialized);
    }

    [Fact]
    public void AllInOneRoundTripTest()
    {
        var serialized = XmlSerializer.Serialize(AllInOne.Sample);
        var deserialized = XmlSerializer.Deserialize<AllInOne>(serialized);
        Assert.Equal(AllInOne.Sample, deserialized);
    }

    private static string SxsSerialize<T>(T t)
    {
        var tmpX = new System.Xml.Serialization.XmlSerializer(typeof(T));
        var stringWriter = new StringWriter();
        var ns = new XmlSerializerNamespaces();
        ns.Add(string.Empty, string.Empty);
        using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, }))
        {
            tmpX.Serialize(xmlWriter, t, ns);
        }
        return stringWriter.ToString();
    }

    private static void AssertXmlEqual<T>(string expected, T t)
        where T : ISerializeProvider<T>
    {
        var baseline = SxsSerialize(t);
        Assert.Equal(expected, baseline);
        var result = XmlSerializer.Serialize(t);
        Assert.Equal(expected, result);
    }

    [GenerateSerialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial class NestedArrays
    {
        public int[][][] A = new[] { new[] { new[] { 1, 2, 3 } } };
    }

    [Fact]
    public void NestedArrTest()
    {
        const string expected = """
<?xml version="1.0" encoding="utf-16"?>
<NestedArrays>
  <A>
    <ArrayOfArrayOfInt>
      <ArrayOfInt>
        <int>1</int>
        <int>2</int>
        <int>3</int>
      </ArrayOfInt>
    </ArrayOfArrayOfInt>
  </A>
</NestedArrays>
""";
        AssertXmlEqual(expected, new NestedArrays());
    }

    [GenerateSerialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial class TypeWithArrayField
    {
        public StructWithIntField[] ArrayField = new[] {
              new StructWithIntField(1),
              new StructWithIntField(2),
              new StructWithIntField(3)
          };
    }

    [GenerateSerialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial record StructWithIntField(int X)
    {
        public StructWithIntField() : this(11) { }
    }

    [Fact]
    public void ArrayWithType()
    {
        var expected = """
<?xml version="1.0" encoding="utf-16"?>
<TypeWithArrayField>
  <ArrayField>
    <StructWithIntField>
      <X>1</X>
    </StructWithIntField>
    <StructWithIntField>
      <X>2</X>
    </StructWithIntField>
    <StructWithIntField>
      <X>3</X>
    </StructWithIntField>
  </ArrayField>
</TypeWithArrayField>
""";
        AssertXmlEqual(expected, new TypeWithArrayField());
    }

    [GenerateSerialize]
    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial struct BoolStruct
    {
        public bool BoolField;
    }

    [Fact]
    public void BoolStructTest()
    {
        var b = new BoolStruct() { BoolField = true };
        var result = XmlSerializer.Serialize(b);
        const string expected = """
<?xml version="1.0" encoding="utf-16"?>
<BoolStruct>
  <BoolField>true</BoolField>
</BoolStruct>
""";
        Assert.Equal(expected.Trim(), result);
    }

    [Fact]
    public void BoolStructRoundTripTest()
    {
        var b = new BoolStruct() { BoolField = true };
        var serialized = XmlSerializer.Serialize(b);
        var deserialized = XmlSerializer.Deserialize<BoolStruct>(serialized);
        Assert.Equal(b.BoolField, deserialized.BoolField);
    }

    [GenerateSerialize]
    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial struct IntArrayStruct
    {
        public int[] IntArray;
    }

    [Fact]
    public void IntArrayRoundTripTest()
    {
        var b = new IntArrayStruct() { IntArray = new[] { 1, 2, 3 } };
        var serialized = XmlSerializer.Serialize(b);
        var deserialized = XmlSerializer.Deserialize<IntArrayStruct>(serialized);
        Assert.Equal(b.IntArray, deserialized.IntArray);
    }

    [GenerateSerialize]
    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial struct NestedIntArrayStruct
    {
        public int[][] NestedArray;
    }

    [Fact]
    public void NestedArrayRoundTripTest()
    {
        var b = new NestedIntArrayStruct() { NestedArray = new[] { new[] { 1 }, new[] { 2, 3 } } };
        var serialized = XmlSerializer.Serialize(b);

        // First, verify simple inner array parsing works
        var innerXml = """
<?xml version="1.0" encoding="utf-16"?>
<IntArrayStruct>
<IntArray>
  <Int>1</Int>
</IntArray>
</IntArrayStruct>
""";
        var innerResult = XmlSerializer.Deserialize<IntArrayStruct>(innerXml);
        Assert.Single(innerResult.IntArray);
        Assert.Equal(1, innerResult.IntArray[0]);

        // Now test nested
        try
        {
            var deserialized = XmlSerializer.Deserialize<NestedIntArrayStruct>(serialized);
            Assert.Equal(b.NestedArray.Length, deserialized.NestedArray.Length);
            Assert.Equal(b.NestedArray[0], deserialized.NestedArray[0]);
            Assert.Equal(b.NestedArray[1], deserialized.NestedArray[1]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed with serialized XML:\n{serialized}\n\nException: {ex}");
        }
    }

    [GenerateSerialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.CamelCase)]
    public partial class MapTest1
    {
        public Dictionary<string, int> mapField = new Dictionary<string, int>()
        {
            ["abc"] = 1,
            ["def"] = 2
        };
    }

    [Fact]
    public void DictionaryTest()
    {
        Assert.Throws<NotSupportedException>(() => XmlSerializer.Serialize(new MapTest1()));
    }

    private static void VerifyCompatSerialize<T>(T t, string expected)
        where T : ISerializeProvider<T>
    {
        var result = LegacySerialize(t);
        Assert.Equal(expected, result);
        result = XmlSerializer.Serialize(t);
        Assert.Equal(expected, result);
    }

    public static string LegacySerialize<T>(T t)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
        {
            serializer.Serialize(writer, t, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        }
        return stringWriter.ToString();
    }

    [GenerateSerialize]
    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial class OuterType
    {
        public string OuterName { get; set; } = "";
        public MiddleType Middle { get; set; } = new();
    }

    [GenerateSerialize]
    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial class MiddleType
    {
        public int MiddleValue { get; set; }
        public InnerType Inner { get; set; } = new();
    }

    [GenerateSerialize]
    [GenerateDeserialize]
    [SerdeTypeOptions(MemberFormat = MemberFormat.None)]
    public partial class InnerType
    {
        public string InnerText { get; set; } = "";
        public bool InnerFlag { get; set; }
    }

    [Fact]
    public void ThreeNestedTypesDeserializeTest()
    {
        var original = new OuterType
        {
            OuterName = "OuterValue",
            Middle = new MiddleType
            {
                MiddleValue = 42,
                Inner = new InnerType
                {
                    InnerText = "DeepNested",
                    InnerFlag = true
                }
            }
        };

        var serialized = XmlSerializer.Serialize(original);

        const string expectedXml = """
<?xml version="1.0" encoding="utf-16"?>
<OuterType>
  <OuterName>OuterValue</OuterName>
  <Middle>
    <MiddleValue>42</MiddleValue>
    <Inner>
      <InnerText>DeepNested</InnerText>
      <InnerFlag>true</InnerFlag>
    </Inner>
  </Middle>
</OuterType>
""";
        Assert.Equal(expectedXml, serialized);

        var deserialized = XmlSerializer.Deserialize<OuterType>(serialized);

        Assert.Equal(original.OuterName, deserialized.OuterName);
        Assert.Equal(original.Middle.MiddleValue, deserialized.Middle.MiddleValue);
        Assert.Equal(original.Middle.Inner.InnerText, deserialized.Middle.Inner.InnerText);
        Assert.Equal(original.Middle.Inner.InnerFlag, deserialized.Middle.Inner.InnerFlag);
    }

    /// <summary>
    /// Test that when deserialization throws an exception, we get the original exception
    /// rather than an exception from Dispose (e.g., "Deserializer disposed before reaching end of XML").
    /// </summary>
    [Fact]
    public void DeserializeExceptionNotHiddenByDispose()
    {
        // XML with an invalid boolean value AND extra content after it.
        // This causes:
        // 1. FormatException during bool.Parse("notaboolean")
        // 2. Dispose() would also throw because reader is at <ExtraContent>, not at </BoolStruct>
        // Without the fix, the Dispose exception would hide the original FormatException.
        const string invalidXml = """
<?xml version="1.0" encoding="utf-16"?>
<BoolStruct>
  <BoolField>notaboolean</BoolField>
  <ExtraContent>this causes Dispose to fail</ExtraContent>
</BoolStruct>
""";
        var ex = Assert.Throws<FormatException>(() => XmlSerializer.Deserialize<BoolStruct>(invalidXml));
        // Verify we got the parsing exception, not an XmlException from Dispose
        Assert.Contains("notaboolean", ex.Message, StringComparison.OrdinalIgnoreCase);
    }
}