// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Constants
{
    /// <summary>
    /// Contains generic type definitions.
    /// </summary>
    public static class GenericTypeDefinitions
    {
        /// <summary>
        /// The generic type definition for the <see cref="Nullable{T}"/> type.
        /// </summary>
        public static Type Nullable { get; } = typeof(Nullable<>);
    }
}
