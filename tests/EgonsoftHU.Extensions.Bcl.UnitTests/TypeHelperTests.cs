// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace EgonsoftHU.Extensions.Bcl.UnitTests
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public class TypeHelperTests : UnitTest<TypeHelperTests>
    {
        public TypeHelperTests(ITestOutputHelper output, LoggingFixture<TypeHelperTests> fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        public void GenericGetTypeName()
        {
            // Arrange
            string expectedTypeName = "System.String";

            // Act
            string actualTypeName = TypeHelper.GetTypeName<string>();

            // Assert
            actualTypeName.Should().Be(expectedTypeName);
        }

        [Fact]
        public void GetTypeName_NotNull()
        {
            // Arrange
            Type type = typeof(string);
            string expectedTypeName = "System.String";

            // Act
            string actualTypeName = TypeHelper.GetTypeName(type);

            // Assert
            actualTypeName.Should().Be(expectedTypeName);
        }

        [Fact]
        public void GetTypeName_Null()
        {
            // Arrange
            string expectedTypeName = String.Empty;

            // Act
            string actualTypeName = TypeHelper.GetTypeName(null);

            // Assert
            actualTypeName.Should().Be(expectedTypeName);
        }
    }
}
