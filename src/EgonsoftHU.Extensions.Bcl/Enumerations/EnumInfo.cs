// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    /// <summary>
    /// Provides static factory method to get an instance of the <see cref="EnumInfo{TEnum}"/> type.
    /// </summary>
    public abstract class EnumInfo
    {
        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the value of which equals to the specified <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="value">An enumeration value.</param>
        /// <returns>
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="value"/> is invalid for the <typeparamref name="TEnum"/> type.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// The underlying type of the <typeparamref name="TEnum"/> type must be one of the following types:
        /// <see cref="SByte"/>, <see cref="Int16"/>, <see cref="Int32"/>, <see cref="Int64"/>,
        /// <see cref="Byte"/>, <see cref="UInt16"/>, <see cref="UInt32"/>, <see cref="UInt64"/>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If the <paramref name="value"/> represents more than one constants in the <typeparamref name="TEnum"/> and
        /// a <see cref="FlagsAttribute"/> is not applied to that type.
        /// </exception>
        public static EnumInfo<TEnum> FromValue<TEnum>(TEnum value)
            where TEnum : struct, Enum
        {
            return EnumInfo<TEnum>.FromValue(value);
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that
        /// represents one or more constants in the <typeparamref name="TEnum"/> type
        /// the value of which equals to the specified <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="value">An enumeration value.</param>
        /// <param name="result">
        /// An instance of the <see cref="EnumInfo{TEnum}"/> type that represents the constant(s) in the <typeparamref name="TEnum"/> type.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> was valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool TryFromValue<TEnum>(TEnum value, [NotNullWhen(true)] out EnumInfo<TEnum>? result)
            where TEnum : struct, Enum
        {
            return EnumInfo<TEnum>.TryFromValue(value, out result);
        }
    }
}
