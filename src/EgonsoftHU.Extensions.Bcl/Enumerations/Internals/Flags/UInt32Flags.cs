// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class UInt32Flags : EnumFlags<uint>
    {
        public override uint Construct(params uint[] values)
        {
            uint value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override uint[] Deconstruct(uint value)
        {
            return ResolveCore(value).Select(number => (uint)number).ToArray();
        }

        public override bool IsPowerOf2(uint value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
