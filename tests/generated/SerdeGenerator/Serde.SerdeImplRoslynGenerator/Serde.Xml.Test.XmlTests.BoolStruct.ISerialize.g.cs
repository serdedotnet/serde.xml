
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial struct BoolStruct
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.XmlTests.BoolStruct>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.BoolStruct.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.XmlTests.BoolStruct>.Serialize(Serde.Xml.Test.XmlTests.BoolStruct value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteBool(_l_info, 0, value.BoolField);
                _l_type.End(_l_info);
            }

        }
    }
}
