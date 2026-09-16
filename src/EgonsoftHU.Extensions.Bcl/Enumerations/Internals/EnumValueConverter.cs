// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Converters;
using EgonsoftHU.Extensions.Bcl.Exceptions;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal abstract class EnumValueConverter<TEnum, TUnderlying> : IEnumValueConverter<TEnum, TUnderlying>
        where TEnum : struct, Enum
        where TUnderlying : struct, IComparable<TUnderlying>
    {
        private static readonly Type enumType = typeof(TEnum);

        private static readonly Type enumUnderlyingType = typeof(TUnderlying);

        private static readonly ReadOnlyDictionary<Type, Func<Type, Type>> converterFactoriesByUnderlyingType =
            new(
                new Dictionary<Type, Func<Type, Type>>()
                {
                    [typeof(sbyte)] = enumType => typeof(SByteEnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(short)] = enumType => typeof(Int16EnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(int)] = enumType => typeof(Int32EnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(long)] = enumType => typeof(Int64EnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(byte)] = enumType => typeof(ByteEnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(ushort)] = enumType => typeof(UInt16EnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(uint)] = enumType => typeof(UInt32EnumValueConverter<>).MakeGenericType(enumType),
                    [typeof(ulong)] = enumType => typeof(UInt64EnumValueConverter<>).MakeGenericType(enumType),
                }
            );

        internal static IEnumValueConverter<TEnum, TUnderlying> Instance { get; } = CreateInstance();

        public abstract TUnderlying ToUnderlyingType(object value);

        public abstract ulong ToUInt64(TUnderlying underlyingValue);

        public TEnum ToEnumType(ref TUnderlying underlyingValue)
        {
            return Unsafe.As<TUnderlying, TEnum>(ref underlyingValue);
        }

        private static IEnumValueConverter<TEnum, TUnderlying> CreateInstance()
        {
            if (!converterFactoriesByUnderlyingType.TryGetValue(enumUnderlyingType, out Func<Type, Type>? factory))
            {
                throw NotSupportedExceptions.NotSupportedEnumUnderlyingType<TUnderlying>();
            }

            Type concreteType = factory.Invoke(enumType);

            return
                Activator.CreateInstance(concreteType) is IEnumValueConverter<TEnum, TUnderlying> converter
                    ? converter
                    : throw InvalidOperationExceptions.CreateEnumValueConverterInstanceFailed<TEnum, TUnderlying>(concreteType);
        }
    }
}
