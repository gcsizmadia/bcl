// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;

using EgonsoftHU.Extensions.Bcl.Constants;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="String"/> type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is <see langword="null"/> or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is <see langword="null"/> or <see cref="String.Empty"/>; otherwise, <see langword="false"/>.</returns>
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether a specified string is <see langword="null"/>, <see cref="String.Empty"/>, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> is <see langword="null"/>, <see cref="String.Empty"/>, or if <paramref name="value"/> consists exclusively of white-space characters.</returns>
        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Gets the specified default value if the specified string is <see langword="null"/> or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <param name="defaultValue">The default value if <paramref name="value"/> is <see langword="null"/> or <see cref="String.Empty"/>.</param>
        /// <returns><paramref name="defaultValue"/> if <paramref name="value"/> is <see langword="null"/> or <see cref="String.Empty"/>; otherwise, <paramref name="value"/> itself.</returns>
        [return: NotNullIfNotNull(nameof(defaultValue))]
        public static string? DefaultIfNullOrEmpty(this string? value, string? defaultValue = null)
        {
            return value.IsNullOrEmpty() ? defaultValue : value;
        }

        /// <summary>
        /// Gets the specified default value if the specified string is <see langword="null"/>, <see cref="String.Empty"/>, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <param name="defaultValue">The default value if <paramref name="value"/> is <see langword="null"/>, <see cref="String.Empty"/>, or consists only of white-space characters.</param>
        /// <returns><paramref name="defaultValue"/> if <paramref name="value"/> is <see langword="null"/>, <see cref="String.Empty"/>, or if <paramref name="value"/> consists exclusively of white-space characters; otherwise, <paramref name="value"/> itself.</returns>
        [return: NotNullIfNotNull(nameof(defaultValue))]
        public static string? DefaultIfNullOrWhiteSpace(this string? value, string? defaultValue = null)
        {
            return value.IsNullOrWhiteSpace() ? defaultValue : value;
        }

        /// <summary>
        /// Ensures that the specified <paramref name="value"/> ends with a slash '<c>/</c>' character.
        /// </summary>
        /// <param name="value">The value that needs to end with a slash '<c>/</c>' character.</param>
        /// <returns><paramref name="value"/> itself if it ends with a slash '<c>/</c>' character; otherwise, appends a slash '<c>/</c>' character at the end of it.</returns>
        public static string EnsureTrailingSlash(this string? value)
        {
            if (value.IsNullOrEmpty())
            {
                return Strings.Slash;
            }

#if NETFRAMEWORK || NETSTANDARD
            return value.EndsWith(Strings.Slash) ? value : $"{value}{Strings.Slash}";
#else
            return value.EndsWith(Chars.Slash) ? value : $"{value}{Chars.Slash}";
#endif
        }

        /// <summary>
        /// Ensures that the specified <paramref name="value"/> does not end with a slash '<c>/</c>' character.
        /// </summary>
        /// <param name="value">The value that must not end with a slash '<c>/</c>' character.</param>
        /// <returns><paramref name="value"/> itself if it does not end with a slash '<c>/</c>' character; otherwise, trims the slash '<c>/</c>' character from the end of it.</returns>
        public static string? EnsureNoTrailingSlash(this string? value)
        {
            return value?.TrimEnd(Chars.Slash);
        }
    }
}
