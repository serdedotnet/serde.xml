
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial record StructWithIntField
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.StructWithIntField>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.StructWithIntField.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.StructWithIntField>.Serialize(Serde.Xml.Test.XmlTests.StructWithIntField value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteI32(_l_info, 0, value.X);
                _l_type.End(_l_info);
            }

        }
    }
}
