// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class Int64Flags : EnumFlags<long>
    {
        public override long Construct(params long[] values)
        {
            long value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override long[] Deconstruct(long value)
        {
            return ResolveCore(value).Select(number => (long)number).ToArray();
        }

        public override bool IsPowerOf2(long value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
