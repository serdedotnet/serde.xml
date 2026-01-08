
namespace Serde.Test;

partial class XmlTests
{
    partial struct BoolStruct : Serde.ISerializeProvider<Serde.Test.XmlTests.BoolStruct>
    {
        static global::Serde.ISerialize<Serde.Test.XmlTests.BoolStruct> global::Serde.ISerializeProvider<Serde.Test.XmlTests.BoolStruct>.Instance { get; }
            = new Serde.Test.XmlTests.BoolStruct._SerObj();
    }
}
