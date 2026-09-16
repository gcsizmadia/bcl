// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
#if !NET8_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif
using System.Linq;

using EgonsoftHU.Extensions.Bcl.Enumerations.Internals.Flags;
using EgonsoftHU.Extensions.Bcl.Exceptions;

namespace EgonsoftHU.Extensions.Bcl.Enumerations.Internals
{
    internal abstract class EnumFlags<TUnderlying> : IEnumFlags<TUnderlying>
        where TUnderlying : struct, IComparable<TUnderlying>
    {
        private const double PowerBase = 2D;

        private static readonly ReadOnlyDictionary<Type, Type> flagsByUnderlyingType =
            new(
                new Dictionary<Type, Type>()
                {
                    [typeof(byte)] = typeof(ByteFlags),
                    [typeof(short)] = typeof(Int16Flags),
                    [typeof(int)] = typeof(Int32Flags),
                    [typeof(long)] = typeof(Int64Flags),
                    [typeof(sbyte)] = typeof(SByteFlags),
                    [typeof(ushort)] = typeof(UInt16Flags),
                    [typeof(uint)] = typeof(UInt32Flags),
                    [typeof(ulong)] = typeof(UInt64Flags),
                }
            );

        internal static IEnumFlags<TUnderlying> Instance { get; } = CreateInstance();

        public abstract TUnderlying Construct(params TUnderlying[] values);

        public abstract TUnderlying[] Deconstruct(TUnderlying value);

        public abstract bool IsPowerOf2(TUnderlying value);

        protected static IEnumerable<double> ResolveCore(double value)
        {
            if (value <= 0)
            {
                return value.AsSingleElementSequence();
            }

            double remainder = value;
            double maxPower = Math.Floor(Math.Log(value, PowerBase));

            var numbers = new List<double>();

            for (double currentPower = maxPower; currentPower >= 0; currentPower--)
            {
                double powerValue = Math.Pow(PowerBase, currentPower);

                if (powerValue <= remainder)
                {
                    numbers.Add(powerValue);
                    remainder -= powerValue;
                }
            }

            return numbers.OrderBy(number => number);
        }

#if !NET8_0_OR_GREATER
        [SuppressMessage(SonarQube.Category, SonarQube.S1244)]
#endif
        protected static bool IsPowerOf2Core(double value)
        {
            double log = Math.Log(value, PowerBase);

            return log == Math.Floor(log);
        }

        private static IEnumFlags<TUnderlying> CreateInstance()
        {
            if (!flagsByUnderlyingType.TryGetValue(typeof(TUnderlying), out Type? flagsType))
            {
                throw NotSupportedExceptions.NotSupportedEnumUnderlyingType<TUnderlying>();
            }

            return
                Activator.CreateInstance(flagsType) is IEnumFlags<TUnderlying> flags
                    ? flags
                    : throw InvalidOperationExceptions.CreateEnumFlagsInstanceFailed<TUnderlying>(flagsType);
        }
    }
}
