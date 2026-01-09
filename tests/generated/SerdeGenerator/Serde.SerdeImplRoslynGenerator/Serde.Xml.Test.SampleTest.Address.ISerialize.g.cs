
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class SampleTest
{
    partial record Address
    {
        sealed partial class _SerObj : Serde.ISerialize<Serde.Xml.Test.SampleTest.Address>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.SampleTest.Address.s_serdeInfo;

            void global::Serde.ISerialize<Serde.Xml.Test.SampleTest.Address>.Serialize(Serde.Xml.Test.SampleTest.Address value, global::Serde.ISerializer serializer)
            {
                var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
                var _l_type = serializer.WriteType(_l_info);
                _l_type.WriteString(_l_info, 0, value.Name);
                _l_type.WriteString(_l_info, 1, value.Line1);
                _l_type.WriteStringIfNotNull(_l_info, 2, value.City);
                _l_type.WriteString(_l_info, 3, value.State);
                _l_type.WriteString(_l_info, 4, value.Zip);
                _l_type.End(_l_info);
            }

        }
    }
}
