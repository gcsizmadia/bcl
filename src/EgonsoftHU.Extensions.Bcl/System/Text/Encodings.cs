// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Text;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// An encoding provider, which supplies UTF-8 encoding without the Unicode byte order mark.
    /// </summary>
    public static class Encodings
    {
        internal static readonly Lazy<Encoding> LazyUTF8EncodingWithoutBOM =
            new(() => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

        /// <summary>
        /// The UTF-8 encoding without the Unicode byte order mark.
        /// </summary>
        /// <remarks>
        /// <see cref="UTF8Encoding.GetPreamble"/> will return an empty byte array.
        /// </remarks>
#if NET10_0_OR_GREATER
        [Obsolete("Use System.Text.Encoding.UTF8WithoutBOM extension property instead.")]
#endif
        public static Encoding UTF8WithoutBOM => LazyUTF8EncodingWithoutBOM.Value;
    }
}
