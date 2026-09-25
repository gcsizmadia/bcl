// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NET8_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
#endif
using System.Collections.Generic;

using EgonsoftHU.Extensions.Bcl.Collections.Generic;

namespace EgonsoftHU.Extensions.Bcl
{
    public partial class GenericExtensions
    {
        /// <summary>
        /// Returns a value as a sequence that contains only that value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">A value to be returned as <see cref="IEnumerable{T}"/>.</param>
        /// <returns>Returns a sequence that contains only the specified <paramref name="value"/>.</returns>
#if NET8_0_OR_GREATER
        [SuppressMessage(SonarQube.Category, SonarQube.S1133)]
        [Obsolete("Use collection expressions instead.", error: true)]
#endif
        public static IEnumerable<T> AsSingleElementSequence<T>(this T value)
        {
            return new SingleElementSequence<T>(value);
        }
    }
}
