// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;

using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.XUnit3;

using Xunit;
using Xunit.Sdk;

namespace EgonsoftHU.Extensions.Bcl.UnitTests
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public abstract class LoggingFixture
    {
        protected static readonly RenderedCompactJsonFormatter Formatter = new();
    }

#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public class LoggingFixture<T> : LoggingFixture, IDisposable
    {
        private const string OutputTemplate =
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fffffff zzz} [{Level:u3}] {Message:lj} ==> {Properties}{NewLine}{Exception}";

        public ILogger? Logger { get; private set; }

        [MemberNotNull(nameof(Logger))]
        public void InitializeLogger(ITestOutputHelper output)
        {
            Logger = CreateLogger(output);
        }

        [MemberNotNull(nameof(Logger))]
        public void InitializeLogger(IMessageSink output)
        {
            Logger = CreateLogger(output);
        }

        private static ILogger CreateLogger(object output)
        {
            var options = new XUnit3TestOutputSinkOptions(OutputTemplate, CultureInfo.CurrentCulture);

            XUnit3TestOutputSink sink = output switch
            {
                ITestOutputHelper testOutputHelper => new(options) { TestOutputHelper = testOutputHelper },
                IMessageSink messageSink => new(options) { MessageSink = messageSink },
                _ => new(options)
            };

            return
                new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File(
                        formatter: Formatter,
                        path: Path.Combine(AppContext.BaseDirectory, "xunit-output.log"),
                        restrictedToMinimumLevel: LogEventLevel.Verbose,
                        shared: true,
                        encoding: Encoding.UTF8
                    )
                    .WriteTo.XUnit3TestOutput(sink, LogEventLevel.Verbose)
                    .CreateLogger()
                    .ForContext<T>();
        }

        #region Dispose pattern implementation

        private bool isDisposed;

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    if (Logger is IDisposable disposableLogger)
                    {
                        disposableLogger.Dispose();
                    }

                    Logger = null;
                }

                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
