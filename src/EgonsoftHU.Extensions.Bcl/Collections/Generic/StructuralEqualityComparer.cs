// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System.Collections;
using System.Collections.Generic;
#if NETCOREAPP
using System.Diagnostics.CodeAnalysis;
#endif

namespace EgonsoftHU.Extensions.Bcl.Collections.Generic
{
    /// <summary>
    /// Provides an <see cref="IEqualityComparer{T}"/> implementation for structural equality comparison.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    /// <remarks>
    /// With this comparer you can use types that implement <see cref="IStructuralEquatable"/> interface (e.g. arrays, value tuples) as the key in a dictionary.
    /// </remarks>
    /// <example>
    /// <code language="cs" title="Using the constructor.">
    /// <![CDATA[
    /// var dictionary = new Dictionary<byte[], object>(StructuralEqualityComparer<byte[]>.Default);
    /// ]]>
    /// </code>
    /// <code language="cs" title="Using LINQ.">
    /// <![CDATA[
    /// var dictionary =
    ///     collection.ToDictionary(
    ///         element => element.ByteArrayProperty,
    ///         element => element,
    ///         StructuralEqualityComparer<byte[]>.Default
    ///     );
    /// ]]>
    /// </code>
    /// </example>
    public sealed class StructuralEqualityComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Returns a default structural equality comparer for the type specified by the generic argument.
        /// </summary>
        public static StructuralEqualityComparer<T> Default { get; } = new();

        /// <inheritdoc/>
        public bool Equals(T? x, T? y)
        {
            return StructuralComparisons.StructuralEqualityComparer.Equals(x, y);
        }

#if NETFRAMEWORK || NETSTANDARD
        /// <inheritdoc/>
        public int GetHashCode(T obj)
#else
        /// <inheritdoc/>
        public int GetHashCode([DisallowNull] T obj)
#endif
        {
            return StructuralComparisons.StructuralEqualityComparer.GetHashCode(obj);
        }
    }
}
