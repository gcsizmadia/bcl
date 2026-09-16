// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Runtime.CompilerServices;

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal sealed class EnumValueConverter<TEnum, TUnderlying> : IEnumValueConverter<TEnum, TUnderlying>
        where TEnum : struct, Enum
        where TUnderlying : struct, IConvertible, IComparable<TUnderlying>
    {
        private static readonly TypeCode[] SupportedTypeCodes =
#if LANGVERSION12_0_OR_GREATER
        [
#else
        new[] {
#endif
            TypeCode.SByte,
            TypeCode.Byte,
            TypeCode.Int16,
            TypeCode.UInt16,
            TypeCode.Int32,
            TypeCode.UInt32,
            TypeCode.Int64,
            TypeCode.UInt64
#if LANGVERSION12_0_OR_GREATER
        ]
#else
        }
#endif
        ;

        private EnumValueConverter()
        {
        }

        internal static IEnumValueConverter<TEnum, TUnderlying> Instance { get; } = CreateInstance();

        public TEnum ToEnumType(TUnderlying underlyingValue)
        {
            TUnderlying source = underlyingValue;

            return Unsafe.As<TUnderlying, TEnum>(ref source);
        }

        public TUnderlying ToUnderlyingType(TEnum value)
        {
            TEnum source = value;

            return Unsafe.As<TEnum, TUnderlying>(ref source);
        }

        public ulong ToUInt64(TUnderlying underlyingValue)
        {
            return ((IConvertible)underlyingValue).ToUInt64(null);
        }

        private static EnumValueConverter<TEnum, TUnderlying> CreateInstance()
        {
            Type underlyingType = typeof(TUnderlying);
            TypeCode underlyingTypeCode = Type.GetTypeCode(underlyingType);

            if (underlyingType != Enum.GetUnderlyingType(typeof(TEnum)))
            {
                throw InvalidOperationExceptions.CreateEnumValueConverterInstanceFailed<TEnum, TUnderlying>(
                    typeof(EnumValueConverter<TEnum, TUnderlying>)
                );
            }

            if (underlyingTypeCode.IsNotIn(SupportedTypeCodes))
            {
                throw NotSupportedExceptions.NotSupportedEnumUnderlyingType<TUnderlying>();
            }

            return new EnumValueConverter<TEnum, TUnderlying>();
        }
    }
}
