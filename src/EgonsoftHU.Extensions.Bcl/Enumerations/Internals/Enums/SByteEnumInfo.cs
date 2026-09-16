// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Enums
{
    internal sealed class SByteEnumInfo<TEnum> : EnumInfo<TEnum, sbyte>
        where TEnum : struct, Enum
    {
        public SByteEnumInfo(string name, TEnum value)
            : base(name, value)
        {
        }
    }
}
