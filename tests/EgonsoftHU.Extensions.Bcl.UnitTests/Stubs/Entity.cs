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
    internal sealed record Entity(int Id, string Name);

#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    internal static class StubEntities
    {
        internal static readonly Entity First = new(1, "First");

        internal static readonly Entity Second = new(2, "Second");
    }
}
