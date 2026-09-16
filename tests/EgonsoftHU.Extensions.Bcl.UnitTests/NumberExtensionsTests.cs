// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;

using EgonsoftHU.Extensions.Bcl.Enumerations;

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
    public class NumberExtensionsTests : UnitTest<NumberExtensionsTests>
    {
        public NumberExtensionsTests(ITestOutputHelper output, LoggingFixture<NumberExtensionsTests> fixture)
            : base(output, fixture)
        {
        }

        #region IsZero

        [Fact]
        public void IsZero_SByte()
        {
            // Arrange
            sbyte zero = 0;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Int16()
        {
            // Arrange
            short zero = 0;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Int32()
        {
            // Arrange
            int zero = 0;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Int64()
        {
            // Arrange
            long zero = 0L;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Byte()
        {
            // Arrange
            byte zero = Byte.MinValue;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_UInt16()
        {
            // Arrange
            ushort zero = UInt16.MinValue;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_UInt32()
        {
            // Arrange
            uint zero = UInt32.MinValue;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_UInt64()
        {
            // Arrange
            ulong zero = UInt64.MinValue;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
        }

#if NET5_0_OR_GREATER
        [Fact]
        public void IsZero_Half()
        {
            // Arrange
            var zero = (Half)0.0f;
            var positiveZero = (Half)(+0.0f);
            var negativeZero = (Half)(-0.0f);

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
            positiveZero.IsZero().Should().BeTrue();
            negativeZero.IsZero().Should().BeTrue();
        }
#endif

        [Fact]
        public void IsZero_Single()
        {
            // Arrange
            float zero = 0.0f;
            float positiveZero = +0.0f;
            float negativeZero = -0.0f;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
            positiveZero.IsZero().Should().BeTrue();
            negativeZero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Double()
        {
            // Arrange
            double zero = 0.0d;
            double positiveZero = +0.0d;
            double negativeZero = -0.0d;

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
            positiveZero.IsZero().Should().BeTrue();
            negativeZero.IsZero().Should().BeTrue();
        }

        [Fact]
        public void IsZero_Decimal()
        {
            // Arrange
            decimal zero = Decimal.Zero;
            decimal positiveZero = +0.0m;

            // C# compiler does not treat "-0m" as negative zero, although it does get both the sign and the scale correctly for "-0.0m".
            decimal negativeZeroFractional = -0.0m;
            decimal negativeZeroIntegral = -0m;

            decimal negatedZero = Decimal.Negate(Decimal.Zero);

            // Act

            // Assert
            zero.IsZero().Should().BeTrue();
            positiveZero.IsZero().Should().BeTrue();
            negativeZeroFractional.IsZero().Should().BeTrue();
            negativeZeroIntegral.IsZero().Should().BeTrue();
            negatedZero.IsZero().Should().BeTrue();
        }

        #endregion

        #region IsNegative

        [Fact]
        public void IsNegative_SByte()
        {
            // Arrange
            sbyte zero = 0;
            sbyte minusOne = -1;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            minusOne.IsNegative().Should().BeTrue();

            SByte.MinValue.IsNegative().Should().BeTrue();
            SByte.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_Int16()
        {
            // Arrange
            short zero = 0;
            short minusOne = -1;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            minusOne.IsNegative().Should().BeTrue();

            Int16.MinValue.IsNegative().Should().BeTrue();
            Int16.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_Int32()
        {
            // Arrange
            int zero = 0;
            int minusOne = -1;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            minusOne.IsNegative().Should().BeTrue();

            Int32.MinValue.IsNegative().Should().BeTrue();
            Int32.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_Int64()
        {
            // Arrange
            long zero = 0L;
            long minusOne = -1L;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            minusOne.IsNegative().Should().BeTrue();

            Int64.MinValue.IsNegative().Should().BeTrue();
            Int64.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_Byte()
        {
            // Arrange
            byte zero = (byte)0U;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();

            Byte.MinValue.IsNegative().Should().BeFalse();
            Byte.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_UInt16()
        {
            // Arrange
            ushort zero = (ushort)0U;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();

            UInt16.MinValue.IsNegative().Should().BeFalse();
            UInt16.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_UInt32()
        {
            // Arrange
            uint zero = 0U;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();

            UInt32.MinValue.IsNegative().Should().BeFalse();
            UInt32.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_UInt64()
        {
            // Arrange
            ulong zero = 0UL;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();

            UInt64.MinValue.IsNegative().Should().BeFalse();
            UInt64.MaxValue.IsNegative().Should().BeFalse();
        }

#if NET5_0_OR_GREATER
        [Fact]
        public void IsNegative_Half()
        {
            // Arrange
            var zero = (Half)0.0f;
            var positiveZero = (Half)(+0.0f);
            var negativeZero = (Half)(-0.0f);
            var minusOne = (Half)(-1.0f);

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            positiveZero.IsNegative().Should().BeFalse();

            negativeZero.IsNegative().Should().BeTrue();
            minusOne.IsNegative().Should().BeTrue();

            Half.MinValue.IsNegative().Should().BeTrue();
            Half.MaxValue.IsNegative().Should().BeFalse();
        }
#endif

        [Fact]
        public void IsNegative_Single()
        {
            // Arrange
            float zero = 0.0f;
            float positiveZero = +0.0f;
            float negativeZero = -0.0f;
            float minusOne = -1.0f;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            positiveZero.IsNegative().Should().BeFalse();

            negativeZero.IsNegative().Should().BeTrue();
            minusOne.IsNegative().Should().BeTrue();

            Single.MinValue.IsNegative().Should().BeTrue();
            Single.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_Double()
        {
            // Arrange
            double zero = 0.0d;
            double positiveZero = +0.0d;
            double negativeZero = -0.0d;
            double minusOne = -1.0d;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            positiveZero.IsNegative().Should().BeFalse();

            negativeZero.IsNegative().Should().BeTrue();
            minusOne.IsNegative().Should().BeTrue();

            Double.MinValue.IsNegative().Should().BeTrue();
            Double.MaxValue.IsNegative().Should().BeFalse();
        }

        [Fact]
        public void IsNegative_Decimal()
        {
            // Arrange
            decimal zero = Decimal.Zero;
            decimal positiveZero = +0.0m;

            // C# compiler does not treat "-0m" as negative zero, although it does get both the sign and the scale correctly for "-0.0m".
            decimal negativeZeroIntegerFormat = -0m;
            decimal negativeZeroFractionalFormat = -0.0m;

            decimal negatedZero = Decimal.Negate(Decimal.Zero);
            decimal minusOne = -1m;

            // Act

            // Assert
            zero.IsNegative().Should().BeFalse();
            positiveZero.IsNegative().Should().BeFalse();

            negativeZeroIntegerFormat.IsNegative().Should().BeFalse();

            negativeZeroFractionalFormat.IsNegative().Should().BeTrue();
            negatedZero.IsNegative().Should().BeTrue();
            minusOne.IsNegative().Should().BeTrue();

            Decimal.MinValue.IsNegative().Should().BeTrue();
            Decimal.MaxValue.IsNegative().Should().BeFalse();
        }

        #endregion

        #region IsNegativeOrZero

        [Fact]
        public void IsNegativeOrZero_SByte()
        {
            // Arrange
            sbyte zero = 0;
            sbyte minusOne = -1;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            SByte.MinValue.IsNegativeOrZero().Should().BeTrue();
            SByte.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_Int16()
        {
            // Arrange
            short zero = 0;
            short minusOne = -1;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Int16.MinValue.IsNegativeOrZero().Should().BeTrue();
            Int16.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_Int32()
        {
            // Arrange
            int zero = 0;
            int minusOne = -1;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Int32.MinValue.IsNegativeOrZero().Should().BeTrue();
            Int32.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_Int64()
        {
            // Arrange
            long zero = 0L;
            long minusOne = -1L;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Int64.MinValue.IsNegativeOrZero().Should().BeTrue();
            Int64.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_Byte()
        {
            // Arrange
            byte zero = (byte)0U;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();

            Byte.MinValue.IsNegativeOrZero().Should().BeTrue();
            Byte.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_UInt16()
        {
            // Arrange
            ushort zero = (ushort)0U;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();

            UInt16.MinValue.IsNegativeOrZero().Should().BeTrue();
            UInt16.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_UInt32()
        {
            // Arrange
            uint zero = 0U;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();

            UInt32.MinValue.IsNegativeOrZero().Should().BeTrue();
            UInt32.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_UInt64()
        {
            // Arrange
            ulong zero = 0UL;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();

            UInt64.MinValue.IsNegativeOrZero().Should().BeTrue();
            UInt64.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

#if NET5_0_OR_GREATER
        [Fact]
        public void IsNegativeOrZero_Half()
        {
            // Arrange
            var zero = (Half)0.0f;
            var positiveZero = (Half)(+0.0f);
            var negativeZero = (Half)(-0.0f);
            var minusOne = (Half)(-1.0f);

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            positiveZero.IsNegativeOrZero().Should().BeTrue();
            negativeZero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Half.MinValue.IsNegativeOrZero().Should().BeTrue();
            Half.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }
#endif

        [Fact]
        public void IsNegativeOrZero_Single()
        {
            // Arrange
            float zero = 0.0f;
            float positiveZero = +0.0f;
            float negativeZero = -0.0f;
            float minusOne = -1.0f;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            positiveZero.IsNegativeOrZero().Should().BeTrue();
            negativeZero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Single.MinValue.IsNegativeOrZero().Should().BeTrue();
            Single.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_Double()
        {
            // Arrange
            double zero = 0.0d;
            double positiveZero = +0.0d;
            double negativeZero = -0.0d;
            double minusOne = -1.0d;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            positiveZero.IsNegativeOrZero().Should().BeTrue();
            negativeZero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Double.MinValue.IsNegativeOrZero().Should().BeTrue();
            Double.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        [Fact]
        public void IsNegativeOrZero_Decimal()
        {
            // Arrange
            decimal zero = Decimal.Zero;
            decimal positiveZero = +0.0m;

            // C# compiler does not treat "-0m" as negative zero, although it does get both the sign and the scale correctly for "-0.0m".
            decimal negativeZero = -0.0m;

            decimal negatedZero = Decimal.Negate(Decimal.Zero);
            decimal minusOne = -1.0m;

            // Act

            // Assert
            zero.IsNegativeOrZero().Should().BeTrue();
            positiveZero.IsNegativeOrZero().Should().BeTrue();
            negativeZero.IsNegativeOrZero().Should().BeTrue();
            negatedZero.IsNegativeOrZero().Should().BeTrue();
            minusOne.IsNegativeOrZero().Should().BeTrue();

            Decimal.MinValue.IsNegativeOrZero().Should().BeTrue();
            Decimal.MaxValue.IsNegativeOrZero().Should().BeFalse();
        }

        #endregion

        #region IsPositive

        [Fact]
        public void IsPositive_SByte()
        {
            // Arrange
            sbyte plusOne = 1;
            sbyte zero = 0;
            sbyte minusOne = -1;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            minusOne.IsPositive().Should().BeFalse();

            SByte.MinValue.IsPositive().Should().BeFalse();
            SByte.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_Int16()
        {
            // Arrange
            short plusOne = 1;
            short zero = 0;
            short minusOne = -1;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            minusOne.IsPositive().Should().BeFalse();

            Int16.MinValue.IsPositive().Should().BeFalse();
            Int16.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_Int32()
        {
            // Arrange
            int plusOne = 1;
            int zero = 0;
            int minusOne = -1;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            minusOne.IsPositive().Should().BeFalse();

            Int32.MinValue.IsPositive().Should().BeFalse();
            Int32.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_Int64()
        {
            // Arrange
            long plusOne = 1L;
            long zero = 0L;
            long minusOne = -1L;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            minusOne.IsPositive().Should().BeFalse();

            Int64.MinValue.IsPositive().Should().BeFalse();
            Int64.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_Byte()
        {
            // Arrange
            byte plusOne = (byte)1U;
            byte zero = (byte)0U;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();

            Byte.MinValue.IsPositive().Should().BeTrue();
            Byte.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_UInt16()
        {
            // Arrange
            ushort plusOne = (ushort)1U;
            ushort zero = (ushort)0U;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();

            UInt16.MinValue.IsPositive().Should().BeTrue();
            UInt16.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_UInt32()
        {
            // Arrange
            uint plusOne = 1U;
            uint zero = 0U;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();

            UInt32.MinValue.IsPositive().Should().BeTrue();
            UInt32.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_UInt64()
        {
            // Arrange
            ulong plusOne = 1UL;
            ulong zero = 0UL;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();

            UInt64.MinValue.IsPositive().Should().BeTrue();
            UInt64.MaxValue.IsPositive().Should().BeTrue();
        }

#if NET5_0_OR_GREATER
        [Fact]
        public void IsPositive_Half()
        {
            // Arrange
            var plusOne = (Half)1.0f;
            var zero = (Half)0.0f;
            var positiveZero = (Half)(+0.0f);
            var negativeZero = (Half)(-0.0f);
            var minusOne = (Half)(-1.0f);

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            positiveZero.IsPositive().Should().BeTrue();

            negativeZero.IsPositive().Should().BeFalse();
            minusOne.IsPositive().Should().BeFalse();

            Half.MinValue.IsPositive().Should().BeFalse();
            Half.MaxValue.IsPositive().Should().BeTrue();
        }
#endif

        [Fact]
        public void IsPositive_Single()
        {
            // Arrange
            float plusOne = 1.0f;
            float zero = 0.0f;
            float positiveZero = +0.0f;
            float negativeZero = -0.0f;
            float minusOne = -1.0f;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            positiveZero.IsPositive().Should().BeTrue();

            negativeZero.IsPositive().Should().BeFalse();
            minusOne.IsPositive().Should().BeFalse();

            Single.MinValue.IsPositive().Should().BeFalse();
            Single.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_Double()
        {
            // Arrange
            double plusOne = 1.0d;
            double zero = 0.0d;
            double positiveZero = +0.0d;
            double negativeZero = -0.0d;
            double minusOne = -1.0d;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            positiveZero.IsPositive().Should().BeTrue();

            negativeZero.IsPositive().Should().BeFalse();
            minusOne.IsPositive().Should().BeFalse();

            Double.MinValue.IsPositive().Should().BeFalse();
            Double.MaxValue.IsPositive().Should().BeTrue();
        }

        [Fact]
        public void IsPositive_Decimal()
        {
            // Arrange
            decimal plusOne = Decimal.One;
            decimal zero = Decimal.Zero;
            decimal positiveZero = +0.0m;

            // C# compiler does not treat "-0m" as negative zero, although it does get both the sign and the scale correctly for "-0.0m".
            decimal negativeZeroIntegerFormat = -0m;
            decimal negativeZeroFractionalFormat = -0.0m;

            decimal negatedZero = Decimal.Negate(Decimal.Zero);
            decimal minusOne = -1m;

            // Act

            // Assert
            plusOne.IsPositive().Should().BeTrue();
            zero.IsPositive().Should().BeTrue();
            positiveZero.IsPositive().Should().BeTrue();

            negativeZeroIntegerFormat.IsPositive().Should().BeTrue();

            negativeZeroFractionalFormat.IsPositive().Should().BeFalse();
            negatedZero.IsPositive().Should().BeFalse();
            minusOne.IsPositive().Should().BeFalse();

            Decimal.MinValue.IsPositive().Should().BeFalse();
            Decimal.MaxValue.IsPositive().Should().BeTrue();
        }

        #endregion

        #region IsInRange
        [Fact]
        public void IsInRange_Int32()
        {
            // Arrange

            // Act

            // Assert
            4.IsInRange(4, 6).Should().BeTrue();
            5.IsInRange(4, 6).Should().BeTrue();
            6.IsInRange(4, 6).Should().BeTrue();

            4.IsInRange(4, 6, IntervalBoundsOptions.LeftOpen).Should().BeFalse();
            5.IsInRange(4, 6, IntervalBoundsOptions.LeftOpen).Should().BeTrue();
            6.IsInRange(4, 6, IntervalBoundsOptions.LeftOpen).Should().BeTrue();

            4.IsInRange(4, 6, IntervalBoundsOptions.RightOpen).Should().BeTrue();
            5.IsInRange(4, 6, IntervalBoundsOptions.RightOpen).Should().BeTrue();
            6.IsInRange(4, 6, IntervalBoundsOptions.RightOpen).Should().BeFalse();

            4.IsInRange(4, 6, IntervalBoundsOptions.Open).Should().BeFalse();
            5.IsInRange(4, 6, IntervalBoundsOptions.Open).Should().BeTrue();
            6.IsInRange(4, 6, IntervalBoundsOptions.Open).Should().BeFalse();
        }
        #endregion
    }
}
