// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using EgonsoftHU.Extensions.Bcl.Enumerations.Internals;
using EgonsoftHU.Extensions.Bcl.Enumerations.Serialization;
using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    internal partial class EnumInfo<TEnum, TUnderlying>
    {
        private static ReadOnlyCollection<EnumInfo<TEnum, TUnderlying>> InitializeMembers()
        {
            return
                FieldsByEnumMemberName
                    .Values
                    .Select(
                        field =>
                        {
                            string fieldName = field.Name;
                            var fieldValue = (TEnum)field.GetValue(null)!;

                            object? instance = Activator.CreateInstance(EnumInfoType, fieldName, fieldValue);

                            if (instance is not EnumInfo<TEnum, TUnderlying> enumeration)
                            {
                                return null;
                            }

                            enumeration.IsDefined = true;
                            enumeration.Attributes = new EnumerationAttributes(field);
                            enumeration.SerializedValue = EnumValueSerializer.Current.Serialize(enumeration);

                            enumeration.IsBit = flagCalculator.IsPowerOf2(enumeration.UnderlyingValue);

                            return enumeration;
                        }
                    )
                    .OfType<EnumInfo<TEnum, TUnderlying>>()
                    .ToList()
                    .AsReadOnly();
        }

        private static ReadOnlyDictionary<TUnderlying, List<EnumInfo<TEnum, TUnderlying>>> InitializeMembersByUnderlyingValue()
        {
            return
                DeclaredMembers
                    .GroupBy(member => member.UnderlyingValue)
                    .ToDictionary(group => group.Key, group => group.ToList())
                    .AsReadOnly();
        }

        private static ReadOnlyDictionary<TUnderlying, EnumInfo<TEnum, TUnderlying>> InitializeMemberByUnderlyingValue()
        {
            return
                membersByUnderlyingValue
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value[0])
                    .AsReadOnly();
        }

        private static EnumInfo<TEnum, TUnderlying> InitializeDefault()
        {
            TUnderlying defaultUnderlyingValue = converter.ToUnderlyingType(DefaultValue);

            if (membersByUnderlyingValue.TryGetValue(defaultUnderlyingValue, out List<EnumInfo<TEnum, TUnderlying>>? members))
            {
                members.ForEach(member => member.IsDefaultValue = true);

                return members[0];
            }

            if (Activator.CreateInstance(EnumInfoType, String.Empty, DefaultValue) is EnumInfo<TEnum, TUnderlying> enumeration)
            {
                enumeration.IsDefaultValue = true;

                return enumeration;
            }

            throw InvalidOperationExceptions.CreateEnumInfoInstanceFailed(EnumInfoType, DefaultValue);
        }

        private static ReadOnlyCollection<TUnderlying> InitializeBits()
        {
            return
                DeclaredMembers
                    .Where(member => member.IsBit)
                    .Select(member => member.UnderlyingValue)
                    .ToList()
                    .AsReadOnly();
        }

        private static TUnderlying InitializeMaxValue()
        {
            return
                HasFlagsAttribute
                    ? flagCalculator.Construct(
                        bits.Where(bit => comparer.Compare(bit, default) > 0)
                            .ToArray()
                    )
                    : memberByUnderlyingValue.Keys.Max();
        }

        private static TUnderlying InitializeMinValue()
        {
            return memberByUnderlyingValue.Keys.Min();
        }
    }
}
