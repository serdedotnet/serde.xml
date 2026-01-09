
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class OuterType
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.OuterType>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.OuterType.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.OuterType>.Serialize(Serde.Xml.Test.XmlTests.OuterType value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteString(_l_info, 0, value.OuterName);
                _l_type.WriteValue<Serde.Xml.Test.XmlTests.MiddleType, Serde.Xml.Test.XmlTests.MiddleType>(_l_info, 1, value.Middle);
                _l_type.End(_l_info);
            }

        }
    }
}
