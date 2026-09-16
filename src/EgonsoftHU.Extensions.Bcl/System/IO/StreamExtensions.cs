// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.IO;
#if NETSTANDARD2_1 || NETCOREAPP2_1_OR_GREATER
using System.Threading;
#endif
using System.Threading.Tasks;

using EgonsoftHU.Extensions.Bcl.Exceptions;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="Stream"/> type.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Converts a stream to byte array using <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="stream">The stream to convert.</param>
        /// <returns>A byte array that contains the content of the <paramref name="stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        /// <exception cref="NotSupportedException"><paramref name="stream"/> does not support seeking.</exception>
        public static byte[] ToByteArray(this Stream stream)
        {
            stream.ThrowIfNull();

            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            if (!stream.TryResetStreamPosition())
            {
                throw NotSupportedExceptions.SeekNotSupported(stream.GetType());
            }

            using var resultStream = new MemoryStream();

            stream.CopyTo(resultStream);
            stream.TryResetStreamPosition();

            return resultStream.ToArray();
        }

#if NETSTANDARD2_1 || NETCOREAPP2_1_OR_GREATER
        /// <summary>
        /// Converts a stream to byte array using <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="stream">The stream to convert.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A byte array that contains the content of the <paramref name="stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        /// <exception cref="NotSupportedException"><paramref name="stream"/> does not support seeking.</exception>
        public static async Task<byte[]> ToByteArrayAsync(this Stream stream, CancellationToken cancellationToken = default)
#else
        /// <summary>
        /// Converts a stream to byte array using <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="stream">The stream to convert.</param>
        /// <returns>A byte array that contains the content of the <paramref name="stream"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        /// <exception cref="NotSupportedException"><paramref name="stream"/> does not support seeking.</exception>
        public static async Task<byte[]> ToByteArrayAsync(this Stream stream)
#endif
        {
            stream.ThrowIfNull();

            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            if (!stream.TryResetStreamPosition())
            {
                throw NotSupportedExceptions.SeekNotSupported(stream.GetType());
            }

            using (memoryStream = new MemoryStream())
            {
#if NETSTANDARD2_1 || NETCOREAPP2_1_OR_GREATER
                await stream.CopyToAsync(memoryStream, cancellationToken);
#else
                await stream.CopyToAsync(memoryStream);
#endif
                stream.TryResetStreamPosition();

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Sets the position to the beginning within the current stream.
        /// A return value indicates whether seeking succeeded.
        /// </summary>
        /// <param name="stream">A stream the position of which should be reset.</param>
        /// <returns><see langword="true"/> if seeking was successful; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
        public static bool TryResetStreamPosition(this Stream stream)
        {
            stream.ThrowIfNull();

            return
                stream.CanSeek
                &&
                stream.Seek(0, SeekOrigin.Begin) == 0;
        }
    }
}
