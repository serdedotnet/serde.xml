
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class ListItemWithAttribute
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "ListItemWithAttribute",
        typeof(Serde.Xml.Test.XmlTests.ListItemWithAttribute).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("Name", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.XmlTests.ListItemWithAttribute).GetProperty("Name"))
        }
        );
    }
}
