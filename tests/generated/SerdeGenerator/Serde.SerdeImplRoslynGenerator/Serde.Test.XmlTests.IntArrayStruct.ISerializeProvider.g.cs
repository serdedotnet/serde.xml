
namespace Serde.Test;

partial class XmlTests
{
    partial struct IntArrayStruct : Serde.ISerializeProvider<Serde.Test.XmlTests.IntArrayStruct>
    {
        static global::Serde.ISerialize<Serde.Test.XmlTests.IntArrayStruct> global::Serde.ISerializeProvider<Serde.Test.XmlTests.IntArrayStruct>.Instance { get; }
            = new Serde.Test.XmlTests.IntArrayStruct._SerObj();
    }
}
