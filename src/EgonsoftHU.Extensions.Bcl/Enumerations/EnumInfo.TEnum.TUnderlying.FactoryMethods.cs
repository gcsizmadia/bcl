// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Diagnostics.CodeAnalysis;

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    internal partial class EnumInfo<TEnum, TUnderlying>
    {
        public static new EnumInfo<TEnum, TUnderlying> FromName(string name)
        {
            return
                TryGetNames(name, throwOnFailure: true, out string[]? names)
                &&
                TryCreateInstance(name, throwOnFailure: true, out EnumInfo<TEnum, TUnderlying>? result, GetUnderlyingValuesFromNames(names))
                    ? result
                    : throw ArgumentExceptions.EnumMemberNotFound<TEnum, string>(name);
        }

        public static new EnumInfo<TEnum, TUnderlying> FromValue(TEnum value)
        {
            return
                TryFromUnderlyingValueCore(
                    value,
                    Converter.ToUnderlyingType(value),
                    throwOnFailure: true,
                    out EnumInfo<TEnum, TUnderlying>? result
                )
                    ? result
                    : throw ArgumentExceptions.EnumMemberNotFound<TEnum, TEnum>(value);
        }

        public static EnumInfo<TEnum, TUnderlying> FromUnderlyingValue(TUnderlying underlyingValue)
        {
            return
                TryFromUnderlyingValueCore(
                    underlyingValue,
                    underlyingValue,
                    throwOnFailure: true,
                    out EnumInfo<TEnum, TUnderlying>? result
                )
                    ? result
                    : throw ArgumentExceptions.EnumMemberNotFound<TEnum, TUnderlying>(underlyingValue);
        }

        public static bool TryFromName(string name, [NotNullWhen(true)] out EnumInfo<TEnum, TUnderlying>? result)
        {
            result = default;

            return
                TryGetNames(name, throwOnFailure: false, out string[]? names)
                &&
                TryCreateInstance(name, throwOnFailure: false, out result, GetUnderlyingValuesFromNames(names));
        }

        public static bool TryFromValue(TEnum value, [NotNullWhen(true)] out EnumInfo<TEnum, TUnderlying>? result)
        {
            return
                TryFromUnderlyingValueCore(
                    value,
                    Converter.ToUnderlyingType(value),
                    throwOnFailure: false,
                    out result
                );
        }

        public static bool TryFromUnderlyingValue(TUnderlying underlyingValue, [NotNullWhen(true)] out EnumInfo<TEnum, TUnderlying>? result)
        {
            return
                TryFromUnderlyingValueCore(
                    underlyingValue,
                    underlyingValue,
                    throwOnFailure: false,
                    out result
                );
        }
    }
}
