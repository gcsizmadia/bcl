// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Globalization;

namespace EgonsoftHU.Extensions.Bcl.Constants
{
    /// <summary>
    /// Contains format strings that indicate how to format the value of either a <see cref="DateTime"/> or <see cref="DateTimeOffset"/>.
    /// </summary>
    public static class DateTimeFormats
    {
        /// <summary>
        /// <see cref="DateTime"/> or <see cref="DateTimeOffset"/> in ISO 8601 format, e.g. <c>2024-01-01T12:34.56.1234567+01:00</c>
        /// </summary>
        /// <remarks>
        /// The <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#the-round-trip-o-o-format-specifier">"O" or "o" standard format specifier</see>
        /// represents a custom date and time format string using a pattern that preserves time zone information and
        /// emits a result string that complies with ISO 8601.
        /// </remarks>
        public const string Iso8601 = "O";

        /// <summary>
        /// <see cref="DateTime"/> or <see cref="DateTimeOffset"/> in RFC 1123 format, e.g. <c>Mon, 01 Jan 2024 12:34:56 GMT</c>
        /// </summary>
        /// <remarks>
        /// The <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#the-rfc1123-r-r-format-specifier">"R" or "r" standard format specifier</see>
        /// represents a custom date and time format string that's defined by the <see cref="DateTimeFormatInfo.RFC1123Pattern"/> property.
        /// </remarks>
        public const string Rfc1123 = "R";

        /// <summary>
        /// The date part of a <see cref="DateTime"/> or <see cref="DateTimeOffset"/> in ISO 8601 format, e.g. <c>2024-01-01</c>
        /// </summary>
        public const string DateOnly = "yyyy-MM-dd";

        /// <summary>
        /// <see cref="DateTime"/> or <see cref="DateTimeOffset"/> in <c>yyyy-MM-dd HH:mm:ss</c> format, e.g. <c>2024-01-01 12:34:56</c>
        /// </summary>
        public const string DateTimeWithSecondPrecision = "yyyy-MM-dd HH:mm:ss";
    }
}
