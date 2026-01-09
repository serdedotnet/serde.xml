
namespace Serde.Xml.Test;

partial record AllInOne
{
    partial class ColorEnumProxy : Serde.ISerdeProvider<Serde.Xml.Test.AllInOne.ColorEnumProxy, Serde.Xml.Test.AllInOne.ColorEnumProxy, Serde.Xml.Test.AllInOne.ColorEnum>
    {
        static Serde.Xml.Test.AllInOne.ColorEnumProxy global::Serde.ISerdeProvider<Serde.Xml.Test.AllInOne.ColorEnumProxy, Serde.Xml.Test.AllInOne.ColorEnumProxy, Serde.Xml.Test.AllInOne.ColorEnum>.Instance { get; }
            = new Serde.Xml.Test.AllInOne.ColorEnumProxy();
    }
}
