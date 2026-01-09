
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial record StructWithIntField
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "StructWithIntField",
        typeof(Serde.Xml.Test.XmlTests.StructWithIntField).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("X", global::Serde.SerdeInfoProvider.GetSerializeInfo<int, global::Serde.I32Proxy>(), typeof(Serde.Xml.Test.XmlTests.StructWithIntField).GetProperty("X"))
        }
        );
    }
}
