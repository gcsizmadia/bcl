// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class Int32Flags : EnumFlags<int>
    {
        public override int Construct(params int[] values)
        {
            int value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override int[] Deconstruct(int value)
        {
            return ResolveCore(value).Select(number => (int)number).ToArray();
        }

        public override bool IsPowerOf2(int value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
