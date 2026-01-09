
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class InnerType
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "InnerType",
        typeof(Serde.Xml.Test.XmlTests.InnerType).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("InnerText", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.XmlTests.InnerType).GetProperty("InnerText")),
            ("InnerFlag", global::Serde.SerdeInfoProvider.GetSerializeInfo<bool, global::Serde.BoolProxy>(), typeof(Serde.Xml.Test.XmlTests.InnerType).GetProperty("InnerFlag"))
        }
        );
    }
}
