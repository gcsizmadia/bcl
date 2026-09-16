// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class UInt16Flags : EnumFlags<ushort>
    {
        public override ushort Construct(params ushort[] values)
        {
            ushort value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override ushort[] Deconstruct(ushort value)
        {
            return ResolveCore(value).Select(number => (ushort)number).ToArray();
        }

        public override bool IsPowerOf2(ushort value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
