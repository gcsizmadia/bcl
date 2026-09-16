// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class SByteFlags : EnumFlags<sbyte>
    {
        public override sbyte Construct(params sbyte[] values)
        {
            sbyte value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override sbyte[] Deconstruct(sbyte value)
        {
            return ResolveCore(value).Select(number => (sbyte)number).ToArray();
        }

        public override bool IsPowerOf2(sbyte value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
