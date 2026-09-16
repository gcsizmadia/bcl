// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif
using System.Runtime.Serialization;

namespace EgonsoftHU.Extensions.Bcl.UnitTests.Stubs
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    internal static class Enums
    {
        internal enum WithNoFlagsWithZero
        {
            [EnumMember(Value = "ZeRo")]
            Zero,
            One,
            Two,
            Three,
            Four
        }

        internal enum WithNoFlagsWithNoZero
        {
            One = 1,
            Two,
            Three,
            Four
        }

        [Flags]
        internal enum WithFlagsWithZero
        {
            Zero,
            One,
            Two,
            Three = 4,
            Four = 8,
            All = One | Two | Three | Four
        }

        [Flags]
        internal enum WithFlagsWithNoZero
        {
            One = 1,
            Two,
            Three = 4,
            Four = 8,
            All = One | Two | Three | Four
        }

        internal enum WithSynonyms
        {
            Zero,
            OneDefinedFirst,
#if NET6_0_OR_GREATER
#pragma warning disable CA1069 // Enums values should not be duplicated
#endif
            OneDefinedSecond = 1
#if NET6_0_OR_GREATER
#pragma warning restore CA1069 // Enums values should not be duplicated
#endif
        }

        internal static class WithSignedTypeCode
        {
            internal enum WithSByte : sbyte
            {
                Min = SByte.MinValue,
                Zero = 0,
                Max = SByte.MaxValue
            }

            internal enum WithInt16 : short
            {
                Min = Int16.MinValue,
                Zero = 0,
                Max = Int16.MaxValue
            }

            internal enum WithInt32 : int
            {
                Min = Int32.MinValue,
                Zero = 0,
                Max = Int32.MaxValue
            }

            internal enum WithInt64 : long
            {
                Min = Int64.MinValue,
                Zero = 0,
                Max = Int64.MaxValue
            }
        }
    }
}
