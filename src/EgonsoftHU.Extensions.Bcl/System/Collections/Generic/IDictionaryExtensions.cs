// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
#if !NET7_0_OR_GREATER
using System.Collections.ObjectModel;
#endif

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="IDictionary{TKey, TValue}"/> type.
    /// </summary>
    public static class IDictionaryExtensions
    {
#if NET7_0_OR_GREATER
        // System.Collections.Generic.CollectionExtensions contains an extension method with the same signature.
#else
        /// <summary>
        /// Returns a read-only <see cref="ReadOnlyDictionary{TKey, TValue}"/> wrapper for the current dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to wrap into a read-only wrapper.</param>
        /// <returns>An object that acts as a read-only wrapper around the current <see cref="IDictionary{TKey, TValue}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is <see langword="null"/>.</exception>
        public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            dictionary.ThrowIfNull();

            return dictionary switch
            {
                ReadOnlyDictionary<TKey, TValue> readOnly => readOnly,
                _ => new ReadOnlyDictionary<TKey, TValue>(dictionary)
            };
        }
#endif

        /// <summary>
        /// Returns a collection of key/value pairs that are sorted on the key.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary the key/value pairs of which are sorted on the key.</param>
        /// <returns>A collection of the original key/value pairs that are sorted on the key.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is <see langword="null"/>.</exception>
        public static SortedDictionary<TKey, TValue> AsSorted<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            dictionary.ThrowIfNull();

            return dictionary switch
            {
                SortedDictionary<TKey, TValue> readOnly => readOnly,
                _ => new SortedDictionary<TKey, TValue>(dictionary)
            };
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary from which the value for the specified key is retrieved.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, either <see cref="ArgumentNullException"/> or <see cref="KeyNotFoundException"/> is thrown.</returns>
        /// <exception cref="ArgumentNullException">Either <paramref name="dictionary"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
        /// <exception cref="KeyNotFoundException">The given <paramref name="key"/> was not present in the <paramref name="dictionary"/>.</exception>
        public static TValue GetOrThrow<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
        {
            dictionary.ThrowIfNull();

            return
                dictionary.TryGetValue(key, out TValue? value)
                    ? value
                    : throw KeyNotFoundExceptions.KeyNotFound(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key or a default value.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary from which the value for the specified key is retrieved.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">The value to return if <paramref name="key"/> is not found.</param>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, <paramref name="defaultValue"/>.</returns>
        /// <exception cref="ArgumentNullException">Either <paramref name="dictionary"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
        public static TValue DefaultIfKeyNotFound<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
            where TKey : notnull
        {
            dictionary.ThrowIfNull();

            return
                dictionary.TryGetValue(key, out TValue? value)
                    ? value
                    : defaultValue;
        }
    }
}
