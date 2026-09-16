// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

using EgonsoftHU.Extensions.Bcl.Enumerations;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="DateTimeOffset"/> type.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Removes the fractional seconds from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> value from which to remove the fractional seconds.</param>
        /// <returns>A <see cref="DateTimeOffset"/> value with no fractional seconds.</returns>
        public static DateTimeOffset ToSecondPrecision(this DateTimeOffset value)
        {
            TimeSpan timeOfDay = value.TimeOfDay;

            return value.Subtract(timeOfDay).AddSeconds((int)timeOfDay.TotalSeconds);
        }

        /// <summary>
        /// Removes the seconds and the fractional seconds from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> value from which to remove the seconds and the fractional seconds.</param>
        /// <returns>A <see cref="DateTimeOffset"/> value with zero seconds.</returns>
        public static DateTimeOffset ToMinutePrecision(this DateTimeOffset value)
        {
            TimeSpan timeOfDay = value.TimeOfDay;

            return value.Subtract(timeOfDay).AddMinutes((int)timeOfDay.TotalMinutes);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="DateTimeOffset"/> value is in the specified interval.
        /// </summary>
        /// <param name="value">The value to compare against the lower bound and the upper bound.</param>
        /// <param name="lowerBound">The beginning of the time interval.</param>
        /// <param name="upperBound">The end of the time interval.</param>
        /// <param name="options">Specifies whether to treat the lower and upper bounds as inclusive or exclusive. By default, both are treated as inclusive.</param>
        /// <returns><see langword="true"/>, if <paramref name="value"/> is in the specified interval; otherwise, <see langword="false"/>.</returns>
        public static bool IsInRange(
            this DateTimeOffset value,
            DateTimeOffset lowerBound,
            DateTimeOffset upperBound,
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
