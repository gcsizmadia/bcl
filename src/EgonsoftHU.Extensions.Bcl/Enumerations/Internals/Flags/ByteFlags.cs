// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags
{
    internal sealed class ByteFlags : EnumFlags<byte>
    {
        public override byte Construct(params byte[] values)
        {
            byte value = default;

            for (int i = 0; i < values.Length; i++)
            {
                value |= values[i];
            }

            return value;
        }

        public override byte[] Deconstruct(byte value)
        {
            return ResolveCore(value).Select(number => (byte)number).ToArray();
        }

        public override bool IsPowerOf2(byte value)
        {
            return IsPowerOf2Core(value);
        }
    }
}
