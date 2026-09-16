// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
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
    public class ThrowExtensionsTests : UnitTest<ThrowExtensionsTests>
    {
        public ThrowExtensionsTests(ITestOutputHelper output, LoggingFixture<ThrowExtensionsTests> fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        public void ThrowIfNull_NonNullableValueType_NonNullValue()
        {
            // Arrange
            int value = 42;

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfNull_NullableValueType_NullValue()
        {
            // Arrange
            int? value = null;

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().ThrowExactly<ArgumentNullException>().WithParameterName(nameof(value));
        }

        [Fact]
        public void ThrowIfNull_NullableValueType_NonNullValue()
        {
            // Arrange
            int? value = 42;

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfNull_NullableReferenceType_NullValue()
        {
            // Arrange
            object? value = null;

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().ThrowExactly<ArgumentNullException>().WithParameterName(nameof(value));
        }

        [Fact]
        public void ThrowIfNull_NullableReferenceType_NonNullValue()
        {
            // Arrange
            object? value = new();

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfNull_NonNullableReferenceType_NullValue()
        {
            // Arrange
            object value = null!;

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().ThrowExactly<ArgumentNullException>().WithParameterName(nameof(value));
        }

        [Fact]
        public void ThrowIfNull_NonNullableReferenceType_NonNullValue()
        {
            // Arrange
            object value = new();

            // Act
            Action sut = () => value.ThrowIfNull();

            // Assert
            sut.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfEmptyGuid_GuidEmpty()
        {
            // Arrange
            Guid value = Guid.Empty;

            // Act
            Action sut = () => value.ThrowIfEmptyGuid();

            // Assert
            sut.Should().ThrowExactly<ArgumentException>().WithParameterName(nameof(value));
        }

        [Fact]
        public void ThrowIfEmptyGuid_GuidNonEmpty()
        {
            // Arrange
            var value = Guid.NewGuid();

            // Act
            Action sut = () => value.ThrowIfEmptyGuid();

            // Assert
            sut.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowIfNullOrEmpty_StringNull()
        {
            // Arrange
            string? value = null;

            // Act
            Action sut = () => value.ThrowIfNullOrEmpty();

            // Assert
            sut.Should().ThrowExactly<ArgumentNullException>().WithParameterName(nameof(value));
        }

        [Fact]
        public void ThrowIfNullOrEmpty_StringEmpty()
        {
            // Arrange
            string value = String.Empty;

            // Act
            Action sut = () => value.ThrowIfNullOrEmpty();

            // Assert
            sut.Should().ThrowExactly<ArgumentException>().WithParameterName(nameof(value));
        }

        [Fact]
        public void ThrowIfNullOrWhiteSpace_StringNull()
        {
            // Arrange
            string? value = null;

            // Act
            Action sut = () => value.ThrowIfNullOrWhiteSpace();

            // Assert
            sut.Should().ThrowExactly<ArgumentNullException>().WithParameterName(nameof(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        public void ThrowIfNullOrWhiteSpace_StringEmptyWhiteSpace(string? value)
        {
            // Arrange

            // Act
            Action sut = () => value.ThrowIfNullOrWhiteSpace();

            // Assert
            sut.Should().ThrowExactly<ArgumentException>().WithParameterName(nameof(value));
        }

        [Theory]
        [InlineData("\t")]
        [InlineData(" ")]
        [InlineData("A")]
        [InlineData("1")]
        public void ThrowIfNullOrEmpty_StringNonNullNonEmpty(string? value)
        {
            // Arrange

            // Act
            Action sut = () => value.ThrowIfNullOrEmpty();

            // Assert
            sut.Should().NotThrow<ArgumentNullException>().And.NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData("A")]
        [InlineData("1")]
        public void ThrowIfNullOrWhiteSpace_StringNonNullNonEmptyNonWhiteSpace(string? value)
        {
            // Arrange

            // Act
            Action sut = () => value.ThrowIfNullOrWhiteSpace();

            // Assert
            sut.Should().NotThrow<ArgumentNullException>().And.NotThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowZero()
        {
            // Arrange
            sbyte sbyteZero = 0;
            short shortZero = 0;
            int intZero = 0;
            long longZero = 0L;

            byte byteZero = Byte.MinValue;
            ushort ushortZero = UInt16.MinValue;
            uint uintZero = UInt32.MinValue;
            ulong ulongZero = UInt64.MinValue;

#if NET5_0_OR_GREATER
            var halfZero = (Half)0.0f;
            var halfPositiveZero = (Half)(+0.0f);
            var halfNegativeZero = (Half)(-0.0f);
#endif

            float floatZero = 0.0f;
            float floatPositiveZero = +0.0f;
            float floatNegativeZero = -0.0f;

            double doubleZero = 0.0d;
            double doublePositiveZero = +0.0d;
            double doubleNegativeZero = -0.0d;

            decimal decimalZero = Decimal.Zero;
            decimal decimalPositiveZero = +0.0m;
            decimal decimalNegativeZeroFractional = -0.0m;
            decimal decimalNegativeZeroIntegral = -0m;

            // Act
            var sut = new List<Action>()
            {
                () => sbyteZero.ThrowIfZero(),
                () => shortZero.ThrowIfZero(),
                () => intZero.ThrowIfZero(),
                () => longZero.ThrowIfZero(),
                () => byteZero.ThrowIfZero(),
                () => ushortZero.ThrowIfZero(),
                () => uintZero.ThrowIfZero(),
                () => ulongZero.ThrowIfZero(),
#if NET5_0_OR_GREATER
                () => halfZero.ThrowIfZero(),
                () => halfPositiveZero.ThrowIfZero(),
                () => halfNegativeZero.ThrowIfZero(),
#endif
                () => floatZero.ThrowIfZero(),
                () => floatPositiveZero.ThrowIfZero(),
                () => floatNegativeZero.ThrowIfZero(),
                () => doubleZero.ThrowIfZero(),
                () => doublePositiveZero.ThrowIfZero(),
                () => doubleNegativeZero.ThrowIfZero(),
                () => decimalZero.ThrowIfZero(),
                () => decimalPositiveZero.ThrowIfZero(),
                () => decimalNegativeZeroFractional.ThrowIfZero(),
                () => decimalNegativeZeroIntegral.ThrowIfZero()
            };

            // Assert
            sut.ForEach(action => action.Should().Throw<ArgumentOutOfRangeException>());
        }

        [Fact]
        public void ThrowNegative()
        {
            // Arrange
            sbyte sbyteNegative = -1;
            short shortNegative = -1;
            int intNegative = -1;
            long longNegative = -1L;

            float floatNegativeZero = -0.0F;
            float floatNegativeNonZero = -0.1F;

            double doubleNegativeZero = -0.0D;
            double doubleNegativeNonZero = -0.1D;

            decimal decimalNegativeZero = -0.0M;
            decimal decimalNegativeNonZero = -0.1M;

            // Act
            var sut = new List<Action>()
            {
                () => sbyteNegative.ThrowIfNegative(),
                () => shortNegative.ThrowIfNegative(),
                () => intNegative.ThrowIfNegative(),
                () => longNegative.ThrowIfNegative(),
                () => floatNegativeZero.ThrowIfNegative(),
                () => floatNegativeNonZero.ThrowIfNegative(),
                () => doubleNegativeZero.ThrowIfNegative(),
                () => doubleNegativeNonZero.ThrowIfNegative(),
                () => decimalNegativeZero.ThrowIfNegative(),
                () => decimalNegativeNonZero.ThrowIfNegative()
            };

            // Assert
            sut.ForEach(action => action.Should().Throw<ArgumentOutOfRangeException>());
        }
    }
}
