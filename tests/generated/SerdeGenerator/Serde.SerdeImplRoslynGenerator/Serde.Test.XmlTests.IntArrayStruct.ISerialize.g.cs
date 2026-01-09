
#nullable enable

using System;
using Serde;

namespace Serde.Test;

partial class XmlTests
{
    partial struct IntArrayStruct
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Test.XmlTests.IntArrayStruct>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Test.XmlTests.IntArrayStruct.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Test.XmlTests.IntArrayStruct>.Serialize(Serde.Test.XmlTests.IntArrayStruct value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>(_l_info, 0, value.IntArray);
                _l_type.End(_l_info);
            }

        }
    }
}
