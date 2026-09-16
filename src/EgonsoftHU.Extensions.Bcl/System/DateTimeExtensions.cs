// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

using EgonsoftHU.Extensions.Bcl.Enumerations;

namespace EgonsoftHU.Extensions.Bcl
{
    /// <summary>
    /// This class contains extension methods that are available for <see cref="DateTime"/> type.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Removes the fractional seconds from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value from which to remove the fractional seconds.</param>
        /// <returns>A <see cref="DateTime"/> value with no fractional seconds.</returns>
        /// <remarks>The <see cref="DateTimeKind"/> setting is preserved.</remarks>
        public static DateTime ToSecondPrecision(this DateTime value)
        {
            TimeSpan timeOfDay = value.TimeOfDay;

            DateTime result = value.Subtract(timeOfDay).AddSeconds((int)timeOfDay.TotalSeconds);

            DateTime.SpecifyKind(result, value.Kind);

            return result;
        }

        /// <summary>
        /// Removes the seconds and the fractional seconds from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value from which to remove the seconds and the fractional seconds.</param>
        /// <returns>A <see cref="DateTime"/> value with zero seconds.</returns>
        /// <remarks>The <see cref="DateTimeKind"/> setting is preserved.</remarks>
        public static DateTime ToMinutePrecision(this DateTime value)
        {
            TimeSpan timeOfDay = value.TimeOfDay;

            DateTime result = value.Subtract(timeOfDay).AddMinutes((int)timeOfDay.TotalMinutes);

            DateTime.SpecifyKind(result, value.Kind);

            return result;
        }

        /// <summary>
        /// Indicates whether the specified <see cref="DateTime"/> value is in the specified interval.
        /// </summary>
        /// <param name="value">The value to compare against the lower bound and the upper bound.</param>
        /// <param name="lowerBound">The beginning of the time interval.</param>
        /// <param name="upperBound">The end of the time interval.</param>
        /// <param name="options">Specifies whether to treat the lower and upper bounds as inclusive or exclusive. By default, both are treated as inclusive.</param>
        /// <returns><see langword="true"/>, if <paramref name="value"/> is in the specified interval; otherwise, <see langword="false"/>.</returns>
        public static bool IsInRange(
            this DateTime value,
            DateTime lowerBound,
            DateTime upperBound,
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
