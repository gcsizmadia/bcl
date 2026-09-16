// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

using static EgonsoftHU.Extensions.Bcl.ErrorMessageConfiguration;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods to throw exceptions.
    /// </summary>
    public static partial class ThrowExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="param"/> is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="param"/>.</typeparam>
        /// <param name="param">The parameter to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>([NotNull] this T? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(param, paramName);
#else
            if (param is null)
            {
                ThrowArgumentNullException(paramName);
            }
#endif
        }

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

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if <paramref name="param"/> is <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="param">The parameter to validate as non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentException"><paramref name="param"/> is <see cref="Guid.Empty"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfEmptyGuid(this Guid param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            if (Guid.Empty == param)
            {
                ThrowArgumentException(paramName, param, Argument_EmptyGuid);
            }
        }

        /// <summary>
        /// Throws an exception if <paramref name="param"/> is <see langword="null"/> or the sequence contains no element.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="param">The parameter to validate.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="param"/> sequence contains no element.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNullOrEmpty<T>([NotNull] this IEnumerable<T>? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            param.ThrowIfNull(paramName);

            if (!param.Any())
            {
                ThrowArgumentException(paramName, param, Argument_EmptyEnumerable);
            }
        }

#if !NET6_0_OR_GREATER
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowArgumentNullException(string? paramName)
        {
            throw new ArgumentNullException(paramName);
        }
#endif

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowArgumentException<T>(string? paramName, T value, Func<string?, T, string> messageSelector)
        {
            throw new ArgumentException(messageSelector.Invoke(paramName, value), paramName);
        }
    }
}
