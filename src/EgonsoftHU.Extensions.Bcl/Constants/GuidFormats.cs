// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

namespace EgonsoftHU.Extensions.Bcl.Constants
{
    /// <summary>
    /// Contains single format specifiers that indicate how to format the value of a <see cref="Guid"/>.
    /// </summary>
    public static class GuidFormats
    {
        /// <summary>
        /// <see cref="Guid" /> in number format, e.g. <c>728022948a434ba9a3603498df3cb0c7</c>
        /// </summary>
        public const string Number = "N";

        /// <summary>
        /// <see cref="Guid" /> in digit format, e.g. <c>72802294-8a43-4ba9-a360-3498df3cb0c7</c>
        /// </summary>
        public const string Digit = "D";

        /// <summary>
        /// <see cref="Guid" /> in brace format, e.g. <c>{72802294-8a43-4ba9-a360-3498df3cb0c7}</c>
        /// </summary>
        public const string Brace = "B";

        /// <summary>
        /// <see cref="Guid" /> in parenthesis format, e.g. <c>(72802294-8a43-4ba9-a360-3498df3cb0c7)</c>
        /// </summary>
        public const string Parenthesis = "P";

        /// <summary>
        /// <see cref="Guid" /> in hexadecimal format, e.g. <c>{0x72802294,0x8a43,0x4ba9,{0xa3,0x60,0x34,0x98,0xdf,0x3c,0xb0,0xc7}}</c>
        /// </summary>
        public const string Hex = "X";
    }
}
