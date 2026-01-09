
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class TypeWithArrayField
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.TypeWithArrayField>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.TypeWithArrayField.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.TypeWithArrayField>.Serialize(Serde.Xml.Test.XmlTests.TypeWithArrayField value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteValue<Serde.Xml.Test.XmlTests.StructWithIntField[], Serde.ArrayProxy.Ser<Serde.Xml.Test.XmlTests.StructWithIntField, Serde.Xml.Test.XmlTests.StructWithIntField>>(_l_info, 0, value.ArrayField);
                _l_type.End(_l_info);
            }

        }
    }
}
