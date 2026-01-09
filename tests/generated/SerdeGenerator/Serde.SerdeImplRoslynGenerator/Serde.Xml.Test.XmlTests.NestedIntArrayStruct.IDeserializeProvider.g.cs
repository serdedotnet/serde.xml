
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct : Serde.IDeserializeProvider<Serde.Xml.Test.XmlTests.NestedIntArrayStruct>
    {
        static global::Serde.IDeserialize<Serde.Xml.Test.XmlTests.NestedIntArrayStruct> global::Serde.IDeserializeProvider<Serde.Xml.Test.XmlTests.NestedIntArrayStruct>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.NestedIntArrayStruct._DeObj();
    }
}
