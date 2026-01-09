
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct BoolStruct : Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.BoolStruct>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.XmlTests.BoolStruct> global::Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.BoolStruct>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.BoolStruct._SerObj();
    }
}
