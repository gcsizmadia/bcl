// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class UInt64Flags : EnumFlags<ulong>
    {
        public override ulong Construct(params ulong[] values)
        {
            ulong value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override ulong[] Deconstruct(ulong value)
        {
            return ResolveCore(value).Select(number => (ulong)number).ToArray();
        }

        public override bool IsPowerOf2(ulong value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
