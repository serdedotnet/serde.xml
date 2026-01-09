
#nullable enable

namespace Serde.Xml.Test;

partial record AllInOne
{
    private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
        "AllInOne",
    typeof(Serde.Xml.Test.AllInOne).GetCustomAttributesData(),
    new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
        ("BoolField", global::Serde.SerdeInfoProvider.GetSerializeInfo<bool, global::Serde.BoolProxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("BoolField")),
        ("ByteField", global::Serde.SerdeInfoProvider.GetSerializeInfo<byte, global::Serde.U8Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("ByteField")),
        ("UShortField", global::Serde.SerdeInfoProvider.GetSerializeInfo<ushort, global::Serde.U16Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("UShortField")),
        ("UIntField", global::Serde.SerdeInfoProvider.GetSerializeInfo<uint, global::Serde.U32Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("UIntField")),
        ("ULongField", global::Serde.SerdeInfoProvider.GetSerializeInfo<ulong, global::Serde.U64Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("ULongField")),
        ("SByteField", global::Serde.SerdeInfoProvider.GetSerializeInfo<sbyte, global::Serde.I8Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("SByteField")),
        ("ShortField", global::Serde.SerdeInfoProvider.GetSerializeInfo<short, global::Serde.I16Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("ShortField")),
        ("IntField", global::Serde.SerdeInfoProvider.GetSerializeInfo<int, global::Serde.I32Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("IntField")),
        ("LongField", global::Serde.SerdeInfoProvider.GetSerializeInfo<long, global::Serde.I64Proxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("LongField")),
        ("StringField", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("StringField")),
        ("EscapedStringField", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("EscapedStringField")),
        ("NullStringField", global::Serde.SerdeInfoProvider.GetSerializeInfo<string?, Serde.NullableRefProxy.Ser<string, global::Serde.StringProxy>>(), typeof(Serde.Xml.Test.AllInOne).GetField("NullStringField")),
        ("UIntArr", global::Serde.SerdeInfoProvider.GetSerializeInfo<uint[], Serde.ArrayProxy.Ser<uint, global::Serde.U32Proxy>>(), typeof(Serde.Xml.Test.AllInOne).GetField("UIntArr")),
        ("NestedArr", global::Serde.SerdeInfoProvider.GetSerializeInfo<int[][], Serde.ArrayProxy.Ser<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>>(), typeof(Serde.Xml.Test.AllInOne).GetField("NestedArr")),
        ("IntImm", global::Serde.SerdeInfoProvider.GetSerializeInfo<System.Collections.Immutable.ImmutableArray<int>, Serde.ImmutableArrayProxy.Ser<int, global::Serde.I32Proxy>>(), typeof(Serde.Xml.Test.AllInOne).GetField("IntImm")),
        ("Color", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.AllInOne.ColorEnum, Serde.Xml.Test.AllInOne.ColorEnumProxy>(), typeof(Serde.Xml.Test.AllInOne).GetField("Color"))
    }
    );
}
