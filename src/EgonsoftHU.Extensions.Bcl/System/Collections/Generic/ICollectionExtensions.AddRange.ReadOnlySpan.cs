// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
using System;
using System.Collections.Generic;

using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl
{
    public static partial class ICollectionExtensions
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
        public static void AddRange<T>(
            this ICollection<T> collection,
#if NET9_0_OR_GREATER
            params
#endif
            ReadOnlySpan<T> items
        )
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

#if NET8_0_OR_GREATER
            if (collection is List<T> list)
            {
                CollectionExtensions.AddRange(list, items);
                return;
            }
#endif

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

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
        public static void AddRange<T>(
            this ICollection<T?> collection,
#if NET9_0_OR_GREATER
            params
#endif
            ReadOnlySpan<T?> items
        )
            where T : struct
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

#if NET8_0_OR_GREATER
            if (collection is List<T?> list)
            {
                CollectionExtensions.AddRange(list, items);
                return;
            }
#endif

            foreach (T? item in items)
            {
                collection.Add(item);
            }
        }

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
        public static void AddRange<T>(
            this ICollection<T?> collection,
#if NET9_0_OR_GREATER
            params
#endif
            ReadOnlySpan<T> items
        )
            where T : struct
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

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

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
        /// <exception cref="ArgumentException"><paramref name="collection"/> is read-only or <paramref name="items"/> contains <see langword="null"/>.</exception>
        public static void AddRange<T>(
            this ICollection<T> collection,
#if NET9_0_OR_GREATER
            params
#endif
            ReadOnlySpan<T?> items
        )
            where T : struct
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

            var nonNullableItems = new List<T>();
            int itemsCount = 0;

            foreach (T? item in items)
            {
                itemsCount++;

                if (item.HasValue)
                {
                    nonNullableItems.Add(item.Value);
                }
            }

            if (itemsCount > nonNullableItems.Count)
            {
                throw ArgumentExceptions.CollectionContainsNull(nameof(items));
            }

#if NET8_0_OR_GREATER
            if (collection is List<T> list)
            {
                list.AddRange(nonNullableItems);
                return;
            }
#endif

            foreach (T item in nonNullableItems)
            {
                collection.Add(item);
            }
        }
    }
}
#endif
