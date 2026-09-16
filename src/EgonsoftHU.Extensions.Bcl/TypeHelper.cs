// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains utility methods for <see cref="Type"/> type.
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// Gets the fully qualified name of the <typeparamref name="T"/> type, including its namespace but not its assembly, if available;
        /// otherwise, the name of the <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> the name of which to get.</typeparam>
        /// <returns>The fully qualified name of the <typeparamref name="T"/> type, including its namespace but not its assembly, if available;
        /// otherwise, the name of the <typeparamref name="T"/> type.</returns>
        public static string GetTypeName<T>()
        {
            return GetTypeName(typeof(T));
        }

        /// <summary>
        /// Gets the fully qualified name of the <paramref name="type"/>, including its namespace but not its assembly, if available;
        /// otherwise, the name of the <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> the name of which to get.</param>
        /// <returns>
        /// The fully qualified name of the <paramref name="type"/>, including its namespace but not its assembly, if available;
        /// otherwise, the name of the <paramref name="type"/>.
        /// </returns>
        /// <remarks>If <paramref name="type"/> is <see langword="null"/> then an empty string is returned.</remarks>
        public static string GetTypeName(Type? type)
        {
            return
                type is null
                    ? String.Empty
                    : type.FullName ?? type.Name;
        }
    }
}
