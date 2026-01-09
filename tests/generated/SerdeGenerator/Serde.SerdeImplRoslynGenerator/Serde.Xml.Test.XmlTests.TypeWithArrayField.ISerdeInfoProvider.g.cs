
#nullable enable

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class TypeWithArrayField
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "TypeWithArrayField",
        typeof(Serde.Xml.Test.XmlTests.TypeWithArrayField).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("ArrayField", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.XmlTests.StructWithIntField[], Serde.ArrayProxy.Ser<Serde.Xml.Test.XmlTests.StructWithIntField, Serde.Xml.Test.XmlTests.StructWithIntField>>(), typeof(Serde.Xml.Test.XmlTests.TypeWithArrayField).GetField("ArrayField"))
        }
        );
    }
}
