// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

namespace System.Diagnostics.CodeAnalysis
{
    internal static class SonarQube
    {
        internal const string Category = nameof(SonarQube);

        /// <summary>
        /// Floating point numbers should not be tested for equality
        /// </summary>
        internal const string S1244 = nameof(S1244);

        /// <summary>
        /// Flags enumerations zero-value members should be named "None"
        /// </summary>
        internal const string S2346 = nameof(S2346);

        /// <summary>
        /// Static fields should not be used in generic types
        /// </summary>
        internal const string S2743 = nameof(S2743);

        /// <summary>
        /// Inner class members should not shadow outer class "static" or type members
        /// </summary>
        internal const string S3218 = nameof(S3218);

        /// <summary>
        /// <c>static</c> fields should be initialized inline
        /// </summary>
        internal const string S3963 = nameof(S3963);
    }
}
