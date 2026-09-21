// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#if !NET8_0_OR_GREATER
using static EgonsoftHU.Extensions.Bcl.ErrorMessageConfiguration;
#endif

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods to throw exceptions.
    /// </summary>
    public static partial class ThrowExtensions
    {
        /// <summary>
        /// Throws an exception if <paramref name="param"/> is <see langword="null"/> or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="param">The parameter to validate as non-null and non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="param"/> is <see cref="String.Empty"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNullOrEmpty([NotNull] this string? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrEmpty(param, paramName);
#else
            param.ThrowIfNull(paramName);

            if (param.Length == 0)
            {
                ThrowArgumentException(paramName, param, Argument_EmptyString);
            }
#endif
        }

        /// <summary>
        /// Throws an exception if <paramref name="param"/> is <see langword="null"/>, <see cref="String.Empty"/> or consists only of white-space characters.
        /// </summary>
        /// <param name="param">The parameter to validate.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="param"/> is <see cref="String.Empty"/> or consists only of white-space characters.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNullOrWhiteSpace([NotNull] this string? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentException.ThrowIfNullOrWhiteSpace(param, paramName);
#else
            param.ThrowIfNull(paramName);

            if (param.IsNullOrWhiteSpace())
            {
                ThrowArgumentException(paramName, param, Argument_EmptyOrWhiteSpaceString);
            }
#endif
        }
    }
}
