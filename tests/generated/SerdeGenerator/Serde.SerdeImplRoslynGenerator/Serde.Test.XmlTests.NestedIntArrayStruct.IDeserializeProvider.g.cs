
namespace Serde.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct : Serde.IDeserializeProvider<Serde.Test.XmlTests.NestedIntArrayStruct>
    {
        static global::Serde.IDeserialize<Serde.Test.XmlTests.NestedIntArrayStruct> global::Serde.IDeserializeProvider<Serde.Test.XmlTests.NestedIntArrayStruct>.Instance { get; }
            = new Serde.Test.XmlTests.NestedIntArrayStruct._DeObj();
    }
}
