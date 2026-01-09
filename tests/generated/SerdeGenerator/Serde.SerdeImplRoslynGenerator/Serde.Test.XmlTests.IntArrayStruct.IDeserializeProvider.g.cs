
namespace Serde.Test;

partial class XmlTests
{
    partial struct IntArrayStruct : Serde.IDeserializeProvider<Serde.Test.XmlTests.IntArrayStruct>
    {
        static global::Serde.IDeserialize<Serde.Test.XmlTests.IntArrayStruct> global::Serde.IDeserializeProvider<Serde.Test.XmlTests.IntArrayStruct>.Instance { get; }
            = new Serde.Test.XmlTests.IntArrayStruct._DeObj();
    }
}
