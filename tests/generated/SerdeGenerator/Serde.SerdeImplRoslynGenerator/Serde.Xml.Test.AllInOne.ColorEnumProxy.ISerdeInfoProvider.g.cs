
#nullable enable

namespace Serde.Xml.Test;

partial record AllInOne
{
    partial class ColorEnumProxy : global::Serde.ISerdeInfoProvider
    {
        global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo { get; } = Serde.SerdeInfo.MakeEnum(
            "ColorEnum",
        typeof(Serde.Xml.Test.AllInOne.ColorEnum).GetCustomAttributesData(),
        global::Serde.SerdeInfoProvider.GetSerializeInfo<int, global::Serde.I32Proxy>(),
        new (string, System.Reflection.MemberInfo?)[] {
            ("Red", typeof(Serde.Xml.Test.AllInOne.ColorEnum).GetField("Red")),
            ("Blue", typeof(Serde.Xml.Test.AllInOne.ColorEnum).GetField("Blue")),
            ("Green", typeof(Serde.Xml.Test.AllInOne.ColorEnum).GetField("Green"))
        }
        );
    }
}
