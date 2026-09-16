// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif

using Serilog;

using Xunit;

namespace EgonsoftHU.Extensions.Bcl.UnitTests
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public abstract class UnitTest<T> : IClassFixture<LoggingFixture<T>>
    {
        protected UnitTest(ITestOutputHelper output, LoggingFixture<T> fixture)
        {
            fixture.InitializeLogger(output);
            Logger = fixture.Logger;
        }

        protected ILogger Logger { get; }
    }
}
