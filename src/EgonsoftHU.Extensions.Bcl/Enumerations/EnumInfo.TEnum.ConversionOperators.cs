// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    public partial class EnumInfo<TEnum>
    {
        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that represents the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">An enum value.</param>
        /// <returns>
        /// The value returned by calling the <see cref="FromValue(TEnum)"/> method with the <paramref name="value"/> parameter.
        /// </returns>
        public static implicit operator EnumInfo<TEnum>(TEnum value)
        {
            return FromValue(value);
        }

        /// <summary>
        /// Defines an implicit conversion of an instance of the <see cref="EnumInfo{TEnum}"/> type to its underlying enum value.
        /// </summary>
        /// <param name="value">An enum member represented by an instance of the <see cref="EnumInfo{TEnum}"/> type.</param>
        /// <returns>
        /// The value of the <see cref="Value"/> property for the <paramref name="value"/> parameter if it is not <see langword="null"/>;
        /// otherwise, the default value of the <typeparamref name="TEnum"/> enum type.
        /// </returns>
        public static implicit operator TEnum(EnumInfo<TEnum>? value)
        {
            return value?.Value ?? Default.Value;
        }
    }
}
