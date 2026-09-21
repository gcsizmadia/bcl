// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
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
        /// Throws <see cref="ArgumentException"/> if <paramref name="param"/> is <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="param">The parameter to validate as non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentException"><paramref name="param"/> is <see cref="Guid.Empty"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#pragma warning disable S1133
        [Obsolete("Use ThrowIfEmpty() extension method instead.")]
#pragma warning restore S1133
        public static void ThrowIfEmptyGuid(this Guid param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            if (Guid.Empty == param)
            {
                ThrowArgumentException(paramName, param, Argument_EmptyGuid);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if <paramref name="param"/> is <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="param">The parameter to validate as non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentException"><paramref name="param"/> is <see cref="Guid.Empty"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfEmpty(this Guid param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            if (Guid.Empty == param)
            {
                ThrowArgumentException(paramName, param, Argument_EmptyGuid);
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if <paramref name="param"/> is <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="param">The parameter to validate as non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="param"/> corresponds.</param>
        /// <exception cref="ArgumentException"><paramref name="param"/> is <see cref="Guid.Empty"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNullOrEmpty(this Guid? param, [CallerArgumentExpression(nameof(param))] string? paramName = null)
        {
            param.ThrowIfNull(paramName);

            if (Guid.Empty == param)
            {
                ThrowArgumentException(paramName, param.Value, Argument_EmptyGuid);
            }
        }
    }
}
