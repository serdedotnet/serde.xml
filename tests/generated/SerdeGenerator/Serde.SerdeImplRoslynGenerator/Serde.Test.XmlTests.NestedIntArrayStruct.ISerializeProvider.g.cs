
namespace Serde.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct : Serde.ISerializeProvider<Serde.Test.XmlTests.NestedIntArrayStruct>
    {
        static global::Serde.ISerialize<Serde.Test.XmlTests.NestedIntArrayStruct> global::Serde.ISerializeProvider<Serde.Test.XmlTests.NestedIntArrayStruct>.Instance { get; }
            = new Serde.Test.XmlTests.NestedIntArrayStruct._SerObj();
    }
}
