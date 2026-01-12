
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class ListItemWithAttribute
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.ListItemWithAttribute>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.ListItemWithAttribute.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.ListItemWithAttribute>.Serialize(Serde.Xml.Test.XmlTests.ListItemWithAttribute value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteString(_l_info, 0, value.Name);
                _l_type.End(_l_info);
            }

        }
    }
}
