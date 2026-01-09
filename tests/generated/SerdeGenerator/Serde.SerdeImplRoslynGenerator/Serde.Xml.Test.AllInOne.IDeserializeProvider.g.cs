
namespace Serde.Xml.Test;

partial record AllInOne : Serde.IDeserializeProvider<Serde.Xml.Test.AllInOne>
{
    static global::Serde.IDeserialize<Serde.Xml.Test.AllInOne> global::Serde.IDeserializeProvider<Serde.Xml.Test.AllInOne>.Instance { get; }
        = new Serde.Xml.Test.AllInOne._DeObj();
}
