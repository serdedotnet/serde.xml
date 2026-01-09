
namespace Serde.Xml.Test;

partial record AllInOne : Serde.ISerdeProvider<Serde.Xml.Test.AllInOne, Serde.Xml.Test.AllInOne._SerdeObj, Serde.Xml.Test.AllInOne>
{
    static Serde.Xml.Test.AllInOne._SerdeObj global::Serde.ISerdeProvider<Serde.Xml.Test.AllInOne, Serde.Xml.Test.AllInOne._SerdeObj, Serde.Xml.Test.AllInOne>.Instance { get; }
        = new Serde.Xml.Test.AllInOne._SerdeObj();
}
