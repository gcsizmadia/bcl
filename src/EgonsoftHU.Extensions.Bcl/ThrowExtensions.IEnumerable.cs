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
    }
}
