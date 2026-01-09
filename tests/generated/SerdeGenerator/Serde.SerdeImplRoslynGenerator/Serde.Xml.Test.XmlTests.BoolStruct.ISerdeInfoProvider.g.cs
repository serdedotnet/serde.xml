
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct BoolStruct
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "BoolStruct",
        typeof(Serde.Xml.Test.XmlTests.BoolStruct).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("BoolField", global::Serde.SerdeInfoProvider.GetSerializeInfo<bool, global::Serde.BoolProxy>(), typeof(Serde.Xml.Test.XmlTests.BoolStruct).GetField("BoolField"))
        }
        );
    }
}
