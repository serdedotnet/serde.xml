
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class ParentWithAttributeOnlyList
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "ParentWithAttributeOnlyList",
        typeof(Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("Items", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.XmlTests.ListItemWithAttribute[], Serde.ArrayProxy.Ser<Serde.Xml.Test.XmlTests.ListItemWithAttribute, Serde.Xml.Test.XmlTests.ListItemWithAttribute>>(), typeof(Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList).GetProperty("Items"))
        }
        );
    }
}
