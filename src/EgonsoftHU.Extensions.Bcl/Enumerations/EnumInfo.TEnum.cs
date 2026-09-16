// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

using EgonsoftHU.Extensions.Bcl.Enumerations.Internals;
using EgonsoftHU.Extensions.Bcl.Exceptions;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    /// <summary>
    /// A base class to represent an enumeration value and also to provide access to additional information
    /// about both the current enumeration value and the <typeparamref name="TEnum"/> type itself.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
    [DebuggerDisplay("{DebuggerDisplayValue}")]
    public abstract partial class EnumInfo<TEnum> : EnumInfo
        where TEnum : struct, Enum
    {
        /// <summary>
        /// The type of the enumeration specified by the <typeparamref name="TEnum"/> type parameter.
        /// </summary>
        public static readonly Type EnumType;

        /// <summary>
        /// The <see cref="TypeInfo"/> representation of the type stored in the <see cref="EnumType"/> field.
        /// </summary>
        public static readonly TypeInfo EnumTypeInfo;

        /// <summary>
        /// The underlying type code of the enumeration specified by the <typeparamref name="TEnum"/> type parameter.
        /// </summary>
        public static readonly TypeCode EnumTypeCode;

        /// <summary>
        /// The underlying type of the enumeration specified by the <typeparamref name="TEnum"/> type parameter.
        /// </summary>
        public static readonly Type EnumUnderlyingType;

        /// <summary>
        /// Indicates whether the <see cref="FlagsAttribute"/> is applied to the enumeration type specified by the <typeparamref name="TEnum"/> type parameter.
        /// </summary>
        public static readonly bool HasFlagsAttribute;

        /// <summary>
        /// Indicates whether the underlying type is a signed integral numeric type.
        /// </summary>
        public static readonly bool IsSigned;

        private protected static readonly Type EnumInfoType;

        private protected static readonly ReadOnlyDictionary<Type, Func<Type, Type>> ConcreteTypeFactoryByUnderlyingType;

        private protected static readonly ReadOnlyDictionary<string, FieldInfo> FieldsByEnumMemberName;

        static EnumInfo()
        {
            ConcreteTypeFactoryByUnderlyingType = InitializeConcreteTypeFactoryByUnderlyingType();

            DefaultValue = default;

            EnumType = typeof(TEnum);
            EnumTypeInfo = EnumType.GetTypeInfo();
            EnumTypeCode = Type.GetTypeCode(EnumType);
            EnumUnderlyingType = Enum.GetUnderlyingType(EnumType);
            EnumInfoType = ConcreteTypeFactoryByUnderlyingType[EnumUnderlyingType].Invoke(EnumType);

            HasFlagsAttribute = EnumType.GetCustomAttribute<FlagsAttribute>() is not null;

            switch (EnumTypeCode)
            {
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    IsSigned = true;
                    break;

                default:
                    break;
            }

            FieldsByEnumMemberName = InitializeFieldsByEnumMemberName();
        }

        private protected EnumInfo(string name, TEnum value)
        {
            Name = name;
            Value = value;

            Attributes = EnumerationAttributes.Empty;
            SerializedValue = name;
        }

        /// <summary>
        /// Gets a collection of the fields defined by the <typeparamref name="TEnum"/> type,
        /// each represented by an instance of the <see cref="EnumInfo{TEnum}"/> type.
        /// </summary>
        public static IReadOnlyCollection<EnumInfo<TEnum>> DeclaredMembers
        {
            get => EnumTypeCode switch
            {
                TypeCode.SByte => EnumInfo<TEnum, sbyte>.DeclaredMembers,
                TypeCode.Int16 => EnumInfo<TEnum, short>.DeclaredMembers,
                TypeCode.Int32 => EnumInfo<TEnum, int>.DeclaredMembers,
                TypeCode.Int64 => EnumInfo<TEnum, long>.DeclaredMembers,
                TypeCode.Byte => EnumInfo<TEnum, byte>.DeclaredMembers,
                TypeCode.UInt16 => EnumInfo<TEnum, ushort>.DeclaredMembers,
                TypeCode.UInt32 => EnumInfo<TEnum, uint>.DeclaredMembers,
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.DeclaredMembers,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets a collection of the fields defined by the <typeparamref name="TEnum"/> type,
        /// each represented by an instance of the <see cref="EnumInfo{TEnum}"/> type.
        /// </summary>
        /// <remarks>
        /// If multiple constants of type <typeparamref name="TEnum"/> have the same value,
        /// only one of them (the first in the order of declaration) is included in the collection.
        /// </remarks>
        public static IReadOnlyCollection<EnumInfo<TEnum>> DeclaredMembersExcludingSynonyms
        {
            get => EnumTypeCode switch
            {
                TypeCode.SByte => EnumInfo<TEnum, sbyte>.DeclaredMembersExcludingSynonyms,
                TypeCode.Int16 => EnumInfo<TEnum, short>.DeclaredMembersExcludingSynonyms,
                TypeCode.Int32 => EnumInfo<TEnum, int>.DeclaredMembersExcludingSynonyms,
                TypeCode.Int64 => EnumInfo<TEnum, long>.DeclaredMembersExcludingSynonyms,
                TypeCode.Byte => EnumInfo<TEnum, byte>.DeclaredMembersExcludingSynonyms,
                TypeCode.UInt16 => EnumInfo<TEnum, ushort>.DeclaredMembersExcludingSynonyms,
                TypeCode.UInt32 => EnumInfo<TEnum, uint>.DeclaredMembersExcludingSynonyms,
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.DeclaredMembersExcludingSynonyms,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets an instance of the <see cref="EnumInfo{TEnum}"/> type that represents the value of <see cref="DefaultValue"/> property.
        /// </summary>
        public static EnumInfo<TEnum> Default
        {
            get => EnumTypeCode switch
            {
                TypeCode.SByte => EnumInfo<TEnum, sbyte>.Default,
                TypeCode.Int16 => EnumInfo<TEnum, short>.Default,
                TypeCode.Int32 => EnumInfo<TEnum, int>.Default,
                TypeCode.Int64 => EnumInfo<TEnum, long>.Default,
                TypeCode.Byte => EnumInfo<TEnum, byte>.Default,
                TypeCode.UInt16 => EnumInfo<TEnum, ushort>.Default,
                TypeCode.UInt32 => EnumInfo<TEnum, uint>.Default,
                TypeCode.UInt64 => EnumInfo<TEnum, ulong>.Default,
                _ => throw NotSupportedExceptions.NotSupportedEnumTypeCode<TEnum>(EnumTypeCode)
            };
        }

        /// <summary>
        /// Gets the value produced by the expression <c>(TEnum)0</c>, where <typeparamref name="TEnum"/> is the enum identifier.
        /// </summary>
        public static TEnum DefaultValue { get; private set; }

        /// <summary>
        /// Gets the name of the constant in the <typeparamref name="TEnum"/> type for the current enumeration value.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value of the constant in the <typeparamref name="TEnum"/> type for the current enumeration value.
        /// </summary>
        public TEnum Value { get; private set; }

        /// <summary>
        /// Gets the value of the underlying type constant in the <typeparamref name="TEnum"/> type converted to <see cref="UInt64"/>.
        /// </summary>
        public ulong UInt64Value { get; protected set; }

        /// <summary>
        /// Gets a string representation of the current enumeration value.
        /// </summary>
        public string SerializedValue { get; protected set; }

        /// <summary>
        /// Indicates whether the current enumeration value is the default value of the <typeparamref name="TEnum"/> type.
        /// </summary>
        public bool IsDefaultValue { get; protected set; }

        /// <summary>
        /// Indicates whether the current enumeration value is defined in the <typeparamref name="TEnum"/> type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if a constant in the <typeparamref name="TEnum"/> type has a value equal to <see cref="Value"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsDefined { get; protected set; }

        /// <summary>
        /// Gets all custom attributes applied to the current member of the <typeparamref name="TEnum"/> type.
        /// </summary>
        public IEnumerationAttributes Attributes { get; protected set; }

        private protected abstract string DebuggerDisplayValue { get; }

        /// <summary>
        /// Determines whether one or more bit fields are set in the current instance.
        /// </summary>
        /// <param name="flag">An enumeration value represented by an instance of the <see cref="EnumInfo{TEnum}"/> type.</param>
        /// <returns>
        /// <see langword="true"/> if the bit field or bit fields that are set in flag are also set in the current instance;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public bool HasFlag(EnumInfo<TEnum> flag)
        {
            flag.ThrowIfNull();

            return Value.HasFlag(flag.Value);
        }
    }
}
