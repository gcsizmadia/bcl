// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

using EgonsoftHU.Extensions.Bcl.Exceptions;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    public partial class EnumInfo<TEnum>
    {
        /// <summary>
        /// Computes the bitwise complement of the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The bitwise complement of the specified <paramref name="value"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        public static EnumInfo<TEnum> operator ~(EnumInfo<TEnum> value)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => ~(EnumInfo<TEnum, sbyte>)value,
                TypeCode.Int16 => ~(EnumInfo<TEnum, short>)value,
                TypeCode.Int32 => ~(EnumInfo<TEnum, int>)value,
                TypeCode.Int64 => ~(EnumInfo<TEnum, long>)value,
                TypeCode.Byte => ~(EnumInfo<TEnum, byte>)value,
                TypeCode.UInt16 => ~(EnumInfo<TEnum, ushort>)value,
                TypeCode.UInt32 => ~(EnumInfo<TEnum, uint>)value,
                TypeCode.UInt64 => ~(EnumInfo<TEnum, ulong>)value,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Computes the bitwise logical OR of the <paramref name="left"/> and <paramref name="right"/> operands.
        /// </summary>
        /// <param name="left">The first operand.</param>
        /// <param name="right">The second operand.</param>
        /// <returns>The bitwise logical OR of the <paramref name="left"/> and <paramref name="right"/> operands.</returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        public static EnumInfo<TEnum> operator |(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => (EnumInfo<TEnum, sbyte>)left | (EnumInfo<TEnum, sbyte>)right,
                TypeCode.Int16 => (EnumInfo<TEnum, short>)left | (EnumInfo<TEnum, short>)right,
                TypeCode.Int32 => (EnumInfo<TEnum, int>)left | (EnumInfo<TEnum, int>)right,
                TypeCode.Int64 => (EnumInfo<TEnum, long>)left | (EnumInfo<TEnum, long>)right,
                TypeCode.Byte => (EnumInfo<TEnum, byte>)left | (EnumInfo<TEnum, byte>)right,
                TypeCode.UInt16 => (EnumInfo<TEnum, ushort>)left | (EnumInfo<TEnum, ushort>)right,
                TypeCode.UInt32 => (EnumInfo<TEnum, uint>)left | (EnumInfo<TEnum, uint>)right,
                TypeCode.UInt64 => (EnumInfo<TEnum, ulong>)left | (EnumInfo<TEnum, ulong>)right,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Computes the bitwise logical AND of the <paramref name="left"/> and <paramref name="right"/> operands.
        /// </summary>
        /// <param name="left">The first operand.</param>
        /// <param name="right">The second operand.</param>
        /// <returns>The bitwise logical AND of the <paramref name="left"/> and <paramref name="right"/> operands.</returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        public static EnumInfo<TEnum> operator &(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => (EnumInfo<TEnum, sbyte>)left & (EnumInfo<TEnum, sbyte>)right,
                TypeCode.Int16 => (EnumInfo<TEnum, short>)left & (EnumInfo<TEnum, short>)right,
                TypeCode.Int32 => (EnumInfo<TEnum, int>)left & (EnumInfo<TEnum, int>)right,
                TypeCode.Int64 => (EnumInfo<TEnum, long>)left & (EnumInfo<TEnum, long>)right,
                TypeCode.Byte => (EnumInfo<TEnum, byte>)left & (EnumInfo<TEnum, byte>)right,
                TypeCode.UInt16 => (EnumInfo<TEnum, ushort>)left & (EnumInfo<TEnum, ushort>)right,
                TypeCode.UInt32 => (EnumInfo<TEnum, uint>)left & (EnumInfo<TEnum, uint>)right,
                TypeCode.UInt64 => (EnumInfo<TEnum, ulong>)left & (EnumInfo<TEnum, ulong>)right,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Computes the bitwise logical exclusive OR, also known as the bitwise logical XOR,
        /// of the <paramref name="left"/> and <paramref name="right"/> operands.
        /// </summary>
        /// <param name="left">The first operand.</param>
        /// <param name="right">The second operand.</param>
        /// <returns>
        /// The bitwise logical exclusive OR, also known as the bitwise logical XOR,
        /// of the <paramref name="left"/> and <paramref name="right"/> operands.
        /// </returns>
        public static EnumInfo<TEnum> operator ^(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => (EnumInfo<TEnum, sbyte>)left ^ (EnumInfo<TEnum, sbyte>)right,
                TypeCode.Int16 => (EnumInfo<TEnum, short>)left ^ (EnumInfo<TEnum, short>)right,
                TypeCode.Int32 => (EnumInfo<TEnum, int>)left ^ (EnumInfo<TEnum, int>)right,
                TypeCode.Int64 => (EnumInfo<TEnum, long>)left ^ (EnumInfo<TEnum, long>)right,
                TypeCode.Byte => (EnumInfo<TEnum, byte>)left ^ (EnumInfo<TEnum, byte>)right,
                TypeCode.UInt16 => (EnumInfo<TEnum, ushort>)left ^ (EnumInfo<TEnum, ushort>)right,
                TypeCode.UInt32 => (EnumInfo<TEnum, uint>)left ^ (EnumInfo<TEnum, uint>)right,
                TypeCode.UInt64 => (EnumInfo<TEnum, ulong>)left ^ (EnumInfo<TEnum, ulong>)right,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }
    }
}
