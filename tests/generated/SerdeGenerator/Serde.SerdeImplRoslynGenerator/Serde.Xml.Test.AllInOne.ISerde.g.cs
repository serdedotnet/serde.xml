
#nullable enable

using System;
using Serde;

namespace Serde.Xml.Test;

partial record AllInOne
{
    sealed partial class _SerdeObj : global::Serde.ISerde<Serde.Xml.Test.AllInOne>
    {
        global::Serde.ISerdeInfo global::Serde.ISerdeInfoProvider.SerdeInfo => Serde.Xml.Test.AllInOne.s_serdeInfo;

        void global::Serde.ISerialize<Serde.Xml.Test.AllInOne>.Serialize(Serde.Xml.Test.AllInOne value, global::Serde.ISerializer serializer)
        {
            var _l_info = global::Serde.SerdeInfoProvider.GetInfo(this);
            var _l_type = serializer.WriteType(_l_info);
            _l_type.WriteBool(_l_info, 0, value.BoolField);
            _l_type.WriteU8(_l_info, 1, value.ByteField);
            _l_type.WriteU16(_l_info, 2, value.UShortField);
            _l_type.WriteU32(_l_info, 3, value.UIntField);
            _l_type.WriteU64(_l_info, 4, value.ULongField);
            _l_type.WriteI8(_l_info, 5, value.SByteField);
            _l_type.WriteI16(_l_info, 6, value.ShortField);
            _l_type.WriteI32(_l_info, 7, value.IntField);
            _l_type.WriteI64(_l_info, 8, value.LongField);
            _l_type.WriteString(_l_info, 9, value.StringField);
            _l_type.WriteString(_l_info, 10, value.EscapedStringField);
            _l_type.WriteStringIfNotNull(_l_info, 11, value.NullStringField);
            _l_type.WriteValue<uint[], Serde.ArrayProxy.Ser<uint, global::Serde.U32Proxy>>(_l_info, 12, value.UIntArr);
            _l_type.WriteValue<int[][], Serde.ArrayProxy.Ser<int[], Serde.ArrayProxy.Ser<int, global::Serde.I32Proxy>>>(_l_info, 13, value.NestedArr);
            _l_type.WriteBoxedValue<System.Collections.Immutable.ImmutableArray<int>, Serde.ImmutableArrayProxy.Ser<int, global::Serde.I32Proxy>>(_l_info, 14, value.IntImm);
            _l_type.WriteBoxedValue<Serde.Xml.Test.AllInOne.ColorEnum, Serde.Xml.Test.AllInOne.ColorEnumProxy>(_l_info, 15, value.Color);
            _l_type.End(_l_info);
        }
        Serde.Xml.Test.AllInOne Serde.IDeserialize<Serde.Xml.Test.AllInOne>.Deserialize(IDeserializer deserializer)
        {
            bool _l_boolfield = default!;
            byte _l_bytefield = default!;
            ushort _l_ushortfield = default!;
            uint _l_uintfield = default!;
            ulong _l_ulongfield = default!;
            sbyte _l_sbytefield = default!;
            short _l_shortfield = default!;
            int _l_intfield = default!;
            long _l_longfield = default!;
            string _l_stringfield = default!;
            string _l_escapedstringfield = default!;
            string? _l_nullstringfield = default!;
            uint[] _l_uintarr = default!;
            int[][] _l_nestedarr = default!;
            System.Collections.Immutable.ImmutableArray<int> _l_intimm = default!;
            Serde.Xml.Test.AllInOne.ColorEnum _l_color = default!;

            ushort _r_assignedValid = 0;

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
                        _l_boolfield = typeDeserialize.ReadBool(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 0;
                        break;
                    case 1:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 1, _l_serdeInfo);
                        _l_bytefield = typeDeserialize.ReadU8(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 1;
                        break;
                    case 2:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 2, _l_serdeInfo);
                        _l_ushortfield = typeDeserialize.ReadU16(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 2;
                        break;
                    case 3:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 3, _l_serdeInfo);
                        _l_uintfield = typeDeserialize.ReadU32(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 3;
                        break;
                    case 4:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 4, _l_serdeInfo);
                        _l_ulongfield = typeDeserialize.ReadU64(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 4;
                        break;
                    case 5:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 5, _l_serdeInfo);
                        _l_sbytefield = typeDeserialize.ReadI8(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 5;
                        break;
                    case 6:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 6, _l_serdeInfo);
                        _l_shortfield = typeDeserialize.ReadI16(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 6;
                        break;
                    case 7:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 7, _l_serdeInfo);
                        _l_intfield = typeDeserialize.ReadI32(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 7;
                        break;
                    case 8:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 8, _l_serdeInfo);
                        _l_longfield = typeDeserialize.ReadI64(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 8;
                        break;
                    case 9:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 9, _l_serdeInfo);
                        _l_stringfield = typeDeserialize.ReadString(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 9;
                        break;
                    case 10:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 10, _l_serdeInfo);
                        _l_escapedstringfield = typeDeserialize.ReadString(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 10;
                        break;
                    case 11:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 11, _l_serdeInfo);
                        _l_nullstringfield = typeDeserialize.ReadValue<string?, Serde.NullableRefProxy.De<string, global::Serde.StringProxy>>(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 11;
                        break;
                    case 12:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 12, _l_serdeInfo);
                        _l_uintarr = typeDeserialize.ReadValue<uint[], Serde.ArrayProxy.De<uint, global::Serde.U32Proxy>>(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 12;
                        break;
                    case 13:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 13, _l_serdeInfo);
                        _l_nestedarr = typeDeserialize.ReadValue<int[][], Serde.ArrayProxy.De<int[], Serde.ArrayProxy.De<int, global::Serde.I32Proxy>>>(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 13;
                        break;
                    case 14:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 14, _l_serdeInfo);
                        _l_intimm = typeDeserialize.ReadBoxedValue<System.Collections.Immutable.ImmutableArray<int>, Serde.ImmutableArrayProxy.De<int, global::Serde.I32Proxy>>(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 14;
                        break;
                    case 15:
                        Serde.DeserializeException.ThrowIfDuplicate(_r_assignedValid, 15, _l_serdeInfo);
                        _l_color = typeDeserialize.ReadBoxedValue<Serde.Xml.Test.AllInOne.ColorEnum, Serde.Xml.Test.AllInOne.ColorEnumProxy>(_l_serdeInfo, _l_index_);
                        _r_assignedValid |= ((ushort)1) << 15;
                        break;
                    case Serde.ITypeDeserializer.IndexNotFound:
                        typeDeserialize.SkipValue(_l_serdeInfo, _l_index_);
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected index: " + _l_index_);
                }
            }
            if ((_r_assignedValid & 0b1111011111111111) != 0b1111011111111111)
            {
                throw Serde.DeserializeException.UnassignedMember();
            }
            var newType = new Serde.Xml.Test.AllInOne() {
                BoolField = _l_boolfield,
                ByteField = _l_bytefield,
                UShortField = _l_ushortfield,
                UIntField = _l_uintfield,
                ULongField = _l_ulongfield,
                SByteField = _l_sbytefield,
                ShortField = _l_shortfield,
                IntField = _l_intfield,
                LongField = _l_longfield,
                StringField = _l_stringfield,
                EscapedStringField = _l_escapedstringfield,
                NullStringField = _l_nullstringfield,
                UIntArr = _l_uintarr,
                NestedArr = _l_nestedarr,
                IntImm = _l_intimm,
                Color = _l_color,
            };

            return newType;
        }
    }
}
