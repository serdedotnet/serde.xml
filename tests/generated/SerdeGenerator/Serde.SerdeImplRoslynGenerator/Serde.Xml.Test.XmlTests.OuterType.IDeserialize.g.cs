
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class OuterType
    {
        sealed partial class _DeObj : Serde.IDeserialize<Serde.Xml.Test.XmlTests.OuterType>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.OuterType.s_serdeInfo;

            Serde.Xml.Test.XmlTests.OuterType Serde.IDeserialize<Serde.Xml.Test.XmlTests.OuterType>.Deserialize(IDeserializer deserializer)
            {
                string _l_outername = default!;
                Serde.Xml.Test.XmlTests.MiddleType _l_middle = default!;

                byte _r_assignedValid = 0;

                var _l_serdeInfo = global::Serde.SerdeInfoProvider.GetInfo(this);
                var typeDeserialize = deserializer.ReadType(_l_serdeInfo);
                while (true)
                {
                    var (_l_index_, _) = typeDeserialize.TryReadIndexWithName(_l_serdeInfo);
                    if (_l_index_ == Serde.ITypeDeserializer.EndOfType)
                    {
                        break;
                    }

                    switch (_l_index_)
                    {
                        case 0:
                            Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 0, _l_serdeInfo);
                            _l_outername = typeDeserialize.ReadString(_l_serdeInfo, _l_index_);
                            _r_assignedValid |= ((byte)1) << 0;
                            break;
                        case 1:
                            Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 1, _l_serdeInfo);
                            _l_middle = typeDeserialize.ReadValue<Serde.Xml.Test.XmlTests.MiddleType, Serde.Xml.Test.XmlTests.MiddleType>(_l_serdeInfo, _l_index_);
                            _r_assignedValid |= ((byte)1) << 1;
                            break;
                        case Serde.ITypeDeserializer.IndexNotFound:
                            typeDeserialize.SkipValue(_l_serdeInfo, _l_index_);
                            break;
                        default:
                            throw new InvalidOperationException("Unexpected index: " + _l_index_);
                    }
                }
                if ((_r_assignedValid & 0b11) != 0b11)
                {
                    throw Serde.DeserializeException.UnassignedMember();
                }
                var newType = new Serde.Xml.Test.XmlTests.OuterType() {
                    OuterName = _l_outername,
                    Middle = _l_middle,
                };

                return newType;
            }
        }
    }
}
