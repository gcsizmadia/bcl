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
using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    [SuppressMessage(SonarQube.Category, SonarQube.S3963)]
    internal abstract partial class EnumInfo<TEnum, TUnderlying> : EnumInfo<TEnum>
        where TEnum : struct, Enum
        where TUnderlying : struct, IConvertible, IComparable<TUnderlying>
    {
        private static readonly IEnumValueConverter<TEnum, TUnderlying> Converter;

        private static readonly IEnumFlags<TUnderlying> FlagCalculator;

        private static readonly Comparer<TUnderlying> Comparer;

        private static readonly ReadOnlyCollection<TUnderlying> Bits;

        private static readonly TUnderlying MinValue;

        private static readonly TUnderlying MaxValue;

#if NETFRAMEWORK || NETSTANDARD2_0
        private static readonly char[] NameSeparators = new[] { Chars.Comma };
#endif

        private static readonly ReadOnlyDictionary<TUnderlying, List<EnumInfo<TEnum, TUnderlying>>> MembersByUnderlyingValue;

        private static readonly ReadOnlyDictionary<TUnderlying, EnumInfo<TEnum, TUnderlying>> MemberByUnderlyingValue;

        private ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> flags;

        static EnumInfo()
        {
            Converter = EnumValueConverter<TEnum, TUnderlying>.Instance;
            FlagCalculator = EnumFlags<TUnderlying>.Instance;
            Comparer = Comparer<TUnderlying>.Default;

            DeclaredMembers = InitializeMembers();
            MembersByUnderlyingValue = InitializeMembersByUnderlyingValue();
            MemberByUnderlyingValue = InitializeMemberByUnderlyingValue();

            Default = InitializeDefault();

            Bits = InitializeBits();
            MinValue = InitializeMinValue();
            MaxValue = InitializeMaxValue();
        }

        private protected EnumInfo(string name, TEnum value)
            : base(name, value)
        {
            UnderlyingValue = Converter.ToUnderlyingType(value);
            UInt64Value = Converter.ToUInt64(UnderlyingValue);

            flags = Array.Empty<EnumInfo<TEnum, TUnderlying>>().AsReadOnly();
        }

        public static new ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> DeclaredMembers { get; private set; }

        public static new ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> DeclaredMembersExcludingSynonyms =>
            MemberByUnderlyingValue.Values.ToList().AsReadOnly();

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
                MembersByUnderlyingValue
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
                                ? FlagCalculator.Deconstruct(underlyingValue)
#if NET8_0_OR_GREATER
                                : [underlyingValue]
#else
                                : underlyingValue.AsSingleElementSequence()
#endif
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

            if (IsValidUnderlyingValue(underlyingValue))
            {
                return
                    TryCreateInstance(
                        originalValue,
                        throwOnFailure,
                        out result,
                        HasFlagsAttribute
                            ? FlagCalculator.Deconstruct(underlyingValue)
#if LANGVERSION12_0_OR_GREATER
                            : [underlyingValue]
#else
                            : underlyingValue.AsSingleElementSequence().ToArray()
#endif
                    );
            }

            return
                throwOnFailure
                    ? throw ArgumentExceptions.EnumMemberNotFound<TEnum, TOriginal>(originalValue, paramName: paramName)
                    : false;
        }

        private static bool IsValidUnderlyingValue(TUnderlying underlyingValue)
        {
            return
                Comparer.Compare(underlyingValue, default) == 0
                ||
                (
                    Comparer.Compare(underlyingValue, MaxValue) <= 0
                    &&
                    Comparer.Compare(underlyingValue, MinValue) >= 0
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
                    .Select(flag => MemberByUnderlyingValue.TryGetValue(flag, out EnumInfo<TEnum, TUnderlying>? member) ? member : null)
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

                    return ThrowOrReturnFalse(throwOnFailure, ArgumentExceptions.EnumMemberNotFound<TEnum, TOriginal>(originalValue));
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
                        return ThrowOrReturnFalse(throwOnFailure, InvalidOperationExceptions.EnumTypeWithNoFlagsAttribute<TEnum>());
                    }

                    var invalidFlags =
                        nonZeroFlags
                            .Except(selectedMembers.Select(member => member.UnderlyingValue))
                            .ToList();

                    if (invalidFlags.Count > 0)
                    {
                        return ThrowOrReturnFalse(throwOnFailure, ArgumentExceptions.EnumMemberNotFound<TEnum, TUnderlying>(originalValue, invalidFlags));
                    }

                    TUnderlying bitwiseOrValue = FlagCalculator.Construct(nonZeroFlags);

                    if (MemberByUnderlyingValue.TryGetValue(bitwiseOrValue, out EnumInfo<TEnum, TUnderlying>? member))
                    {
                        result = member;
                        break;
                    }

                    string name =
                        String.Join(
                            Strings.CommaSpaceSeparator,
                            selectedMembers.Select(selectedMember => selectedMember.Name)
                        );

                    TEnum value = Converter.ToEnumType(bitwiseOrValue);

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
            return Comparer.Compare(flag, default) == 0;
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

            return instance;
        }

        private static bool ThrowOrReturnFalse([DoesNotReturnIf(true)] bool throwOnFailure, Exception ex)
        {
            return throwOnFailure ? throw ex : false;
        }
    }
}
