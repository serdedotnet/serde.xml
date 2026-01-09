
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.NestedIntArrayStruct>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.NestedIntArrayStruct.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.NestedIntArrayStruct>.Serialize(Serde.Xml.Test.XmlTests.NestedIntArrayStruct value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<int[][], Serde.ArrayProxy.Ser<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>>(_l_info, 0, value.NestedArray);
                _l_type.End(_l_info);
            }

        }
    }
}
