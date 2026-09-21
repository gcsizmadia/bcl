// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="ICollection{T}"/> type.
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the current <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="collection">The current collection to the end of which the elements of the specified collection will be added.</param>
        /// <param name="items">
        /// The collection whose elements should be added to the end of the current <paramref name="collection"/>.
        /// The collection itself cannot be <see langword="null" />,
        /// but it can contain elements that are <see langword="null" />, if type <typeparamref name="T"/> is a nullable reference/value type.
        /// </param>
        /// <exception cref="ArgumentNullException">Either <paramref name="collection"/> or <paramref name="items"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="collection"/> is read-only.</exception>
#if NET9_0_OR_GREATER
        public static void AddRange<T>(this ICollection<T> collection, params IEnumerable<T> items)
#else
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
#endif
        {
            collection.ThrowIfNull();
            items.ThrowIfNull();

            if (collection.IsReadOnly)
            {
                throw ArgumentExceptions.CollectionIsReadOnly(nameof(collection));
            }

            if (collection is List<T> list)
            {
                list.AddRange(items);
                return;
            }

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        /// <summary>
        /// Adds the elements of the specified collection to the end of the current <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="collection">The current collection to the end of which the elements of the specified collection will be added.</param>
        /// <param name="items">
        /// The collection whose elements should be added to the end of the current <paramref name="collection"/>.
        /// The collection itself cannot be <see langword="null" />,
        /// but it can contain elements that are <see langword="null" />, if type <typeparamref name="T"/> is a nullable reference/value type.
        /// </param>
        /// <exception cref="ArgumentNullException">Either <paramref name="collection"/> or <paramref name="items"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="collection"/> is read-only.</exception>
#if NET9_0_OR_GREATER
        public static void AddRange<T>(this ICollection<T> collection, params ReadOnlySpan<T> items)
#elif NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public static void AddRange<T>(this ICollection<T> collection, ReadOnlySpan<T> items)
#endif
        {
            collection.ThrowIfNull();

            if (collection.IsReadOnly)
            {
                throw ArgumentExceptions.CollectionIsReadOnly(nameof(collection));
            }

            if (items.IsEmpty)
            {
                return;
            }

            if (collection is List<T> list)
            {
                list.AddRange(items);
                return;
            }

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }
#endif
    }
}
