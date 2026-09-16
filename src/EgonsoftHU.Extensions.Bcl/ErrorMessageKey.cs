// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// The keys that identify error messages.
    /// </summary>
    public static class ErrorMessageKey
    {
        /// <summary>
        /// The default error message template for this error is:<br/><c>The value cannot be an empty sequence.</c>
        /// </summary>
        public const string Argument_EmptyEnumerable = nameof(Argument_EmptyEnumerable);

        /// <summary>
        /// The default error message template for this error is:<br/><c>The value cannot be an empty Guid.</c>
        /// </summary>
        public const string Argument_EmptyGuid = nameof(Argument_EmptyGuid);

        /// <summary>
        /// The default error message template for this error is:<br/><c>The value cannot be an empty string.</c>
        /// </summary>
        public const string Argument_EmptyString = nameof(Argument_EmptyString);

        /// <summary>
        /// The default error message template for this error is:<br/><c>The value cannot be an empty string or composed entirely of whitespace.</c>
        /// </summary>
        public const string Argument_EmptyOrWhiteSpaceString = nameof(Argument_EmptyOrWhiteSpaceString);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be a non-zero value.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeNonZero = nameof(ArgumentOutOfRange_MustBeNonZero);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be a non-negative value.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeNonNegative = nameof(ArgumentOutOfRange_MustBeNonNegative);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be a non-negative and non-zero value.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeNonNegativeNonZero = nameof(ArgumentOutOfRange_MustBeNonNegativeNonZero);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be a non-positive value.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeNonPositive = nameof(ArgumentOutOfRange_MustBeNonPositive);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be a non-positive and non-zero value.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeNonPositiveNonZero = nameof(ArgumentOutOfRange_MustBeNonPositiveNonZero);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be less than '{2}'.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeLess = nameof(ArgumentOutOfRange_MustBeLess);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be less than or equal to '{2}'.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeLessOrEqual = nameof(ArgumentOutOfRange_MustBeLessOrEqual);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be greater than '{2}'.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeGreater = nameof(ArgumentOutOfRange_MustBeGreater);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be greater than or equal to '{2}'.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeGreaterOrEqual = nameof(ArgumentOutOfRange_MustBeGreaterOrEqual);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must be equal to '{2}'.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeEqual = nameof(ArgumentOutOfRange_MustBeEqual);

        /// <summary>
        /// The default error message template for this error is:<br/><c>{0} ('{1}') must not be equal to '{2}'.</c>
        /// </summary>
        public const string ArgumentOutOfRange_MustBeNotEqual = nameof(ArgumentOutOfRange_MustBeNotEqual);
    }
}
