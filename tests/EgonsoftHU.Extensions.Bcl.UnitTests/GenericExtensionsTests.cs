// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif

using FluentAssertions;

using Xunit;

namespace EgonsoftHU.Extensions.Bcl.UnitTests
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public class GenericExtensionsTests : UnitTest<GenericExtensionsTests>
    {
        public GenericExtensionsTests(ITestOutputHelper output, LoggingFixture<GenericExtensionsTests> fixture)
            : base(output, fixture)
        {
        }

        public class IsDefaultValueTests
        {
            [Fact]
            public void NonNullableValueType()
            {
                // Arrange
                int value = 0;

                // Act
                bool result = value.IsDefaultValue();

                // Assert
                result.Should().BeTrue();
            }

            [Fact]
            public void NullableValueTypeNotNull()
            {
                // Arrange
                int? value = 0;

                // Act
                bool result = value.IsDefaultValue();

                // Assert
                result.Should().BeFalse();
            }

            [Fact]
            public void NullableValueTypeNull()
            {
                // Arrange
                int? value = null;

                // Act
                bool result = value.IsDefaultValue();

                // Assert
                result.Should().BeTrue();
            }

            [Fact]
            public void NullableReferenceTypeNull()
            {
                // Arrange
                string? value = null;

                // Act
                bool result = value.IsDefaultValue();

                // Assert
                result.Should().BeTrue();
            }

            [Fact]
            public void NonNullableReferenceTypeNull()
            {
                // Arrange
                string value = null!;

                // Act
                bool result = value.IsDefaultValue();

                // Assert
                result.Should().BeTrue();
            }
        }
    }
}
