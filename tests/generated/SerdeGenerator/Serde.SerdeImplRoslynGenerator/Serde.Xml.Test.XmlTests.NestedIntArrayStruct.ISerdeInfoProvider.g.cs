
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "NestedIntArrayStruct",
        typeof(Serde.Xml.Test.XmlTests.NestedIntArrayStruct).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("NestedArray", global::Serde.SerdeInfoProvider.GetSerializeInfo<int[][], Serde.ArrayProxy.Ser<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>>(), typeof(Serde.Xml.Test.XmlTests.NestedIntArrayStruct).GetField("NestedArray"))
        }
        );
    }
}
