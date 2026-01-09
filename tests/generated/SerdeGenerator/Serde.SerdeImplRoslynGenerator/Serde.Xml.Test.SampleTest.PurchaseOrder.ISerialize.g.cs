
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class SampleTest
{
    partial record PurchaseOrder
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.SampleTest.PurchaseOrder>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.SampleTest.PurchaseOrder.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.SampleTest.PurchaseOrder>.Serialize(Serde.Xml.Test.SampleTest.PurchaseOrder value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<Serde.Xml.Test.SampleTest.Address, Serde.Xml.Test.SampleTest.Address>(_l_info, 0, value.ShipTo);
                _l_type.WriteString(_l_info, 1, value.OrderDate);
                _l_type.WriteValue<Serde.Xml.Test.SampleTest.OrderedItem[], Serde.ArrayProxy.Ser<Serde.Xml.Test.SampleTest.OrderedItem, Serde.Xml.Test.SampleTest.OrderedItem>>(_l_info, 2, value.OrderedItems);
                _l_type.WriteDecimal(_l_info, 3, value.SubTotal);
                _l_type.WriteDecimal(_l_info, 4, value.ShipCost);
                _l_type.WriteDecimal(_l_info, 5, value.TotalCost);
                _l_type.End(_l_info);
            }

        }
    }
}
