// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;

using EgonsoftHU.Extensions.Bcl.Enumerations;

namespace EgonsoftHU.Extensions.Bcl.Internals
{
    internal static class InternalComparer<T> where T : struct, IComparable<T>
    {
        private static readonly Comparer<T> Comparer = Comparer<T>.Default;

        internal static bool IsInRange(
            T value,
            T lowerBound,
            T upperBound,
            IntervalBoundsOptions options = default
        )
        {
            return
                (
                    options.HasFlag(IntervalBoundsOptions.LeftOpen)
                        ? Comparer.Compare(value, lowerBound) > 0
                        : Comparer.Compare(value, lowerBound) >= 0
                )
                &&
                (
                    options.HasFlag(IntervalBoundsOptions.RightOpen)
                        ? Comparer.Compare(value, upperBound) < 0
                        : Comparer.Compare(value, upperBound) <= 0
                );
        }
    }
}
