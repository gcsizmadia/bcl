// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    internal partial class EnumInfo<TEnum, TUnderlying> : IEquatable<EnumInfo<TEnum, TUnderlying>>
    {
        private static readonly EqualityComparer<TUnderlying> underlyingEqualityComparer = EqualityComparer<TUnderlying>.Default;

        /// <summary>
        /// Indicates whether the <paramref name="left"/> parameter is equal to the <paramref name="right"/> parameter.
        /// </summary>
        /// <param name="left">A value to compare with the <paramref name="right"/> parameter.</param>
        /// <param name="right">A value to compare with the <paramref name="left"/> parameter.</param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="left"/> parameter is equal to the <paramref name="right"/> parameter;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(EnumInfo<TEnum, TUnderlying>? left, EnumInfo<TEnum, TUnderlying>? right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Indicates whether the <paramref name="left"/> parameter is not equal to the <paramref name="right"/> parameter.
        /// </summary>
        /// <param name="left">A value to compare with the <paramref name="right"/> parameter.</param>
        /// <param name="right">A value to compare with the <paramref name="left"/> parameter.</param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="left"/> parameter is not equal to the <paramref name="right"/> parameter;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(EnumInfo<TEnum, TUnderlying>? left, EnumInfo<TEnum, TUnderlying>? right)
        {
            return !Equals(left, right);
        }

        public static bool Equals(EnumInfo<TEnum, TUnderlying>? left, EnumInfo<TEnum, TUnderlying>? right)
        {
            return left is null ? right is null : ReferenceEquals(left, right) || left.Equals(right);
        }

        /// <inheritdoc/>
        public bool Equals([NotNullWhen(true)] EnumInfo<TEnum, TUnderlying>? other)
        {
            return
                other is not null
                &&
                (
                    ReferenceEquals(this, other)
                    ||
                    underlyingEqualityComparer.Equals(UnderlyingValue, other.UnderlyingValue)
                );
        }

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return Equals(obj as EnumInfo<TEnum, TUnderlying>);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }
    }
}
