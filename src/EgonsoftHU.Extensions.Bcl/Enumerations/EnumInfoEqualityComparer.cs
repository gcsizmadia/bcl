// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public sealed class EnumInfoEqualityComparer<TEnum> : EqualityComparer<EnumInfo<TEnum>>
        where TEnum : struct, Enum
    {
        internal static readonly EnumInfoEqualityComparer<TEnum> Instance = new();

        /// <inheritdoc/>
        public override bool Equals(EnumInfo<TEnum>? left, EnumInfo<TEnum>? right)
        {
            return EnumInfo<TEnum>.Equals(left, right);
        }

        /// <inheritdoc/>
        public override int GetHashCode([DisallowNull] EnumInfo<TEnum> obj)
        {
            obj.ThrowIfNull();

            return obj.GetHashCode();
        }
    }
}
