
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct : Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.NestedIntArrayStruct>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.XmlTests.NestedIntArrayStruct> global::Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.NestedIntArrayStruct>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.NestedIntArrayStruct._SerObj();
    }
}
