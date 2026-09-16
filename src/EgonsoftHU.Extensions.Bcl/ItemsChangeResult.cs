// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Collections.Generic;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// Represents the difference between two sets of items as groups of new, existing and removed items.
    /// </summary>
    /// <typeparam name="TItem">The type of the items.</typeparam>
    /// <param name="ItemsToAdd">Incoming items to add.</param>
    /// <param name="ItemsToUpdate">Incoming items based on which to update existing items.</param>
    /// <param name="ItemsToRemove">Existing items to be removed.</param>
    public record ItemsChangeResult<TItem>(
        IReadOnlyList<TItem> ItemsToAdd,
        IReadOnlyList<TItem> ItemsToUpdate,
        IReadOnlyList<TItem> ItemsToRemove
    );

    /// <summary>
    /// Represents the difference between two sets of items as groups of new, existing and removed items.
    /// </summary>
    /// <typeparam name="TIncoming">The type of the incoming items.</typeparam>
    /// <typeparam name="TExisting">The type of the existing items.</typeparam>
    /// <param name="ItemsToAdd">Incoming items to add.</param>
    /// <param name="ItemsToUpdate">Incoming items based on which to update existing items.</param>
    /// <param name="ItemsToRemove">Existing items to be removed.</param>
    public record ItemsChangeResult<TIncoming, TExisting>(
        IReadOnlyList<TIncoming> ItemsToAdd,
        IReadOnlyList<TIncoming> ItemsToUpdate,
        IReadOnlyList<TExisting> ItemsToRemove
    );
}
