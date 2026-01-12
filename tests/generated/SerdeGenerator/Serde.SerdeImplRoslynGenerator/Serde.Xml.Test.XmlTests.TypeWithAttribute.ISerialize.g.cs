
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class TypeWithAttribute
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.TypeWithAttribute>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.TypeWithAttribute.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.TypeWithAttribute>.Serialize(Serde.Xml.Test.XmlTests.TypeWithAttribute value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteString(_l_info, 0, value.Name);
                _l_type.WriteI32(_l_info, 1, value.Value);
                _l_type.End(_l_info);
            }

        }
    }
}
