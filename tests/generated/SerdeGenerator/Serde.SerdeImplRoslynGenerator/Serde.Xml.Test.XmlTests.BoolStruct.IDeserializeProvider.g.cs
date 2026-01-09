
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct BoolStruct : Serde.IDeserializeProvider<Serde.Xml.Test.XmlTests.BoolStruct>
    {
        static global::Serde.IDeserialize<Serde.Xml.Test.XmlTests.BoolStruct> global::Serde.IDeserializeProvider<Serde.Xml.Test.XmlTests.BoolStruct>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.BoolStruct._DeObj();
    }
}
