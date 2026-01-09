
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct IntArrayStruct
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.IntArrayStruct>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.IntArrayStruct.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.IntArrayStruct>.Serialize(Serde.Xml.Test.XmlTests.IntArrayStruct value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>(_l_info, 0, value.IntArray);
                _l_type.End(_l_info);
            }

        }
    }
}
