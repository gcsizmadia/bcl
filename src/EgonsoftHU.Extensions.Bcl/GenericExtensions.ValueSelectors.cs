// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl
{
    public partial class GenericExtensions
    {
        /// <summary>
        /// Gets a string value using a specified value selector or null. The value selector gets the source object as input parameter.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <param name="sourceObject">The source object that can be used by a value selector.</param>
        /// <param name="valueSelector">A value selector that gets the source object as input parameter and returns a value.</param>
        /// <returns>
        /// A string value returned by the <paramref name="valueSelector"/> if it is not equal to <see langword="null"/>;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="sourceObject"/> or <paramref name="valueSelector"/> is <see langword="null"/>.
        /// </exception>
        public static string? GetStringValueOrNull<TSource>(this TSource sourceObject, Func<TSource, string?> valueSelector)
            where TSource : class?
        {
            sourceObject.ThrowIfNull();
            valueSelector.ThrowIfNull();

            return sourceObject.GetValueOrDefault(valueSelector, null);
        }

        /// <summary>
        /// Gets a string value using a specified value selector or <see cref="String.Empty"/>. The value selector gets the source object as input parameter.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <param name="sourceObject">The source object that can be used by a value selector.</param>
        /// <param name="valueSelector">A value selector that gets the source object as input parameter and returns a value.</param>
        /// <returns>
        /// A string value returned by the <paramref name="valueSelector"/> if it is not equal to <see langword="null"/>;
        /// otherwise, the <see cref="String.Empty"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="sourceObject"/> or <paramref name="valueSelector"/> is <see langword="null"/>.
        /// </exception>
        public static string GetStringValueOrEmptyString<TSource>(this TSource sourceObject, Func<TSource, string?> valueSelector)
            where TSource : class?
        {
            sourceObject.ThrowIfNull();
            valueSelector.ThrowIfNull();

            return
                sourceObject.GetValueOrDefault(valueSelector, String.Empty) is string result
                    ? result
                    : String.Empty;
        }

        /// <summary>
        /// Gets a value using a specified value selector or a specified default value.
        /// The value selector gets the source object as input parameter.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TResult">The type of the value that is returned by the value selector.</typeparam>
        /// <param name="sourceObject">The source object that can be used by a value selector.</param>
        /// <param name="valueSelector">A value selector that gets the source object as input parameter and returns a value.</param>
        /// <param name="defaultValue">
        /// The value to be returned if the value returned by the value selector is the default value of the return type.
        /// </param>
        /// <returns>
        /// A value returned by the <paramref name="valueSelector"/> if it is not equal to <c>default(<typeparamref name="TResult"/>)</c>;
        /// otherwise, the <paramref name="defaultValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="sourceObject"/> or <paramref name="valueSelector"/> is <see langword="null"/>.
        /// </exception>
        public static TResult GetValueOrDefault<TSource, TResult>(
            this TSource sourceObject,
            Func<TSource, TResult> valueSelector,
            TResult defaultValue
        )
            where TSource : class?
        {
            sourceObject.ThrowIfNull();
            valueSelector.ThrowIfNull();

            TResult value = valueSelector.Invoke(sourceObject);

            return value.IsDefaultValue() ? defaultValue : value;
        }

        /// <summary>
        /// Gets a value using a specified value selector that gets the source object as input parameter.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TResult">The type of the value that is returned by the value selector.</typeparam>
        /// <param name="sourceObject">The source object that can be used by a value selector.</param>
        /// <param name="valueSelector">A value selector that gets the source object as input parameter and returns a value.</param>
        /// <returns>A value returned by the <paramref name="valueSelector"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="sourceObject"/> or <paramref name="valueSelector"/> is <see langword="null"/>.
        /// </exception>
        public static TResult GetValue<TSource, TResult>(this TSource sourceObject, Func<TSource, TResult> valueSelector)
            where TSource : class?
        {
            sourceObject.ThrowIfNull();
            valueSelector.ThrowIfNull();

            return valueSelector.Invoke(sourceObject);
        }
    }
}
