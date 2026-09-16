// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if LANGVERSION12_0_OR_GREATER
#else
using System;
#endif
using System.Linq;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    internal partial class EnumInfo<TEnum, TUnderlying>
    {
        public static EnumInfo<TEnum, TUnderlying> operator ~(EnumInfo<TEnum, TUnderlying> value)
        {
            TUnderlying[] currentBits = GetBits(value);
            TUnderlying[] resultBits = bits.Except(currentBits).ToArray();

            return CreateInstance(resultBits);
        }

        public static EnumInfo<TEnum, TUnderlying> operator |(EnumInfo<TEnum, TUnderlying> left, EnumInfo<TEnum, TUnderlying> right)
        {
            TUnderlying bitwiseOrValue =
                flagCalculator.Construct(
#if LANGVERSION12_0_OR_GREATER
                    [.. GetBits(left), .. GetBits(right)]
#else
                    GetBits(left).Concat(GetBits(right)).ToArray()
#endif
                );

            TUnderlying[] resultBits = flagCalculator.Deconstruct(bitwiseOrValue);

            return CreateInstance(resultBits);
        }

        public static EnumInfo<TEnum, TUnderlying> operator &(EnumInfo<TEnum, TUnderlying> left, EnumInfo<TEnum, TUnderlying> right)
        {
            TUnderlying[] leftBits = GetBits(left);
            TUnderlying[] rightBits = GetBits(right);

            TUnderlying[] resultBits = leftBits.Intersect(rightBits).ToArray();

            return CreateInstance(resultBits);
        }

        public static EnumInfo<TEnum, TUnderlying> operator ^(EnumInfo<TEnum, TUnderlying> left, EnumInfo<TEnum, TUnderlying> right)
        {
            TUnderlying[] leftBits = GetBits(left);
            TUnderlying[] rightBits = GetBits(right);

            TUnderlying[] union = leftBits.Union(rightBits).ToArray();
            TUnderlying[] intersect = leftBits.Intersect(rightBits).ToArray();

            TUnderlying[] resultBits = union.Except(intersect).ToArray();

            return CreateInstance(resultBits);
        }

        private static TUnderlying[] GetBits(EnumInfo<TEnum, TUnderlying>? enumeration)
        {
            return
                enumeration is null
#if LANGVERSION12_0_OR_GREATER
                    ? []
#else
                    ? Array.Empty<TUnderlying>()
#endif
                    : flagCalculator.Deconstruct(enumeration.UnderlyingValue);
        }
    }
}
