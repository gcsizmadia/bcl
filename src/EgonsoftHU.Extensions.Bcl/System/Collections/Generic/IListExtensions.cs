// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if !NET7_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
#endif

namespace EgonsoftHU.Extensions.Bcl
{
#if NET7_0_OR_GREATER
    // System.Collections.Generic.CollectionExtensions already contains AsReadOnly() extension method with the same signature.
#else
    /// <summary>
    /// This class contains extension methods that are available for <see cref="IList{T}"/> type.
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Returns a read-only <see cref="ReadOnlyCollection{T}"/> wrapper for the current collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="list">The list to wrap into a read-only wrapper.</param>
        /// <returns>An object that acts as a read-only wrapper around the current <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>.</exception>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IList<T> list)
        {
            list.ThrowIfNull();

            return list switch
            {
                ReadOnlyCollection<T> readOnly => readOnly,
                _ => new ReadOnlyCollection<T>(list)
            };
        }
    }
#endif
}
