// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
#if !NET8_0_OR_GREATER
using System.Collections.Generic;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using static EgonsoftHU.Extensions.Bcl.ErrorMessageConfiguration;

namespace EgonsoftHU.Extensions.Bcl
{
    public partial class ThrowExtensions
    {
        #region ThrowIfZero

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this byte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this short value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this int value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this long value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this sbyte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this ushort value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this uint value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this ulong value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

#if NET5_0_OR_GREATER
        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this Half value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }
#endif

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this float value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this double value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is zero.</summary>
        /// <param name="value">The argument to validate as non-zero.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfZero(this decimal value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfZero(value, paramName);
#else
            if (value.IsZero())
            {
                ThrowZero(paramName, value);
            }
#endif
        }

        #endregion

        #region ThrowIfNegative

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this byte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this short value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this int value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this long value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this sbyte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this ushort value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this uint value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this ulong value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

#if NET5_0_OR_GREATER
        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this Half value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }
#endif

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this float value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this double value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.</summary>
        /// <param name="value">The argument to validate as non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegative(this decimal value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);
#else
            if (value.IsNegative())
            {
                ThrowNegative(paramName, value);
            }
#endif
        }

        #endregion

        #region ThrowIfNegativeOrZero

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this byte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this short value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this int value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this long value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this sbyte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this ushort value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this uint value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this ulong value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

#if NET5_0_OR_GREATER
        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this Half value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }
#endif

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this float value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this double value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-negative.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNegativeOrZero(this decimal value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);
#else
            if (value.IsNegativeOrZero())
            {
                ThrowNegativeOrZero(paramName, value);
            }
#endif
        }

        #endregion

        #region ThrowIfPositive

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this byte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this short value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this int value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this long value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this sbyte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this ushort value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this uint value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this ulong value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

#if NET5_0_OR_GREATER
        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this Half value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }
#endif

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this float value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this double value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive.</summary>
        /// <param name="value">The argument to validate as non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositive(this decimal value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositive())
            {
                ThrowPositive(paramName, value);
            }
        }

        #endregion

        #region ThrowIfPositiveOrZero

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this byte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this short value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this int value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this long value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this sbyte value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this ushort value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this uint value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this ulong value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

#if NET5_0_OR_GREATER
        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this Half value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }
#endif

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this float value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this double value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is positive or zero.</summary>
        /// <param name="value">The argument to validate as non-zero and non-positive.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfPositiveOrZero(this decimal value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value.IsPositiveOrZero())
            {
                ThrowPositiveOrZero(paramName, value);
            }
        }

        #endregion

        #region ThrowIfGreaterThan

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is greater than <paramref name="other"/>.</summary>
        /// <param name="value">The argument to validate as less than or equal to <paramref name="other"/>.</param>
        /// <param name="other">The value to compare with <paramref name="value"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        /// <typeparam name="T">A type that implements <seealso cref="IComparable{T}"/> interface.</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfGreaterThan<T>(this T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, other, paramName);
#else
            if (value.CompareTo(other) > 0)
            {
                ThrowGreater(paramName, value, other);
            }
#endif
        }

        #endregion

        #region ThrowIfGreaterThanOrEqualTo

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is greater than or equal to <paramref name="other"/>.</summary>
        /// <param name="value">The argument to validate as less than <paramref name="other"/>.</param>
        /// <param name="other">The value to compare with <paramref name="value"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        /// <typeparam name="T">A type that implements <seealso cref="IComparable{T}"/> interface.</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfGreaterThanOrEqualTo<T>(this T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, other, paramName);
#else
            if (value.CompareTo(other) >= 0)
            {
                ThrowGreaterEqual(paramName, value, other);
            }
#endif
        }

        #endregion

        #region ThrowIfLessThan

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than <paramref name="other"/>.</summary>
        /// <param name="value">The argument to validate as greater than or equal to <paramref name="other"/>.</param>
        /// <param name="other">The value to compare with <paramref name="value"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        /// <typeparam name="T">A type that implements <seealso cref="IComparable{T}"/> interface.</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLessThan<T>(this T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfLessThan(value, other, paramName);
#else
            if (value.CompareTo(other) < 0)
            {
                ThrowLess(paramName, value, other);
            }
#endif
        }

        #endregion

        #region ThrowIfLessThanOrEqualTo

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than or equal to <paramref name="other"/>.</summary>
        /// <param name="value">The argument to validate as greater than <paramref name="other"/>.</param>
        /// <param name="other">The value to compare with <paramref name="value"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        /// <typeparam name="T">A type that implements <seealso cref="IComparable{T}"/> interface.</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLessThanOrEqualTo<T>(this T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, other, paramName);
#else
            if (value.CompareTo(other) <= 0)
            {
                ThrowLessEqual(paramName, value, other);
            }
#endif
        }

        #endregion

        #region ThrowIfEqualTo

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is equal to <paramref name="other"/>.</summary>
        /// <param name="value">The argument to validate as not equal to <paramref name="other"/>.</param>
        /// <param name="other">The value to compare with <paramref name="value"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        /// <typeparam name="T">A type that implements <seealso cref="IEquatable{T}"/> interface.</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfEqualTo<T>(this T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IEquatable<T>?
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfEqual(value, other, paramName);
#else
            if (EqualityComparer<T>.Default.Equals(value, other))
            {
                ThrowEqual(paramName, value, other);
            }
#endif
        }

        #endregion

        #region ThrowIfNotEqualTo

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is not equal to <paramref name="other"/>.</summary>
        /// <param name="value">The argument to validate as equal to <paramref name="other"/>.</param>
        /// <param name="other">The value to compare with <paramref name="value"/>.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
        /// <typeparam name="T">A type that implements <seealso cref="IEquatable{T}"/> interface.</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNotEqualTo<T>(this T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IEquatable<T>?
        {
#if NET8_0_OR_GREATER
            ArgumentOutOfRangeException.ThrowIfNotEqual(value, other, paramName);
#else
            if (!EqualityComparer<T>.Default.Equals(value, other))
            {
                ThrowNotEqual(paramName, value, other);
            }
#endif
        }

        #endregion

        [DoesNotReturn]
        private static void ThrowPositive<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonPositive(paramName, value));
        }

        [DoesNotReturn]
        private static void ThrowPositiveOrZero<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonPositiveNonZero(paramName, value));
        }

#if !NET8_0_OR_GREATER
        [DoesNotReturn]
        private static void ThrowZero<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonZero(paramName, value));
        }

        [DoesNotReturn]
        private static void ThrowNegative<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonNegative(paramName, value));
        }

        [DoesNotReturn]
        private static void ThrowNegativeOrZero<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonNegativeNonZero(paramName, value));
        }

        [DoesNotReturn]
        private static void ThrowGreater<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeLessOrEqual(paramName, value, other));
        }

        [DoesNotReturn]
        private static void ThrowGreaterEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeLess(paramName, value, other));
        }

        [DoesNotReturn]
        private static void ThrowLess<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeGreaterOrEqual(paramName, value, other));
        }

        [DoesNotReturn]
        private static void ThrowLessEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeGreater(paramName, value, other));
        }

        [DoesNotReturn]
        private static void ThrowEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNotEqual(paramName, value, other));
        }

        [DoesNotReturn]
        private static void ThrowNotEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeEqual(paramName, value, other));
        }
#endif
    }
}
