// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    public partial class EnumInfo<TEnum>
    {
        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// that have the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of one or more constants in the <typeparamref name="TEnum"/> type.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If no constant found in the <typeparamref name="TEnum"/> type that has a name specified by the <paramref name="name"/> parameter.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="name"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type.
        /// </exception>
        public static EnumInfo<TEnum> FromName(string name)
        {
            return
                EnumTypeCode switch
                {
                    TypeCode.SByte => EnumInfo<TEnum, sbyte>.FromName(name),
                    TypeCode.Int16 => EnumInfo<TEnum, short>.FromName(name),
                    TypeCode.Int32 => EnumInfo<TEnum, int>.FromName(name),
                    TypeCode.Int64 => EnumInfo<TEnum, long>.FromName(name),
                    TypeCode.Byte => EnumInfo<TEnum, byte>.FromName(name),
                    TypeCode.UInt16 => EnumInfo<TEnum, ushort>.FromName(name),
                    TypeCode.UInt32 => EnumInfo<TEnum, uint>.FromName(name),
                    TypeCode.UInt64 => EnumInfo<TEnum, ulong>.FromName(name),
                    _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
                };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the value of which equals to the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">An enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="value"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="value"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type.
        /// </exception>
        public static EnumInfo<TEnum> FromValue(TEnum value)
        {
            return
                EnumTypeCode switch
                {
                    TypeCode.SByte => EnumInfo<TEnum, sbyte>.FromValue(value),
                    TypeCode.Int16 => EnumInfo<TEnum, short>.FromValue(value),
                    TypeCode.Int32 => EnumInfo<TEnum, int>.FromValue(value),
                    TypeCode.Int64 => EnumInfo<TEnum, long>.FromValue(value),
                    TypeCode.Byte => EnumInfo<TEnum, byte>.FromValue(value),
                    TypeCode.UInt16 => EnumInfo<TEnum, ushort>.FromValue(value),
                    TypeCode.UInt32 => EnumInfo<TEnum, uint>.FromValue(value),
                    TypeCode.UInt64 => EnumInfo<TEnum, ulong>.FromValue(value),
                    _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
                };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(sbyte underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => EnumInfo<TEnum, sbyte>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int16 => EnumInfo<TEnum, short>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int32 => EnumInfo<TEnum, int>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => throw ArgumentExceptions.ArgumentMustBeOfType<ushort>(underlyingValue),
                TypeCode.UInt32 => throw ArgumentExceptions.ArgumentMustBeOfType<uint>(underlyingValue),
                TypeCode.UInt64 => throw ArgumentExceptions.ArgumentMustBeOfType<ulong>(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(short underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => EnumInfo<TEnum, short>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int32 => EnumInfo<TEnum, int>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => throw ArgumentExceptions.ArgumentMustBeOfType<ushort>(underlyingValue),
                TypeCode.UInt32 => throw ArgumentExceptions.ArgumentMustBeOfType<uint>(underlyingValue),
                TypeCode.UInt64 => throw ArgumentExceptions.ArgumentMustBeOfType<ulong>(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(int underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => throw ArgumentExceptions.ArgumentMustBeOfType<short>(underlyingValue),
                TypeCode.Int32 => EnumInfo<TEnum, int>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => throw ArgumentExceptions.ArgumentMustBeOfType<ushort>(underlyingValue),
                TypeCode.UInt32 => throw ArgumentExceptions.ArgumentMustBeOfType<uint>(underlyingValue),
                TypeCode.UInt64 => throw ArgumentExceptions.ArgumentMustBeOfType<ulong>(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(long underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => throw ArgumentExceptions.ArgumentMustBeOfType<short>(underlyingValue),
                TypeCode.Int32 => throw ArgumentExceptions.ArgumentMustBeOfType<int>(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => throw ArgumentExceptions.ArgumentMustBeOfType<ushort>(underlyingValue),
                TypeCode.UInt32 => throw ArgumentExceptions.ArgumentMustBeOfType<uint>(underlyingValue),
                TypeCode.UInt64 => throw ArgumentExceptions.ArgumentMustBeOfType<ulong>(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(byte underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => EnumInfo<TEnum, short>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int32 => EnumInfo<TEnum, int>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => EnumInfo<TEnum, byte>.FromUnderlyingValue(underlyingValue),
                TypeCode.UInt16 => EnumInfo<TEnum, ushort>.FromUnderlyingValue(underlyingValue),
                TypeCode.UInt32 => EnumInfo<TEnum, uint>.FromUnderlyingValue(underlyingValue),
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.FromUnderlyingValue(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(ushort underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => throw ArgumentExceptions.ArgumentMustBeOfType<short>(underlyingValue),
                TypeCode.Int32 => EnumInfo<TEnum, int>.FromUnderlyingValue(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => EnumInfo<TEnum, ushort>.FromUnderlyingValue(underlyingValue),
                TypeCode.UInt32 => EnumInfo<TEnum, uint>.FromUnderlyingValue(underlyingValue),
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.FromUnderlyingValue(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(uint underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => throw ArgumentExceptions.ArgumentMustBeOfType<short>(underlyingValue),
                TypeCode.Int32 => throw ArgumentExceptions.ArgumentMustBeOfType<int>(underlyingValue),
                TypeCode.Int64 => EnumInfo<TEnum, long>.FromUnderlyingValue(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => throw ArgumentExceptions.ArgumentMustBeOfType<ushort>(underlyingValue),
                TypeCode.UInt32 => EnumInfo<TEnum, uint>.FromUnderlyingValue(underlyingValue),
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.FromUnderlyingValue(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="underlyingValue"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="underlyingValue"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type
        /// </exception>
        public static EnumInfo<TEnum> FromUnderlyingValue(ulong underlyingValue)
        {
            return EnumTypeCode switch
            {
                TypeCode.SByte => throw ArgumentExceptions.ArgumentMustBeOfType<sbyte>(underlyingValue),
                TypeCode.Int16 => throw ArgumentExceptions.ArgumentMustBeOfType<short>(underlyingValue),
                TypeCode.Int32 => throw ArgumentExceptions.ArgumentMustBeOfType<int>(underlyingValue),
                TypeCode.Int64 => throw ArgumentExceptions.ArgumentMustBeOfType<long>(underlyingValue),
                TypeCode.Byte => throw ArgumentExceptions.ArgumentMustBeOfType<byte>(underlyingValue),
                TypeCode.UInt16 => throw ArgumentExceptions.ArgumentMustBeOfType<ushort>(underlyingValue),
                TypeCode.UInt32 => throw ArgumentExceptions.ArgumentMustBeOfType<uint>(underlyingValue),
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.FromUnderlyingValue(underlyingValue),
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// that have the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of one or more constants in the <typeparamref name="TEnum"/> type.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="name"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromName(string name, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.SByte:
                {
                    if (EnumInfo<TEnum, sbyte>.TryFromName(name, out EnumInfo<TEnum, sbyte>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int16:
                {
                    if (EnumInfo<TEnum, short>.TryFromName(name, out EnumInfo<TEnum, short>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromName(name, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromName(name, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Byte:
                {
                    if (EnumInfo<TEnum, byte>.TryFromName(name, out EnumInfo<TEnum, byte>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt16:
                {
                    if (EnumInfo<TEnum, ushort>.TryFromName(name, out EnumInfo<TEnum, ushort>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt32:
                {
                    if (EnumInfo<TEnum, uint>.TryFromName(name, out EnumInfo<TEnum, uint>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt64:
                {
                    if (EnumInfo<TEnum, ulong>.TryFromName(name, out EnumInfo<TEnum, ulong>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the value of which equals to the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">An enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromValue(TEnum value, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.SByte:
                {
                    if (EnumInfo<TEnum, sbyte>.TryFromValue(value, out EnumInfo<TEnum, sbyte>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int16:
                {
                    if (EnumInfo<TEnum, short>.TryFromValue(value, out EnumInfo<TEnum, short>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromValue(value, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromValue(value, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Byte:
                {
                    if (EnumInfo<TEnum, byte>.TryFromValue(value, out EnumInfo<TEnum, byte>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt16:
                {
                    if (EnumInfo<TEnum, ushort>.TryFromValue(value, out EnumInfo<TEnum, ushort>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt32:
                {
                    if (EnumInfo<TEnum, uint>.TryFromValue(value, out EnumInfo<TEnum, uint>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt64:
                {
                    if (EnumInfo<TEnum, ulong>.TryFromValue(value, out EnumInfo<TEnum, ulong>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(sbyte underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.SByte:
                {
                    if (EnumInfo<TEnum, sbyte>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, sbyte>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int16:
                {
                    if (EnumInfo<TEnum, short>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, short>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(short underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.Int16:
                {
                    if (EnumInfo<TEnum, short>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, short>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(int underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(long underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(byte underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.Int16:
                {
                    if (EnumInfo<TEnum, short>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, short>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Byte:
                {
                    if (EnumInfo<TEnum, byte>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, byte>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt16:
                {
                    if (EnumInfo<TEnum, ushort>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, ushort>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt32:
                {
                    if (EnumInfo<TEnum, uint>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, uint>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt64:
                {
                    if (EnumInfo<TEnum, ulong>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, ulong>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(ushort underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.Int32:
                {
                    if (EnumInfo<TEnum, int>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, int>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt16:
                {
                    if (EnumInfo<TEnum, ushort>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, ushort>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt32:
                {
                    if (EnumInfo<TEnum, uint>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, uint>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt64:
                {
                    if (EnumInfo<TEnum, ulong>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, ulong>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(uint underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.Int64:
                {
                    if (EnumInfo<TEnum, long>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, long>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt32:
                {
                    if (EnumInfo<TEnum, uint>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, uint>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                case TypeCode.UInt64:
                {
                    if (EnumInfo<TEnum, ulong>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, ulong>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the underlying value of which equals to the specified <paramref name="underlyingValue"/>.
        /// </summary>
        /// <param name="underlyingValue">The underlying value of an enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="underlyingValue"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromUnderlyingValue(ulong underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
        {
            result = default;

            switch (EnumTypeCode)
            {
                case TypeCode.UInt64:
                {
                    if (EnumInfo<TEnum, ulong>.TryFromUnderlyingValue(underlyingValue, out EnumInfo<TEnum, ulong>? derivedResult))
                    {
                        result = derivedResult;
                        return true;
                    }

                    return false;
                }

                default:
                    return false;
            }
        }
    }
}
