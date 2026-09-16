// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Enums
{
    internal sealed class Int16EnumInfo<TEnum> : EnumInfo<TEnum, short>
        where TEnum : struct, Enum
    {
        public Int16EnumInfo(string name, TEnum value)
            : base(name, value)
        {
        }
    }
}
