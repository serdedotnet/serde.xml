
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class ParentWithAttributeOnlyList
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList>.Serialize(Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<Serde.Xml.Test.XmlTests.ListItemWithAttribute[], Serde.ArrayProxy.Ser<Serde.Xml.Test.XmlTests.ListItemWithAttribute, Serde.Xml.Test.XmlTests.ListItemWithAttribute>>(_l_info, 0, value.Items);
                _l_type.End(_l_info);
            }

        }
    }
}
