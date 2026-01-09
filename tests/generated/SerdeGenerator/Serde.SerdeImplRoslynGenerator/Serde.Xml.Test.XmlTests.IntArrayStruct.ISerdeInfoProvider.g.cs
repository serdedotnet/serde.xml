
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct IntArrayStruct
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "IntArrayStruct",
        typeof(Serde.Xml.Test.XmlTests.IntArrayStruct).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("IntArray", global::Serde.SerdeInfoProvider.GetSerializeInfo<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>(), typeof(Serde.Xml.Test.XmlTests.IntArrayStruct).GetField("IntArray"))
        }
        );
    }
}
