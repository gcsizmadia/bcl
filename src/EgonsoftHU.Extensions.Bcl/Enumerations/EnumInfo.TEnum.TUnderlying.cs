// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

using EgonsoftHU.Extensions.Bcl.Constants;
using EgonsoftHU.Extensions.Bcl.Enumerations.Internals;
using EgonsoftHU.Extensions.Bcl.Enumerations.Serialization;
using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    internal abstract partial class EnumInfo<TEnum, TUnderlying> : EnumInfo<TEnum>
        where TEnum : struct, Enum
        where TUnderlying : struct, IComparable<TUnderlying>
    {
        private static readonly IEnumValueConverter<TEnum, TUnderlying> converter;

        private static readonly IEnumFlags<TUnderlying> flagCalculator;

        private static readonly Comparer<TUnderlying> comparer;

        private static readonly ReadOnlyCollection<TUnderlying> bits;

        private static readonly TUnderlying minValue;

        private static readonly TUnderlying maxValue;

#if NETFRAMEWORK || NETSTANDARD2_0
        private static readonly char[] NameSeparators = new[] { Chars.Comma };
#endif

        private static readonly ReadOnlyDictionary<TUnderlying, List<EnumInfo<TEnum, TUnderlying>>> membersByUnderlyingValue;

        private static readonly ReadOnlyDictionary<TUnderlying, EnumInfo<TEnum, TUnderlying>> memberByUnderlyingValue;

        private ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> flags;

        static EnumInfo()
        {
            converter = EnumValueConverter<TEnum, TUnderlying>.Instance;
            flagCalculator = EnumFlags<TUnderlying>.Instance;
            comparer = Comparer<TUnderlying>.Default;

            DeclaredMembers = InitializeMembers();
            membersByUnderlyingValue = InitializeMembersByUnderlyingValue();
            memberByUnderlyingValue = InitializeMemberByUnderlyingValue();

            Default = InitializeDefault();

            bits = InitializeBits();
            minValue = InitializeMinValue();
            maxValue = InitializeMaxValue();
        }

        private protected EnumInfo(string name, TEnum value)
            : base(name, value)
        {
            UnderlyingValue = converter.ToUnderlyingType(value);
            UInt64Value = converter.ToUInt64(UnderlyingValue);

            flags = Array.Empty<EnumInfo<TEnum, TUnderlying>>().AsReadOnly();
        }

        public static new ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> DeclaredMembers { get; private set; }

        public static new ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> DeclaredMembersExcludingSynonyms =>
            memberByUnderlyingValue.Values.ToList().AsReadOnly();

        public static new EnumInfo<TEnum, TUnderlying> Default { get; private set; }

        public TUnderlying UnderlyingValue { get; private set; }

        public bool IsBit { get; private set; }

        public override string ToString()
        {
            return Name.DefaultIfNullOrWhiteSpace($"{UnderlyingValue}");
        }

        private protected override string DebuggerDisplayValue =>
            HasFlagsAttribute && flags.Count > 0
                ? $"{TypeHelper.GetTypeName(EnumType)}.({Name}) = [{UnderlyingValue}]"
                : $"{TypeHelper.GetTypeName(EnumType)}.{Name.DefaultIfNullOrWhiteSpace("__Unnamed__")} = [{UnderlyingValue}]";

        private static bool TryGetNames(string? name, bool throwOnFailure, [NotNullWhen(true)] out string[]? names)
        {
            names = default;

            if (name.IsNullOrWhiteSpace())
            {
                return
                    throwOnFailure
                        ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, string>(name)
                        : false;
            }

            names = GetNames(name);

            if (names.Length == 0)
            {
                return
                    throwOnFailure
                        ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, string>(name)
                        : false;
            }

            var invalidNames =
                names
                    .Except(FieldsByEnumMemberName.Keys, StringComparer.OrdinalIgnoreCase)
                    .ToList();

            return
                invalidNames.Count <= 0
                ||
                (
                    throwOnFailure
                        ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, string>(name, invalidNames)
                        : false
                );
        }

        private static string[] GetNames(string name)
        {
            return
#if NET5_0_OR_GREATER
                name.Split(Chars.Comma, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
#else
#if NETFRAMEWORK || NETSTANDARD2_0
                name.Split(NameSeparators, StringSplitOptions.RemoveEmptyEntries)
#else
                name.Split(Chars.Comma, StringSplitOptions.RemoveEmptyEntries)
#endif
                    .Select(value => value.Trim())
                    .Where(value => String.Empty != value)
#endif
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToArray();
        }

        private static TUnderlying[] GetUnderlyingValuesFromNames(string[] names)
        {
            return
                membersByUnderlyingValue
                    .SelectMany(kvp => kvp.Value)
                    .Join(
                        names,
                        member => member.Name,
                        name => name,
                        (member, name) => member.UnderlyingValue,
                        StringComparer.OrdinalIgnoreCase
                    )
                    .SelectMany(
                        underlyingValue =>
                            HasFlagsAttribute
                                ? flagCalculator.Deconstruct(underlyingValue)
                                : underlyingValue.AsSingleElementSequence()
                    )
                    .Distinct()
                    .ToArray();
        }

        private static bool TryFromUnderlyingValueCore<TOriginal>(
            TOriginal originalValue,
            TUnderlying underlyingValue,
            bool throwOnFailure,
            [NotNullWhen(true)]
            out EnumInfo<TEnum, TUnderlying>? result,
            [CallerArgumentExpression(nameof(originalValue))] string? paramName = null
        )
        {
            result = default;

            return
                IsValidUnderlyingValue(underlyingValue)
                    ? HasFlagsAttribute
                        ? TryCreateInstance(originalValue, throwOnFailure, out result, flagCalculator.Deconstruct(underlyingValue))
                        : TryCreateInstance(originalValue, throwOnFailure, out result, underlyingValue)
                    : throwOnFailure
                        ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, TOriginal>(originalValue, paramName: paramName)
                        : false;
        }

        private static bool IsValidUnderlyingValue(TUnderlying underlyingValue)
        {
            return
                comparer.Compare(underlyingValue, default) == 0
                ||
                (
                    comparer.Compare(underlyingValue, maxValue) <= 0
                    &&
                    comparer.Compare(underlyingValue, minValue) >= 0
                );
        }

        private static bool TryCreateInstance<TOriginal>(
            TOriginal originalValue,
            bool throwOnFailure,
            [NotNullWhen(true)]
            out EnumInfo<TEnum, TUnderlying>? result,
            params TUnderlying[] flags
        )
        {
            result = default;

            TUnderlying[] nonZeroFlags =
                flags
                    .Where(flag => !IsZeroFlag(flag))
                    .ToArray();

            ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> selectedMembers =
                nonZeroFlags
                    .Select(flag => memberByUnderlyingValue.TryGetValue(flag, out EnumInfo<TEnum, TUnderlying>? member) ? member : null)
                    .OfType<EnumInfo<TEnum, TUnderlying>>()
                    .ToList()
                    .AsReadOnly();

            switch (selectedMembers.Count)
            {
                case 0:
                {
                    if (flags.Length == 0 || (flags.Length == 1 && IsZeroFlag(flags[0])))
                    {
                        result = Default;
                        break;
                    }

                    return
                        throwOnFailure
                            ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, TOriginal>(originalValue)
                            : false;
                }

                case 1:
                {
                    result = selectedMembers[0];
                    break;
                }

                default:
                {
                    if (!HasFlagsAttribute)
                    {
                        return
                            throwOnFailure
                                ? throw InvalidOperationExceptions.EnumTypeWithNoFlagsAttribute<TEnum>()
                                : false;
                    }

                    var invalidFlags =
                        nonZeroFlags
                            .Except(selectedMembers.Select(member => member.UnderlyingValue))
                            .ToList();

                    if (invalidFlags.Count > 0)
                    {
                        return
                            throwOnFailure
                                ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, TUnderlying>(originalValue, invalidFlags)
                                : false;
                    }

                    TUnderlying bitwiseOrValue = flagCalculator.Construct(nonZeroFlags);

                    if (memberByUnderlyingValue.TryGetValue(bitwiseOrValue, out EnumInfo<TEnum, TUnderlying>? member))
                    {
                        result = member;
                        break;
                    }

                    string name =
                        String.Join(
                            Strings.CommaSpaceSeparator,
                            selectedMembers.Select(selectedMember => selectedMember.Name)
                        );

                    TEnum value = converter.ToEnumType(ref bitwiseOrValue);

                    result = CreateSpecialInstance(name, value, selectedMembers);
                    break;
                }
            }

            return true;
        }

        private static EnumInfo<TEnum, TUnderlying> CreateInstance(params TUnderlying[] flags)
        {
            TryCreateInstance(flags, throwOnFailure: true, out EnumInfo<TEnum, TUnderlying>? result, flags);
            return result!;
        }

        private static bool IsZeroFlag(TUnderlying flag)
        {
            return comparer.Compare(flag, default) == 0;
        }

        private static EnumInfo<TEnum, TUnderlying> CreateSpecialInstance(
            string name,
            TEnum value,
            ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>>? flags = null
        )
        {
            if (Activator.CreateInstance(EnumInfoType, name, value) is not EnumInfo<TEnum, TUnderlying> instance)
            {
                throw InvalidOperationExceptions.CreateEnumInfoInstanceFailed(EnumInfoType, value);
            }

            instance.flags = flags ?? Array.Empty<EnumInfo<TEnum, TUnderlying>>().AsReadOnly();

            instance.SerializedValue = EnumValueSerializer.Current.Serialize(instance);

            return instance;
        }
    }
}
