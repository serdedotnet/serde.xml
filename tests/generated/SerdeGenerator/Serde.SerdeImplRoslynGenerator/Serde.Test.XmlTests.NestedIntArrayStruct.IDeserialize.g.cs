
#nullable enable

using System;
using Serde;

namespace Serde.Test;

partial class XmlTests
{
    partial struct NestedIntArrayStruct
    {
        sealed partial class _DeObj : Serde.IDeserialize<Serde.Test.XmlTests.NestedIntArrayStruct>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Test.XmlTests.NestedIntArrayStruct.s_serdeInfo;

            Serde.Test.XmlTests.NestedIntArrayStruct Serde.IDeserialize<Serde.Test.XmlTests.NestedIntArrayStruct>.Deserialize(IDeserializer deserializer)
            {
                int[][] _l_nestedarray = default!;

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
                            _l_nestedarray = typeDeserialize.ReadValue<int[][], Serde.ArrayProxy.De<int[], Serde.ArrayProxy.De<int, global::Serde.I32Proxy>>>(_l_serdeInfo, _l_index_);
                            _r_assignedValid |= ((byte)1) << 0;
                            break;
                        case Serde.ITypeDeserializer.IndexNotFound:
                            typeDeserialize.SkipValue(_l_serdeInfo, _l_index_);
                            break;
                        default:
                            throw new InvalidOperationException("Unexpected index: " + _l_index_);
                    }
                }
                if ((_r_assignedValid & 0b1) != 0b1)
                {
                    throw Serde.DeserializeException.UnassignedMember();
                }
                var newType = new Serde.Test.XmlTests.NestedIntArrayStruct() {
                    NestedArray = _l_nestedarray,
                };

                return newType;
            }
        }
    }
}
