// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal interface IEnumValueConverter<TEnum, TUnderlying>
        where TEnum : struct, Enum
        where TUnderlying : struct, IConvertible, IComparable<TUnderlying>
    {
        TEnum ToEnumType(TUnderlying underlyingValue);

        ulong ToUInt64(TUnderlying underlyingValue);

        TUnderlying ToUnderlyingType(TEnum value);
    }
}
