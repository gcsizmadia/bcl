// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class Int16Flags : EnumFlags<short>
    {
        public override short Construct(params short[] values)
        {
            short value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override short[] Deconstruct(short value)
        {
            return ResolveCore(value).Select(number => (short)number).ToArray();
        }

        public override bool IsPowerOf2(short value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
