// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using static EgonsoftHU.Extensions.Bcl.ErrorMessageConfiguration;

namespace EgonsoftHU.Extensions.Bcl
{
    internal static class ThrowHelper
    {

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowArgumentNullException(string? paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        [DoesNotReturn]
        internal static void ThrowPositive<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonPositive(paramName, value));
        }

        [DoesNotReturn]
        internal static void ThrowPositiveOrZero<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonPositiveNonZero(paramName, value));
        }

#if !NET8_0_OR_GREATER
        [DoesNotReturn]
        internal static void ThrowZero<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonZero(paramName, value));
        }

        [DoesNotReturn]
        internal static void ThrowNegative<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonNegative(paramName, value));
        }

        [DoesNotReturn]
        internal static void ThrowNegativeOrZero<T>(string? paramName, T value)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNonNegativeNonZero(paramName, value));
        }

        [DoesNotReturn]
        internal static void ThrowGreater<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeLessOrEqual(paramName, value, other));
        }

        [DoesNotReturn]
        internal static void ThrowGreaterEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeLess(paramName, value, other));
        }

        [DoesNotReturn]
        internal static void ThrowLess<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeGreaterOrEqual(paramName, value, other));
        }

        [DoesNotReturn]
        internal static void ThrowLessEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeGreater(paramName, value, other));
        }

        [DoesNotReturn]
        internal static void ThrowEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeNotEqual(paramName, value, other));
        }

        [DoesNotReturn]
        internal static void ThrowNotEqual<T>(string? paramName, T value, T other)
        {
            throw new ArgumentOutOfRangeException(paramName, value, ArgumentOutOfRange_MustBeEqual(paramName, value, other));
        }
#endif
    }
}
