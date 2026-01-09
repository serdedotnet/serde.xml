
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class MapTest1
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.MapTest1>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.MapTest1.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.MapTest1>.Serialize(Serde.Xml.Test.XmlTests.MapTest1 value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<System.Collections.Generic.Dictionary<string, int>, Serde.DictProxy.Ser<string, int, global::Serde.StringProxy, global::Serde.I32Proxy>>(_l_info, 0, value.mapField);
                _l_type.End(_l_info);
            }

        }
    }
}
