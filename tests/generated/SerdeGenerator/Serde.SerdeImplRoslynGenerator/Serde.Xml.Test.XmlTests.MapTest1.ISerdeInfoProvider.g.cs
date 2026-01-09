
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class MapTest1
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "MapTest1",
        typeof(Serde.Xml.Test.XmlTests.MapTest1).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("mapField", global::Serde.SerdeInfoProvider.GetSerializeInfo<System.Collections.Generic.Dictionary<string, int>, Serde.DictProxy.Ser<string, int, global::Serde.StringProxy, global::Serde.I32Proxy>>(), typeof(Serde.Xml.Test.XmlTests.MapTest1).GetField("mapField"))
        }
        );
    }
}
