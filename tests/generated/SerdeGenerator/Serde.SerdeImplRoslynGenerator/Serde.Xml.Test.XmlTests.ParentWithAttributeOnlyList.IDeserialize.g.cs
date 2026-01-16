
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial class XmlTests
{
    partial class ParentWithAttributeOnlyList
    {
        sealed partial class _DeObj : Serde.IDeserialize<Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList>
        {
            global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList.s_serdeInfo;

            Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList Serde.IDeserialize<Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList>.Deserialize(IDeserializer deserializer)
            {
                Serde.Xml.Test.XmlTests.ListItemWithAttribute[] _l_items = default!;

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
                            _l_items = typeDeserialize.ReadValue<Serde.Xml.Test.XmlTests.ListItemWithAttribute[], Serde.ArrayProxy.De<Serde.Xml.Test.XmlTests.ListItemWithAttribute, Serde.Xml.Test.XmlTests.ListItemWithAttribute>>(_l_serdeInfo, _l_index_);
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
                var newType = new Serde.Xml.Test.XmlTests.ParentWithAttributeOnlyList() {
                    Items = _l_items,
                };

                return newType;
            }
        }
    }
}
