// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    public partial class EnumInfo<TEnum> : IComparable<EnumInfo<TEnum>>, IComparable
    {
        /// <inheritdoc/>
        public int CompareTo(object? obj)
        {
            return obj is null
                ? 1
                : obj is EnumInfo<TEnum> enumeration
                    ? CompareTo(enumeration)
                    : throw ArgumentExceptions.ArgumentMustBeOfType<EnumInfo<TEnum>>(obj);
        }

        /// <inheritdoc/>
        public int CompareTo(EnumInfo<TEnum>? other)
        {
            return
                other is null
                    ? 1
                    : Value.CompareTo(other.Value);
        }

        /// <summary>
        /// Indicates whether the <paramref name="left"/> parameter is greater than the <paramref name="right"/> parameter.
        /// </summary>
        /// <param name="left">A value to compare with the <paramref name="right"/> parameter.</param>
        /// <param name="right">A value to compare with the <paramref name="left"/> parameter.</param>
        /// <returns>
        /// <see langword="true"/> if the left-hand operand is greater than the right-hand operand; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator >(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Indicates whether the <paramref name="left"/> parameter is greater than or equal to the <paramref name="right"/> parameter.
        /// </summary>
        /// <param name="left">A value to compare with the <paramref name="right"/> parameter.</param>
        /// <param name="right">A value to compare with the <paramref name="left"/> parameter.</param>
        /// <returns>
        /// <see langword="true"/> if the left-hand operand is greater than or equal to the right-hand operand; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator >=(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Indicates whether the <paramref name="left"/> parameter is less than the <paramref name="right"/> parameter.
        /// </summary>
        /// <param name="left">A value to compare with the <paramref name="right"/> parameter.</param>
        /// <param name="right">A value to compare with the <paramref name="left"/> parameter.</param>
        /// <returns>
        /// <see langword="true"/> if the left-hand operand is less than the right-hand operand; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator <(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Indicates whether the <paramref name="left"/> parameter is less than or equal to the <paramref name="right"/> parameter.
        /// </summary>
        /// <param name="left">A value to compare with the <paramref name="right"/> parameter.</param>
        /// <param name="right">A value to compare with the <paramref name="left"/> parameter.</param>
        /// <returns>
        /// <see langword="true"/> if the left-hand operand is less than or equal to the right-hand operand; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator <=(EnumInfo<TEnum> left, EnumInfo<TEnum> right)
        {
            return left.CompareTo(right) <= 0;
        }
    }
}
