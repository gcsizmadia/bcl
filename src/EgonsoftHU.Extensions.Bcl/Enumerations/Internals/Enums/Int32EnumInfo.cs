// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Enums
{
    internal sealed class Int32EnumInfo<TEnum> : EnumInfo<TEnum, int>
        where TEnum : struct, Enum
    {
        public Int32EnumInfo(string name, TEnum value)
            : base(name, value)
        {
        }
    }
}
