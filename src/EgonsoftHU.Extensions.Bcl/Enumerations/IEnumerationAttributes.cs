// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
#if NET9_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    /// <summary>
    /// Provides access to attributes applied to an enum member.
    /// </summary>
    public interface IEnumerationAttributes
    {
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute"/> that is applied to the current enum member.
        /// </summary>
        DescriptionAttribute? Description { get; }

        /// <summary>
        /// Gets the <see cref="DisplayAttribute"/> that is applied to the current enum member.
        /// </summary>
        DisplayAttribute? Display { get; }

        /// <summary>
        /// Gets the <see cref="DisplayNameAttribute"/> that is applied to the current enum member.
        /// </summary>
        DisplayNameAttribute? DisplayName { get; }

        /// <summary>
        /// Gets the <see cref="EnumMemberAttribute"/> that is applied to the current enum member.
        /// </summary>
        EnumMemberAttribute? EnumMember { get; }

#if NET9_0_OR_GREATER
        /// <summary>
        /// Gets the <see cref="JsonStringEnumMemberNameAttribute"/> that is applied to the current enum member.
        /// </summary>
        JsonStringEnumMemberNameAttribute? JsonStringEnumMemberName { get; }
#endif

        /// <summary>
        /// Gets a custom attribute of a specified <typeparamref name="TAttribute"/> type that is applied to the current enum member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <returns>
        /// A custom attribute of the specified <typeparamref name="TAttribute"/> type, if applied to the current enum member;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        TAttribute? GetAttribute<TAttribute>()
            where TAttribute : Attribute;

        /// <summary>
        /// Gets all the attributes that are applied to the current enum member.
        /// </summary>
        /// <returns>A read-only collection of the attributes that are applied to the current enum member.</returns>
        ReadOnlyCollection<Attribute> GetAll();
    }
}
