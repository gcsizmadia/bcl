// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Collections.Generic;
using System.Linq;

namespace EgonsoftHU.Extensions.Bcl
{
    public partial class GenericExtensions
    {
        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T value, IEqualityComparer<T>? equalityComparer, params T[] values)
        {
            return
                equalityComparer is null
                    ? values.Contains(value)
                    : values.Contains(value, equalityComparer);
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T? value, IEqualityComparer<T?>? equalityComparer, params T?[] values)
            where T : struct
        {
            return
                equalityComparer is null
                    ? values.Contains(value)
                    : values.Contains(value, equalityComparer);
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T value, IEqualityComparer<T?>? equalityComparer, params T?[] values)
            where T : struct
        {
            return
                equalityComparer is null
                    ? values.Contains(value)
                    : values.Contains(value, equalityComparer);
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T? value, IEqualityComparer<T>? equalityComparer, params T[] values)
            where T : struct
        {
            return
                value.HasValue
                &&
                (
                    equalityComparer is null
                        ? values.Contains(value.Value)
                        : values.Contains(value.Value, equalityComparer)
                );
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T value, params T[] values)
        {
            return value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T? value, params T?[] values)
            where T : struct
        {
            return value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T value, params T?[] values)
            where T : struct
        {
            return value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if found; otherwise, <see langword="false"/>.</returns>
        public static bool IsIn<T>(this T? value, params T[] values)
            where T : struct
        {
            return value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T value, IEqualityComparer<T>? equalityComparer, params T[] values)
        {
            return !value.IsIn(equalityComparer, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T? value, IEqualityComparer<T?>? equalityComparer, params T?[] values)
            where T : struct
        {
            return !value.IsIn(equalityComparer, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T value, IEqualityComparer<T?>? equalityComparer, params T?[] values)
            where T : struct
        {
            return !value.IsIn(equalityComparer, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="equalityComparer">The <see cref="IEqualityComparer{T}" /> implementation to use when comparing elements, or <see langword="null" /> to use the default <see cref="IEqualityComparer{T}" /> for the type of an element.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T? value, IEqualityComparer<T>? equalityComparer, params T[] values)
            where T : struct
        {
            return !value.IsIn(equalityComparer, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T value, params T[] values)
        {
            return !value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T? value, params T?[] values)
            where T : struct
        {
            return !value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T value, params T?[] values)
            where T : struct
        {
            return !value.IsIn(equalityComparer: null, values);
        }

        /// <summary>
        /// Indicates whether a specified value is not found in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">The array to search.</param>
        /// <returns>Returns <see langword="true"/> if not found; otherwise, <see langword="false"/>.</returns>
        public static bool IsNotIn<T>(this T? value, params T[] values)
            where T : struct
        {
            return !value.IsIn(equalityComparer: null, values);
        }
    }
}
