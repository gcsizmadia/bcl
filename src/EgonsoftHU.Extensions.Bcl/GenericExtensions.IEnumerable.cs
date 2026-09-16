// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Linq;

#if !NET8_0_OR_GREATER
using EgonsoftHU.Extensions.Bcl.Collections.Generic;
#endif

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
        /// <remarks>This method has been deprecated. Use <see cref="AsSingleElementSequence{T}(T)"/> extension method instead.</remarks>
        [Obsolete("This method has been deprecated. Use " + nameof(AsSingleElementSequence) + "<T>(T) extension method instead.")]
        public static IEnumerable<T?> AsEnumerable<T>(this T? value)
        {
            yield return value;
        }

#if !NET8_0_OR_GREATER
        /// <summary>
        /// Returns a value as a sequence that contains only that value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">A value to be returned as <see cref="IEnumerable{T}"/>.</param>
        /// <returns>Returns a sequence that contains only the specified <paramref name="value"/>.</returns>
        public static IEnumerable<T> AsSingleElementSequence<T>(this T value)
        {
            return new SingleElementSequence<T>(value);
        }
#endif

        /// <summary>
        /// Determines whether a specified collection contains the current value by using a specified <see cref="IEqualityComparer{T}"/>.
        /// If no equality comparer is specified then the default equality comparer will be used.
        /// </summary>
        /// <typeparam name="T">The type of both the current value and the elements in <paramref name="values"/>.</typeparam>
        /// <param name="value">The value to locate in the collection.</param>
        /// <param name="equalityComparer">An equality comparer to compare values.</param>
        /// <param name="values">A collection in which to locate a value.</param>
        /// <returns>Returns true if the specified collection contains an element that has the specified value; otherwise, false.</returns>
        public static bool IsIn<T>(this T? value, IEqualityComparer<T?>? equalityComparer, params T?[] values)
        {
            return
                equalityComparer is null
                    ? values.Contains(value)
                    : values.Contains(value, equalityComparer);
        }

        /// <summary>
        /// Determines whether a specified collection contains the current value by using the default equality comparer.
        /// </summary>
        /// <typeparam name="T">The type of both the current value and the elements in <paramref name="values"/>.</typeparam>
        /// <param name="value">The value to locate in the collection.</param>
        /// <param name="values">A collection in which to locate a value.</param>
        /// <returns>Returns true if the specified collection contains an element that has the specified value; otherwise, false.</returns>
        public static bool IsIn<T>(this T? value, params T?[] values)
        {
            return value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Determines whether a specified collection does not contain the current value by using a specified <see cref="IEqualityComparer{T}"/>.
        /// If no equality comparer is specified then the default equality comparer will be used.
        /// </summary>
        /// <typeparam name="T">The type of both the current value and the elements in <paramref name="values"/>.</typeparam>
        /// <param name="value">The value to locate in the collection.</param>
        /// <param name="values">A collection in which to locate a value.</param>
        /// <returns>Returns true if the specified collection does not contain an element that has the specified value; otherwise, false.</returns>
        public static bool IsNotIn<T>(this T? value, params T?[] values)
        {
            return !value.IsIn(values);
        }

        /// <summary>
        /// Determines whether a specified collection does not contain the current value by using the default equality comparer.
        /// </summary>
        /// <typeparam name="T">The type of both the current value and the elements in <paramref name="values"/>.</typeparam>
        /// <param name="value">The value to locate in the collection.</param>
        /// <param name="equalityComparer">An equality comparer to compare values.</param>
        /// <param name="values">A collection in which to locate a value.</param>
        /// <returns>Returns true if the specified collection does not contain an element that has the specified value; otherwise, false.</returns>
        public static bool IsNotIn<T>(this T? value, IEqualityComparer<T?>? equalityComparer, params T?[] values)
        {
            return !value.IsIn(equalityComparer, values);
        }
    }
}
