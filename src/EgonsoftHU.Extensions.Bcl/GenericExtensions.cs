// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains generic extension methods that are available for any type.
    /// </summary>
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Determines whether a specified <paramref name="value"/> is the default value of its <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// <see langword="true"/> for value types if default(<typeparamref name="T"/>) equals to <paramref name="value"/>;
        /// <see langword="true"/> for reference types if <paramref name="value"/> is <see langword="null"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsDefaultValue<T>([NotNullWhen(false)] this T value)
        {
            return EqualityComparer<T?>.Default.Equals(default, value);
        }

        /// <summary>
        /// Determines whether a specified <paramref name="value"/> is the default value of its <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// <see langword="true"/> for value types if default(<typeparamref name="T"/>) equals to <paramref name="value"/>;
        /// <see langword="true"/> for reference types if <paramref name="value"/> is <see langword="null"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsDefaultValue<T>([NotNullWhen(false)] this T? value) where T : struct
        {
            return value is null;
        }

        private static bool IsNotNull<T>([NotNullWhen(true)] this T value)
            where T : class?
        {
            return value is not null;
        }
    }
}
