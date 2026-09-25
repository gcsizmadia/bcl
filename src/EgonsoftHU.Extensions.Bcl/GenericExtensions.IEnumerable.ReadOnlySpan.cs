// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NET8_0_OR_GREATER

using System;
#if NET10_0_OR_GREATER
using System.Collections.Generic;
#endif
using System.Linq;

namespace EgonsoftHU.Extensions.Bcl
{
    public partial class GenericExtensions
    {
        /// <summary>
        /// Indicates whether a specified value is found in a read-only span.
        /// </summary>
        /// <typeparam name="T">The type of the span.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The span to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(
            this T value,
#if NET10_0_OR_GREATER
            params
#endif
            ReadOnlySpan<T> values
        )
            where T : IEquatable<T>?
        {
            return values.Contains(value);
        }

#if NET10_0_OR_GREATER
        /// <summary>
        /// Indicates whether a specified value is found in a read-only span.
        /// </summary>
        /// <typeparam name="T">The type of the span.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The span to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(
            this T value,
            IEqualityComparer<T>? equalityComparer,
            params ReadOnlySpan<T> values
        )
        {
            return values.Contains(value, equalityComparer);
        }
#endif

        /// <summary>
        /// Indicates whether a specified value is not found in a read-only span.
        /// </summary>
        /// <typeparam name="T">The type of the span.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The span to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(
            this T value,
#if NET10_0_OR_GREATER
            params
#endif
            ReadOnlySpan<T> values
        )
            where T : notnull, IEquatable<T>?
        {
            return !values.Contains(value);
        }

#if NET10_0_OR_GREATER
        /// <summary>
        /// Indicates whether a specified value is not found in a read-only span.
        /// </summary>
        /// <typeparam name="T">The type of the span.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The span to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(
            this T value,
            IEqualityComparer<T>? equalityComparer,
            params ReadOnlySpan<T> values
        )
        {
            return !values.Contains(value, equalityComparer);
        }
#endif
    }
}
#endif
