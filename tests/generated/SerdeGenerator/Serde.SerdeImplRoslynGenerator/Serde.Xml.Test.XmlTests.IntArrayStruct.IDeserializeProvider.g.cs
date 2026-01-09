
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct IntArrayStruct : Serde.IDeserializeProvider<Serde.Xml.Test.XmlTests.IntArrayStruct>
    {
        static global::Serde.IDeserialize<Serde.Xml.Test.XmlTests.IntArrayStruct> global::Serde.IDeserializeProvider<Serde.Xml.Test.XmlTests.IntArrayStruct>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.IntArrayStruct._DeObj();
    }
}
