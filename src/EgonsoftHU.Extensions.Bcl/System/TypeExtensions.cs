// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using EgonsoftHU.Extensions.Bcl.Constants;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="Type"/> type.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the <see cref="Nullable{T}"/> type based on the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The value type from which a new nullable type should be constructed.</param>
        /// <returns>
        /// A <see cref="Nullable{T}"/> type that is
        /// the specified <paramref name="type"/> itself if it is a <see cref="Nullable{T}"/> type;
        /// a constructed <see cref="Nullable{T}"/> type if <paramref name="type"/> is a value type;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        [return: MaybeNull]
        public static Type AsNullableValueType(this Type type)
        {
            type.ThrowIfNull();

            return type switch
            {
                { IsValueType: true } when type.IsNullableValueType() => type,
                { IsValueType: true } => CreateNullableType(type),
                _ => null
            };
        }

        /// <summary>
        /// Indicates whether the current <paramref name="type"/> is a nullable value type.
        /// </summary>
        /// <param name="type">The type to check if it is a nullable value type.</param>
        /// <returns><see langword="true"/> if <paramref name="type"/> is a nullable value type; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        public static bool IsNullableValueType(this Type type)
        {
            type.ThrowIfNull();

            TypeInfo typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsValueType
                &&
                typeInfo.IsGenericType
                &&
                GenericTypeDefinitions.Nullable == type.GetGenericTypeDefinition();
        }

        /// <summary>
        /// Gets the full name of the <see cref="Type"/>, if available; otherwise, the name of the <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> the name of which to get.</param>
        /// <returns>The full name of the <see cref="Type"/>, if available; otherwise, the name of the <see cref="Type"/>.</returns>
        public static string GetName(this Type type)
        {
            return TypeHelper.GetTypeName(type);
        }

        private static Type CreateNullableType(Type type)
        {
            Type constructedType = GenericTypeDefinitions.Nullable.MakeGenericType(type);
            return constructedType;
        }
    }
}
