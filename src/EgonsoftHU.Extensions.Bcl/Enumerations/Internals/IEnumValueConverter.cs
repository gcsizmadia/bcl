// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal interface IEnumValueConverter<TEnum, TUnderlying>
        where TEnum : struct, Enum
        where TUnderlying : struct, IComparable<TUnderlying>
    {
        TUnderlying ToUnderlyingType(object value);

        ulong ToUInt64(TUnderlying underlyingValue);

        TEnum ToEnumType(ref TUnderlying underlyingValue);
    }
}
