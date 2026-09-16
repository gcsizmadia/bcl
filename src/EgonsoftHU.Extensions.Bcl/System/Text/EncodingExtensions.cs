// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NET10_0_OR_GREATER
using System.Text;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// <see cref="Encoding"/> extensions, e.g. extension property that provides UTF-8 encoding without the Unicode byte order mark.
    /// </summary>
    public static class EncodingExtensions
    {
        extension(Encoding encoding)
        {
            /// <summary>
            /// The UTF-8 encoding without the Unicode byte order mark.
            /// </summary>
            /// <remarks>
            /// <see cref="UTF8Encoding.GetPreamble"/> will return an empty byte array.
            /// </remarks>
            public static Encoding UTF8WithoutBOM => Encodings.LazyUTF8EncodingWithoutBOM.Value;
        }
    }
}
#endif
