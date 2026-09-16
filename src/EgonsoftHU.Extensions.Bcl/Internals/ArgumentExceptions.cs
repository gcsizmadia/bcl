// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Text;
#endif

namespace EgonsoftHU.Extensions.Bcl.Internals
{
    internal static class ArgumentExceptions
    {
        [SuppressMessage(SonarQube.Category, SonarQube.S3218)]
        private static class MessageTemplates
        {
#if NET8_0_OR_GREATER
            internal static readonly CompositeFormat ArgumentMustBeOfType = CompositeFormat.Parse("Object must be of type: '{0}'");
#else
            internal const string ArgumentMustBeOfType = "Object must be of type: '{0}'";
#endif

            internal const string CollectionIsReadOnly = "The collection is read-only.";

            internal const string EnumMemberNotFound = "Enum member not found.";

            internal const string PropertyNotFound = "No property with the specified name is declared in the current type.";
        }

        internal static ArgumentException ArgumentMustBeOfType<TRequired>(
            object? paramValue,
            [CallerArgumentExpression(nameof(paramValue))] string? paramName = null
        )
        {
            return ArgumentMustBeOfType(typeof(TRequired), paramValue, paramName);
        }

        internal static ArgumentException ArgumentMustBeOfType(
            Type requiredType,
            object? paramValue,
            [CallerArgumentExpression(nameof(paramValue))] string? paramName = null
        )
        {
            var ex =
                new ArgumentException(
                    String.Format(
                        CultureInfo.CurrentCulture,
                        MessageTemplates.ArgumentMustBeOfType,
                        TypeHelper.GetTypeName(requiredType)
                    ),
                    paramName
                );

            ex.Data[ExceptionDataKeys.RequiredType] = TypeHelper.GetTypeName(requiredType);

            ex.Data[ExceptionDataKeys.ActualType] =
                paramValue is null
                    ? Type.Missing.ToString()
                    : TypeHelper.GetTypeName(paramValue.GetType());

            return ex;
        }

        internal static ArgumentException CollectionIsReadOnly(string paramName)
        {
            var ex = new ArgumentException(MessageTemplates.CollectionIsReadOnly, paramName);

            return ex;
        }

        internal static ArgumentException EnumMemberNotFound<TEnum, TInvalid>(
            object? paramValue,
            List<TInvalid>? invalidValues = null,
            [CallerArgumentExpression(nameof(paramValue))] string? paramName = null
        )
            where TEnum : struct, Enum
        {
            var ex = new ArgumentException(MessageTemplates.EnumMemberNotFound, paramName);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName<TEnum>();
            ex.Data[ExceptionDataKeys.OriginalValue] = paramValue;
            ex.Data[ExceptionDataKeys.InvalidValues] = invalidValues;

            return ex;
        }

        internal static ArgumentException PropertyNotFound(Type sourceType, string propertyName)
        {
            var ex = new ArgumentException(MessageTemplates.PropertyNotFound, nameof(propertyName));

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName(sourceType);
            ex.Data[ExceptionDataKeys.PropertyName] = propertyName;

            return ex;
        }
    }
}
