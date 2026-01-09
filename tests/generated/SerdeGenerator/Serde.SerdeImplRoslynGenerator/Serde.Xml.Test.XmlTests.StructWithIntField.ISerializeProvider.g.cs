
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial record StructWithIntField : Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.StructWithIntField>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.XmlTests.StructWithIntField> global::Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.StructWithIntField>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.StructWithIntField._SerObj();
    }
}
