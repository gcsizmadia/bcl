// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace EgonsoftHU.Extensions.Bcl.Internals
{
    internal static class InvalidOperationExceptions
    {
        [SuppressMessage(SonarQube.Category, SonarQube.S3218)]
        private static class MessageTemplates
        {
            internal const string CreateEnumFlagsInstanceFailed =
                "Create an instance of a type that implements IEnumFlags<TUnderlying> interface failed.";

            internal const string CreateEnumInfoInstanceFailed =
                "Create an instance of the EnumInfo<TEnum> type failed.";

            internal const string EnumTypeWithNoFlagsAttribute =
                "No System.FlagsAttribute is applied to the current enumeration type.";

            internal const string PropertyValueNotSet =
                "The property value is not set.";
        }

        internal static InvalidOperationException CreateEnumFlagsInstanceFailed<TUnderlying>(Type concreteType)
            where TUnderlying : struct
        {
            var ex = new InvalidOperationException(MessageTemplates.CreateEnumFlagsInstanceFailed);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName(concreteType);
            ex.Data[ExceptionDataKeys.EnumUnderlyingType] = TypeHelper.GetTypeName<TUnderlying>();

            return ex;
        }

        internal static InvalidOperationException CreateEnumInfoInstanceFailed<TEnum>(Type concreteType, TEnum value)
            where TEnum : struct, Enum
        {
            var ex = new InvalidOperationException(MessageTemplates.CreateEnumInfoInstanceFailed);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName(concreteType);
            ex.Data[ExceptionDataKeys.EnumType] = TypeHelper.GetTypeName<TEnum>();
            ex.Data[ExceptionDataKeys.OriginalValue] = value;

            return ex;
        }

        internal static InvalidOperationException CreateEnumInfoInstanceFailed<TEnum, TUnderlying>(Type concreteType, TUnderlying value)
            where TEnum : struct, Enum
            where TUnderlying : struct
        {
            var ex = new InvalidOperationException(MessageTemplates.CreateEnumInfoInstanceFailed);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName(concreteType);
            ex.Data[ExceptionDataKeys.EnumType] = TypeHelper.GetTypeName<TEnum>();
            ex.Data[ExceptionDataKeys.EnumUnderlyingType] = TypeHelper.GetTypeName<TUnderlying>();
            ex.Data[ExceptionDataKeys.OriginalValue] = value;

            return ex;
        }

        internal static InvalidOperationException CreateEnumValueConverterInstanceFailed<TEnum, TUnderlying>(Type concreteType)
            where TEnum : struct, Enum
            where TUnderlying : struct
        {
            var ex = new InvalidOperationException(MessageTemplates.CreateEnumFlagsInstanceFailed);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName(concreteType);
            ex.Data[ExceptionDataKeys.EnumType] = TypeHelper.GetTypeName<TEnum>();
            ex.Data[ExceptionDataKeys.EnumUnderlyingType] = TypeHelper.GetTypeName<TUnderlying>();

            return ex;
        }

        internal static InvalidOperationException EnumTypeWithNoFlagsAttribute<TEnum>()
            where TEnum : struct, Enum
        {
            var ex = new InvalidOperationException(MessageTemplates.EnumTypeWithNoFlagsAttribute);

            ex.Data[ExceptionDataKeys.EnumType] = TypeHelper.GetTypeName<TEnum>();

            return ex;
        }

        internal static InvalidOperationException PropertyValueNotSet<TProperty>([CallerMemberName] string? propertyName = null)
        {
            var ex = new InvalidOperationException(MessageTemplates.PropertyValueNotSet);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName<TProperty>();
            ex.Data[ExceptionDataKeys.PropertyName] = propertyName;

            return ex;
        }
    }
}
