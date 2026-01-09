
namespace Serde.Xml.Test;

partial record AllInOne : Serde.ISerializeProvider<Serde.Xml.Test.AllInOne>
{
    static global::Serde.ISerialize<Serde.Xml.Test.AllInOne> global::Serde.ISerializeProvider<Serde.Xml.Test.AllInOne>.Instance { get; }
        = new Serde.Xml.Test.AllInOne._SerObj();
}
