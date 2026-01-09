
#nullable enable

namespace Serde.Xml.Test;

partial class SampleTest
{
    partial record PurchaseOrder
    {
        private static global::Serde.ISerdeInfo s_serdeInfo = Serde.SerdeInfo.MakeCustom(
            "PurchaseOrder",
        typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetCustomAttributesData(),
        new (string, global::Serde.ISerdeInfo, System.Reflection.MemberInfo?)[] {
            ("ShipTo", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.SampleTest.Address, Serde.Xml.Test.SampleTest.Address>(), typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetField("ShipTo")),
            ("OrderDate", global::Serde.SerdeInfoProvider.GetSerializeInfo<string, global::Serde.StringProxy>(), typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetField("OrderDate")),
            ("Items", global::Serde.SerdeInfoProvider.GetSerializeInfo<Serde.Xml.Test.SampleTest.OrderedItem[], Serde.ArrayProxy.Ser<Serde.Xml.Test.SampleTest.OrderedItem, Serde.Xml.Test.SampleTest.OrderedItem>>(), typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetField("OrderedItems")),
            ("SubTotal", global::Serde.SerdeInfoProvider.GetSerializeInfo<decimal, global::Serde.DecimalProxy>(), typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetField("SubTotal")),
            ("ShipCost", global::Serde.SerdeInfoProvider.GetSerializeInfo<decimal, global::Serde.DecimalProxy>(), typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetField("ShipCost")),
            ("TotalCost", global::Serde.SerdeInfoProvider.GetSerializeInfo<decimal, global::Serde.DecimalProxy>(), typeof(Serde.Xml.Test.SampleTest.PurchaseOrder).GetField("TotalCost"))
        }
        );
    }
}
