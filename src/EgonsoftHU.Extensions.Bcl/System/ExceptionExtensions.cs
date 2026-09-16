// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Net;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="Exception"/> type.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the HTTP status code from an exception.
        /// </summary>
        /// <param name="ex">The exception from which the HTTP status code should be retrieved.</param>
        /// <param name="defaultHttpStatusCode">The default HTTP status code, if the exception does not contain one.</param>
        /// <returns>
        /// An HTTP status code if it is either set for the <see cref="Exception"/> instance specified by the <paramref name="ex"/> parameter
        /// or specified by the <paramref name="defaultHttpStatusCode"/> parameter;
        /// otherwise, <see langword="null"/>.
        /// </returns>
        public static int? GetHttpStatusCode(this Exception ex, int? defaultHttpStatusCode = null)
        {
            ex.ThrowIfNull();

            return
                (int?)ex.Data[nameof(HttpStatusCode)]
                ??
                defaultHttpStatusCode;
        }

        /// <summary>
        /// Sets the HTTP status code for an exception.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="ex">The exception for which the HTTP status code will be set.</param>
        /// <param name="httpStatusCode">The HTTP status code to set.</param>
        /// <returns>
        /// A reference to the <see cref="Exception"/> instance (specified by the <paramref name="ex"/> parameter)
        /// this extension method was called on.
        /// </returns>
        public static TException SetHttpStatusCode<TException>(this TException ex, int httpStatusCode)
            where TException : Exception
        {
            ex.ThrowIfNull();

            ex.Data[nameof(HttpStatusCode)] = httpStatusCode;

            return ex;
        }
    }
}
