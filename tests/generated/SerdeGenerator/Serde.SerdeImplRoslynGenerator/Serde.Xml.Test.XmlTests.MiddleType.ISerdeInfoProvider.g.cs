
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class MiddleType
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "MiddleType",
        typeof(Serde.Xml.Test.XmlTests.MiddleType).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("MiddleValue", global::Serde.SerdeInfoProvider.GetSerializeInfo<int, global::Serde.I32Proxy>(), typeof(Serde.Xml.Test.XmlTests.MiddleType).GetProperty("MiddleValue")),
            ("Inner", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.XmlTests.InnerType, Serde.Xml.Test.XmlTests.InnerType>(), typeof(Serde.Xml.Test.XmlTests.MiddleType).GetProperty("Inner"))
        }
        );
    }
}
