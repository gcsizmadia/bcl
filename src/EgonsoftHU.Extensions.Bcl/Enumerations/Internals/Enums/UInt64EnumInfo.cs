// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Enums
{
    internal sealed class UInt64EnumInfo<TEnum> : EnumInfo<TEnum, ulong>
        where TEnum : struct, Enum
    {
        public UInt64EnumInfo(string name, TEnum value)
            : base(name, value)
        {
        }
    }
}
