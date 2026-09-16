// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
#if NET7_0_OR_GREATER
using System.Collections.Generic;
#endif 
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal sealed class EnumerationAttributes : IEnumerationAttributes
    {
        internal static readonly EnumerationAttributes Empty = new();

        private readonly ReadOnlyCollection<Attribute> attributes;

        internal EnumerationAttributes(FieldInfo fieldInfo)
        {
            attributes = fieldInfo.GetCustomAttributes().ToList().AsReadOnly();

            Description = GetAttribute<DescriptionAttribute>();
            Display = GetAttribute<DisplayAttribute>();
            DisplayName = GetAttribute<DisplayNameAttribute>();
            EnumMember = GetAttribute<EnumMemberAttribute>();
        }

        private EnumerationAttributes()
        {
            attributes = Array.Empty<Attribute>().AsReadOnly();
        }

        public DescriptionAttribute? Description { get; }

        public DisplayAttribute? Display { get; }

        public DisplayNameAttribute? DisplayName { get; }

        public EnumMemberAttribute? EnumMember { get; }

        public TAttribute? GetAttribute<TAttribute>()
            where TAttribute : Attribute
        {
            return attributes.OfType<TAttribute>().FirstOrDefault();
        }

        public ReadOnlyCollection<Attribute> GetAll()
        {
            return attributes;
        }
    }
}
