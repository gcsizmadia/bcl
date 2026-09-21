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
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowArgumentException<T>(string? paramName, T value, Func<string?, T, string> messageSelector)
        {
            throw new ArgumentException(messageSelector.Invoke(paramName, value), paramName);
        }
    }
}
