
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class OuterType
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "OuterType",
        typeof(Serde.Xml.Test.XmlTests.OuterType).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("OuterName", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.XmlTests.OuterType).GetProperty("OuterName")),
            ("Middle", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.XmlTests.MiddleType, Serde.Xml.Test.XmlTests.MiddleType>(), typeof(Serde.Xml.Test.XmlTests.OuterType).GetProperty("Middle"))
        }
        );
    }
}
