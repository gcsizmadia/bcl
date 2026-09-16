// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NET6_0_OR_GREATER
using System;

using EgonsoftHU.Extensions.Bcl.Enumerations;
using EgonsoftHU.Extensions.Bcl.Internals;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="DateOnly"/> type.
    /// </summary>
    public static class DateOnlyExtensions
    {
        /// <summary>
        /// Indicates whether the specified <see cref="DateOnly"/> value is in the specified interval.
        /// </summary>
        /// <param name="value">The value to compare against the lower bound and the upper bound.</param>
        /// <param name="lowerBound">The beginning of the time interval.</param>
        /// <param name="upperBound">The end of the time interval.</param>
        /// <param name="options">Specifies whether to treat the lower and upper bounds as inclusive or exclusive. By default, both are treated as inclusive.</param>
        /// <returns><see langword="true"/>, if <paramref name="value"/> is in the specified interval; otherwise, <see langword="false"/>.</returns>
        public static bool IsInRange(
            this DateOnly value,
            DateOnly lowerBound,
            DateOnly upperBound,
            IntervalBoundsOptions options = default
        )
        {
            return
                (
                    options.HasFlag(IntervalBoundsOptions.LeftOpen)
                        ? value > lowerBound
                        : value >= lowerBound
                )
                &&
                (
                    options.HasFlag(IntervalBoundsOptions.RightOpen)
                        ? value < upperBound
                        : value <= upperBound
                );
        }
    }
}
#endif
