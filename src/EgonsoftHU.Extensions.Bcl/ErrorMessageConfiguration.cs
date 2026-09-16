// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

using EgonsoftHU.Extensions.Bcl.Constants;
using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// Controls the error messages for extension methods in this assembly that throw <see cref="ArgumentException"/> or <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    public class ErrorMessageConfiguration
    {
        private static readonly Dictionary<string, ErrorMessageProviderAttribute> errorMessages =
            new()
            {
                [ErrorMessageKey.Argument_EmptyEnumerable] =
                    new()
                    {
                        ErrorMessage = "The value cannot be an empty sequence."
                    },
                [ErrorMessageKey.Argument_EmptyGuid] =
                    new()
                    {
                        ErrorMessage = "The value cannot be an empty Guid."
                    },
                [ErrorMessageKey.Argument_EmptyString] =
                    new()
                    {
                        ErrorMessage = "The value cannot be an empty string."
                    },
                [ErrorMessageKey.Argument_EmptyOrWhiteSpaceString] =
                    new()
                    {
                        ErrorMessage = "The value cannot be an empty string or composed entirely of whitespace."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeNonZero] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be a non-zero value."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeNonNegative] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be a non-negative value."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeNonNegativeNonZero] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be a non-negative and non-zero value."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeNonPositive] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be a non-positive value."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeNonPositiveNonZero] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be a non-positive and non-zero value."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeLess] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be less than '{2}'."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeLessOrEqual] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be less than or equal to '{2}'."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeGreater] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be greater than '{2}'."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeGreaterOrEqual] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be greater than or equal to '{2}'."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeEqual] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must be equal to '{2}'."
                    },
                [ErrorMessageKey.ArgumentOutOfRange_MustBeNotEqual] =
                    new()
                    {
                        ErrorMessage = "{0} ('{1}') must not be equal to '{2}'."
                    }
            };

        private ErrorMessageConfiguration()
        {
        }

        /// <summary>
        /// Gets the current error message configuration.
        /// </summary>
        public static ErrorMessageConfiguration Current { get; } = new();

        /// <summary>
        /// Replaces the default error message with <paramref name="errorMessage"/> for the error specified by <paramref name="errorMessageKey"/>.
        /// </summary>
        /// <param name="errorMessageKey">The key that identifies an error message.</param>
        /// <param name="errorMessage">The explicit error message string.</param>
        /// <remarks>
        /// This method is intended to be used for non-localizable error messages.<br/>
        /// Use <see cref="ConfigureErrorMessage(String, Type, String)"/> for localizable error messages.
        /// </remarks>
#if NET6_0_OR_GREATER
        [SuppressMessage("Performance", "CA1822:Mark members as static")]
#endif
        public void ConfigureErrorMessage(string errorMessageKey, string errorMessage)
        {
            errorMessageKey.ThrowIfNullOrWhiteSpace();
            errorMessage.ThrowIfNullOrWhiteSpace();

            ThrowIfKeyNotFound(errorMessageKey);

            errorMessages[errorMessageKey] = new() { ErrorMessage = errorMessage };
        }

        /// <summary>
        /// Replaces the default error message for the error specified by <paramref name="errorMessageKey"/> using resource.
        /// </summary>
        /// <param name="errorMessageKey">The key that identifies an error message.</param>
        /// <param name="errorMessageResourceType">The resource type to use for error message lookups.</param>
        /// <param name="errorMessageResourceName">The resource name (property name) to use as the key for lookups on the resource type.</param>
        /// <remarks>
        /// This method is intended to be used for localizable error messages.<br/>
        /// Use <see cref="ConfigureErrorMessage(String, String)"/> for non-localized error messages.
        /// <para>
        /// If <paramref name="errorMessageResourceName"/> is <see langword="null"/>, <see cref="String.Empty"/>,
        /// or if <paramref name="errorMessageResourceName"/> consists exclusively of white-space characters
        /// then the value of <paramref name="errorMessageKey"/> will be used.
        /// </para>
        /// </remarks>
#if NET6_0_OR_GREATER
        [SuppressMessage("Performance", "CA1822:Mark members as static")]
#endif
        public void ConfigureErrorMessage(string errorMessageKey, Type errorMessageResourceType, string? errorMessageResourceName = null)
        {
            errorMessageKey.ThrowIfNullOrWhiteSpace();
            errorMessageResourceType.ThrowIfNull();

            if (errorMessageResourceName.IsNullOrWhiteSpace())
            {
                errorMessageResourceName = errorMessageKey;
            }

            ThrowIfKeyNotFound(errorMessageKey);

            errorMessages[errorMessageKey] =
                new()
                {
                    ErrorMessageResourceType = errorMessageResourceType,
                    ErrorMessageResourceName = errorMessageResourceName
                };
        }

        internal static string Argument_EmptyEnumerable<T>(string? paramName, IEnumerable<T> value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string Argument_EmptyGuid(string? paramName, Guid value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string Argument_EmptyString(string? paramName, string value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string Argument_EmptyOrWhiteSpaceString<T>(string? paramName, T value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string ArgumentOutOfRange_MustBeNonZero<T>(string? paramName, T value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string ArgumentOutOfRange_MustBeNonNegative<T>(string? paramName, T value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string ArgumentOutOfRange_MustBeNonNegativeNonZero<T>(string? paramName, T value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string ArgumentOutOfRange_MustBeNonPositive<T>(string? paramName, T value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string ArgumentOutOfRange_MustBeNonPositiveNonZero<T>(string? paramName, T value)
        {
            return FormatErrorMessage(paramName, value);
        }

        internal static string ArgumentOutOfRange_MustBeLess<T>(string? paramName, T value, T other)
        {
            return FormatErrorMessage(paramName, value, other);
        }

        internal static string ArgumentOutOfRange_MustBeLessOrEqual<T>(string? paramName, T value, T other)
        {
            return FormatErrorMessage(paramName, value, other);
        }

        internal static string ArgumentOutOfRange_MustBeGreater<T>(string? paramName, T value, T other)
        {
            return FormatErrorMessage(paramName, value, other);
        }

        internal static string ArgumentOutOfRange_MustBeGreaterOrEqual<T>(string? paramName, T value, T other)
        {
            return FormatErrorMessage(paramName, value, other);
        }

        internal static string ArgumentOutOfRange_MustBeEqual<T>(string? paramName, T value, T other)
        {
            return FormatErrorMessage(paramName, (object?)value ?? Strings.NullString, (object?)other ?? Strings.NullString);
        }

        internal static string ArgumentOutOfRange_MustBeNotEqual<T>(string? paramName, T value, T other)
        {
            return FormatErrorMessage(paramName, (object?)value ?? Strings.NullString, (object?)other ?? Strings.NullString);
        }

        private static string FormatErrorMessage<T>(string? paramName, T value, [CallerMemberName] string? errorMessageKey = null)
        {
            errorMessageKey.ThrowIfNullOrWhiteSpace();
            ThrowIfKeyNotFound(errorMessageKey);

            return errorMessages[errorMessageKey].FormatErrorMessage(paramName, value);
        }

        private static string FormatErrorMessage<T>(string? paramName, T value, T other, [CallerMemberName] string? errorMessageKey = null)
        {
            errorMessageKey.ThrowIfNullOrWhiteSpace();
            ThrowIfKeyNotFound(errorMessageKey);

            return errorMessages[errorMessageKey].FormatErrorMessage(paramName, value, other);
        }

        private static void ThrowIfKeyNotFound(string errorMessageKey)
        {
            if (!errorMessages.ContainsKey(errorMessageKey))
            {
                ThrowKeyNotFoundException(errorMessageKey);
            }
        }

        [DoesNotReturn]
        private static void ThrowKeyNotFoundException(string errorMessageKey)
        {
            throw KeyNotFoundExceptions.KeyNotFound(errorMessageKey);
        }

        private sealed class ErrorMessageProviderAttribute : ValidationAttribute
        {
            internal string FormatErrorMessage(params object?[] args)
            {
                return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, args);
            }
        }
    }
}
