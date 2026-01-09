
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class MiddleType
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.MiddleType>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.MiddleType.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.MiddleType>.Serialize(Serde.Xml.Test.XmlTests.MiddleType value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteI32(_l_info, 0, value.MiddleValue);
                _l_type.WriteValue<Serde.Xml.Test.XmlTests.InnerType, Serde.Xml.Test.XmlTests.InnerType>(_l_info, 1, value.Inner);
                _l_type.End(_l_info);
            }

        }
    }
}
