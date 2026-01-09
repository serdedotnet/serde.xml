
#nullable enable

namespace Serde.Test;

partial class XmlTests
{
    partial struct IntArrayStruct
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "IntArrayStruct",
        typeof(Serde.Test.XmlTests.IntArrayStruct).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("IntArray", global::Serde.SerdeInfoProvider.GetSerializeInfo<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>(), typeof(Serde.Test.XmlTests.IntArrayStruct).GetField("IntArray"))
        }
        );
    }
}
