
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class TypeWithAttribute
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "TypeWithAttribute",
        typeof(Serde.Xml.Test.XmlTests.TypeWithAttribute).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("Name", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.XmlTests.TypeWithAttribute).GetProperty("Name")),
            ("Value", global::Serde.SerdeInfoProvider.GetSerializeInfo<int, global::Serde.I32Proxy>(), typeof(Serde.Xml.Test.XmlTests.TypeWithAttribute).GetProperty("Value"))
        }
        );
    }
}
