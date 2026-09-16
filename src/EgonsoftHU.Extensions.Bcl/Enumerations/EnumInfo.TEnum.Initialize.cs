// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

using EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Enums;

namespace EgonsoftHU.Extensions.Bcl.Enumerations
{
    public partial class EnumInfo<TEnum>
    {
        private static ReadOnlyDictionary<Type, Func<Type, Type>> InitializeConcreteTypeFactoryByUnderlyingType()
        {
            return
                new(
                    new Dictionary<Type, Func<Type, Type>>()
                    {
                        [typeof(sbyte)] = enumType => typeof(SByteEnumInfo<>).MakeGenericType(enumType),
                        [typeof(short)] = enumType => typeof(Int16EnumInfo<>).MakeGenericType(enumType),
                        [typeof(int)] = enumType => typeof(Int32EnumInfo<>).MakeGenericType(enumType),
                        [typeof(long)] = enumType => typeof(Int64EnumInfo<>).MakeGenericType(enumType),
                        [typeof(byte)] = enumType => typeof(ByteEnumInfo<>).MakeGenericType(enumType),
                        [typeof(ushort)] = enumType => typeof(UInt16EnumInfo<>).MakeGenericType(enumType),
                        [typeof(uint)] = enumType => typeof(UInt32EnumInfo<>).MakeGenericType(enumType),
                        [typeof(ulong)] = enumType => typeof(UInt64EnumInfo<>).MakeGenericType(enumType),
                    }
                );
        }

        private static ReadOnlyDictionary<string, FieldInfo> InitializeFieldsByEnumMemberName()
        {
            return
                EnumTypeInfo
                    .DeclaredFields
                    .Where(
                        fieldInfo =>
                            fieldInfo.IsPublic
                            &&
                            fieldInfo.IsStatic
                            &&
                            fieldInfo.FieldType == EnumType
                    )
                    .ToDictionary(fieldInfo => fieldInfo.Name, StringComparer.OrdinalIgnoreCase)
                    .AsReadOnly();
        }
    }
}
