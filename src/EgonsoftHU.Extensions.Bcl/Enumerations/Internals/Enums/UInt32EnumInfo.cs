// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Enums
{
    internal sealed class UInt32EnumInfo<TEnum> : EnumInfo<TEnum, uint>
        where TEnum : struct, Enum
    {
        public UInt32EnumInfo(string name, TEnum value)
            : base(name, value)
        {
        }
    }
}
