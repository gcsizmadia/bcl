// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif

namespace EgonsoftHU.Extensions.Bcl.UnitTests.Stubs
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    internal sealed record DataTransferObject(int Id, string Name);

#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    internal static class StubDataTransferObjects
    {
        internal static readonly DataTransferObject First = new(1, "First");

        internal static readonly DataTransferObject FirstUpdated = new(1, "FirstUpdated");

        internal static readonly DataTransferObject Second = new(2, "Second");

        internal static readonly DataTransferObject SecondUpdated = new(2, "SecondUpdated");

        internal static readonly DataTransferObject Third = new(3, "Third");
    }
}
