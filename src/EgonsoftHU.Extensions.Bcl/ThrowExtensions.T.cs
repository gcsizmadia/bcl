// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

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
        public static void ThrowIfNull<T>([NotNull] this T param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
            where T : class?
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(param, paramName);
#else
            if (param is null)
            {
                ThrowHelper.ThrowArgumentNullException(paramName);
            }
#endif
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="param"/> is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="param"/>.</typeparam>
        /// <param name="param">The parameter to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>([NotNull] this T? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
            where T : struct
        {
            if (param is null)
            {
                ThrowHelper.ThrowArgumentNullException(paramName);
            }
        }
    }
}
