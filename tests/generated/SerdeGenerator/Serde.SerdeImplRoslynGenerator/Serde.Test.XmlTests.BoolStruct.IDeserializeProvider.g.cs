
namespace Serde.Test;

partial class XmlTests
{
    partial struct BoolStruct : Serde.IDeserializeProvider<Serde.Test.XmlTests.BoolStruct>
    {
        static global::Serde.IDeserialize<Serde.Test.XmlTests.BoolStruct> global::Serde.IDeserializeProvider<Serde.Test.XmlTests.BoolStruct>.Instance { get; }
            = new Serde.Test.XmlTests.BoolStruct._DeObj();
    }
}
