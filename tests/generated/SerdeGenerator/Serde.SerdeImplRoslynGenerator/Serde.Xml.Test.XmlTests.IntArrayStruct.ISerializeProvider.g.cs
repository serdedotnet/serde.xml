
namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct IntArrayStruct : Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.IntArrayStruct>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.XmlTests.IntArrayStruct> global::Serde.ISerializeProvider<Serde.Xml.Test.XmlTests.IntArrayStruct>.Instance { get; }
            = new Serde.Xml.Test.XmlTests.IntArrayStruct._SerObj();
    }
}
