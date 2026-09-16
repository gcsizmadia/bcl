// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="IEnumerable{T}"/> type.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Determines whether a sequence is <see langword="null"/> or contains no element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="sequence">The sequence to check if it is <see langword="null"/> or contains no element.</param>
        /// <returns><see langword="true"/> if the <paramref name="sequence"/> is <see langword="null"/> or contains no element; otherwise, <see langword="false"/>.</returns>
        public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? sequence)
        {
            return sequence is null || !sequence.Any();
        }

        /// <summary>
        /// Groups the difference between <paramref name="incomingItems"/> and <paramref name="existingItems"/>
        /// into new, existing and removed items according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TItem">The type of the items.</typeparam>
        /// <typeparam name="TKey">The type of the key of an item.</typeparam>
        /// <param name="existingItems">An <see cref="IEnumerable{TItem}"/> whose keys that are not also in <paramref name="incomingItems"/> will be returned as removed items.</param>
        /// <param name="incomingItems">An <see cref="IEnumerable{TItem}"/> the elements of which will be returned either as new or existing items.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>
        /// An instance of the <see cref="ItemsChangeResult{TItem}"/> type representing the detected changes as new, existing and removed items.
        /// </returns>
        public static ItemsChangeResult<TItem> DetectChanges<TItem, TKey>(
            this IEnumerable<TItem>? existingItems,
            IEnumerable<TItem>? incomingItems,
            Func<TItem, TKey> keySelector
        )
        {
            keySelector.ThrowIfNull();

            IEnumerable<TItem> existing = existingItems ?? Array.Empty<TItem>();
            IEnumerable<TItem> incoming = incomingItems ?? Array.Empty<TItem>();

            IEnumerable<TKey> existingKeys = existing.Select(keySelector).ToList().AsReadOnly();
            IEnumerable<TKey> incomingKeys = incoming.Select(keySelector).ToList().AsReadOnly();

#if NET6_0_OR_GREATER
            IEnumerable<TItem> itemsToAdd = incoming.ExceptBy(existingKeys, keySelector);
            IEnumerable<TItem> itemsToUpdate = incoming.IntersectBy(existingKeys, keySelector);
            IEnumerable<TItem> itemsToRemove = existing.ExceptBy(incomingKeys, keySelector);
#else
            IEnumerable<TKey> keysForAdd = incomingKeys.Except(existingKeys);
            IEnumerable<TKey> keysForUpdate = incomingKeys.Intersect(existingKeys);
            IEnumerable<TKey> keysForRemove = existingKeys.Except(incomingKeys);

            IEnumerable<TItem> itemsToAdd = incoming.Join(keysForAdd, keySelector, key => key, (item, key) => item);
            IEnumerable<TItem> itemsToUpdate = incoming.Join(keysForUpdate, keySelector, key => key, (item, key) => item);
            IEnumerable<TItem> itemsToRemove = existing.Join(keysForRemove, keySelector, key => key, (item, key) => item);
#endif
            return
                new ItemsChangeResult<TItem>(
                    itemsToAdd.ToList().AsReadOnly(),
                    itemsToUpdate.ToList().AsReadOnly(),
                    itemsToRemove.ToList().AsReadOnly()
                );
        }

        /// <summary>
        /// Groups the difference between <paramref name="incomingItems"/> and <paramref name="existingItems"/>
        /// into new, existing and removed items according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TIncoming">The type of the incoming items.</typeparam>
        /// <typeparam name="TExisting">The type of the existing items.</typeparam>
        /// <typeparam name="TKey">The type of the key of an item.</typeparam>
        /// <param name="existingItems">An <see cref="IEnumerable{TItem}"/> whose keys that are not also in <paramref name="incomingItems"/> will be returned as removed items.</param>
        /// <param name="incomingItems">An <see cref="IEnumerable{TItem}"/> the elements of which will be returned either as new or existing items.</param>
        /// <param name="existingKeySelector">A function to extract the key for each existing element.</param>
        /// <param name="incomingKeySelector">A function to extract the key for each incoming element.</param>
        /// <returns>
        /// An instance of the <see cref="ItemsChangeResult{TIncoming, TExisting}"/> type representing the detected changes as new, existing and removed items.
        /// </returns>
        public static ItemsChangeResult<TIncoming, TExisting> DetectChanges<TIncoming, TExisting, TKey>(
            this IEnumerable<TExisting>? existingItems,
            IEnumerable<TIncoming>? incomingItems,
            Func<TExisting, TKey> existingKeySelector,
            Func<TIncoming, TKey> incomingKeySelector
        )
        {
            existingKeySelector.ThrowIfNull();
            incomingKeySelector.ThrowIfNull();

            IEnumerable<TExisting> existing = existingItems ?? Array.Empty<TExisting>();
            IEnumerable<TIncoming> incoming = incomingItems ?? Array.Empty<TIncoming>();

            IEnumerable<TKey> existingKeys = existing.Select(existingKeySelector).ToList().AsReadOnly();
            IEnumerable<TKey> incomingKeys = incoming.Select(incomingKeySelector).ToList().AsReadOnly();

#if NET6_0_OR_GREATER
            IEnumerable<TIncoming> itemsToAdd = incoming.ExceptBy(existingKeys, incomingKeySelector);
            IEnumerable<TIncoming> itemsToUpdate = incoming.IntersectBy(existingKeys, incomingKeySelector);
            IEnumerable<TExisting> itemsToRemove = existing.ExceptBy(incomingKeys, existingKeySelector);
#else
            IEnumerable<TKey> keysForAdd = incomingKeys.Except(existingKeys);
            IEnumerable<TKey> keysForUpdate = incomingKeys.Intersect(existingKeys);
            IEnumerable<TKey> keysForRemove = existingKeys.Except(incomingKeys);

            IEnumerable<TIncoming> itemsToAdd = incoming.Join(keysForAdd, incomingKeySelector, key => key, (item, key) => item);
            IEnumerable<TIncoming> itemsToUpdate = incoming.Join(keysForUpdate, incomingKeySelector, key => key, (item, key) => item);
            IEnumerable<TExisting> itemsToRemove = existing.Join(keysForRemove, existingKeySelector, key => key, (item, key) => item);
#endif
            return
                new ItemsChangeResult<TIncoming, TExisting>(
                    itemsToAdd.ToList().AsReadOnly(),
                    itemsToUpdate.ToList().AsReadOnly(),
                    itemsToRemove.ToList().AsReadOnly()
                );
        }
    }
}
