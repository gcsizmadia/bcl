// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;

namespace EgonsoftHU.Extensions.Bcl.Internals
{
    internal static class NotSupportedExceptions
    {
        [SuppressMessage(SonarQube.Category, SonarQube.S3218)]
        private static class MessageTemplates
        {
            internal const string NotSupportedEnumTypeCode = "Not supported enumeration type code.";

            internal const string NotSupportedEnumUnderlyingType = "Not supported enumeration underlying type.";

            internal const string SeekNotSupported = "The specified stream does not support seeking.";
        }

        internal static NotSupportedException NotSupportedEnumTypeCode<TEnum>(TypeCode typeCode)
            where TEnum : struct, Enum
        {
            var ex = new NotSupportedException(MessageTemplates.NotSupportedEnumTypeCode);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName<TEnum>();
            ex.Data[ExceptionDataKeys.TypeCode] = typeCode;

            return ex;
        }

        internal static NotSupportedException NotSupportedEnumUnderlyingType<TUnderlying>()
            where TUnderlying : struct
        {
            var ex = new NotSupportedException(MessageTemplates.NotSupportedEnumUnderlyingType);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName<TUnderlying>();

            return ex;
        }

        internal static NotSupportedException SeekNotSupported(Type streamType)
        {
            var ex = new NotSupportedException(MessageTemplates.SeekNotSupported);

            ex.Data[ExceptionDataKeys.Type] = TypeHelper.GetTypeName(streamType);

            return ex;
        }
    }
}
