// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif

using System;
using System.Collections.Generic;
using System.Linq;

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

        public class IsInTests
        {
            public class ParamsArray
            {
                [Fact]
                public void NullableValueType_In_NullableValueType()
                {
                    // Arrange
                    int? number = 2;

                    int?[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int?[] { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void NonNullableValueType_In_NullableValueType()
                {
                    // Arrange
                    int number = 2;

                    int?[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int?[] { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void NullableValueType_WithNotNull_In_NonNullableValueType()
                {
                    // Arrange
                    int? number = 2;

                    int[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int[] { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void NullableValueType_WithNull_In_NonNullableValueType()
                {
                    // Arrange
                    int? number = null;

                    int[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int[] { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeFalse();
                }

                [Fact]
                public void NonNullableValueType_In_NonNullableValueType()
                {
                    // Arrange
                    int number = 2;

                    int[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int[] { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void ReferenceType_In_ReferenceType()
                {
                    // Arrange
                    object obj = new();

                    object[] objs =
#if LANGVERSION12_0_OR_GREATER
                        [obj, new()]
#else
                        new object[] { obj, new() }
#endif
                        ;

                    // Act
                    bool result = obj.IsIn(objs);

                    // Assert
                    result.Should().BeTrue();
                }
            }

            public class ParamsIEnumerable
            {
                [Fact]
                public void NullableValueType_In_NullableValueType()
                {
                    // Arrange
                    int? number = 2;

                    IEnumerable<int?> numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new List<int?>() { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void NonNullableValueType_In_NullableValueType()
                {
                    // Arrange
                    int number = 2;

                    IEnumerable<int?> numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new List<int?>() { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void NullableValueType_WithNotNull_In_NonNullableValueType()
                {
                    // Arrange
                    int? number = 2;

                    IEnumerable<int> numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new List<int>() { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void NullableValueType_WithNull_In_NonNullableValueType()
                {
                    // Arrange
                    int? number = null;

                    IEnumerable<int> numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new List<int>() { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeFalse();
                }

                [Fact]
                public void NonNullableValueType_In_NonNullableValueType()
                {
                    // Arrange
                    int number = 2;

                    IEnumerable<int> numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new List<int>() { 1, 2, 3 }
#endif
                        ;

                    // Act
                    bool result = number.IsIn(numbers);

                    // Assert
                    result.Should().BeTrue();
                }

                [Fact]
                public void ReferenceType_In_ReferenceType()
                {
                    // Arrange
                    object obj = new();

                    IEnumerable<object> objs =
#if LANGVERSION12_0_OR_GREATER
                        [obj, new()]
#else
                        new List<object>() { obj, new() }
#endif
                        ;

                    // Act
                    bool result = obj.IsIn(objs);

                    // Assert
                    result.Should().BeTrue();
                }
            }

#if NET8_0_OR_GREATER
            public class ParamsReadOnlySpan
            {
                [Fact]
                public void NonNullableValueType_In_NonNullableValueType()
                {
                    // Arrange
                    int number = 2;

                    int[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int[] { 1, 2, 3 }
#endif
                    ;

                    // Act
                    bool result = number.IsIn(numbers.AsSpan());

                    // Assert
                    result.Should().BeTrue();
                }

#if NET10_0_OR_GREATER
                [Fact]
                public void NonNullableValueType_In_NonNullableValueType_Using_EqualityComparer()
                {
                    // Arrange
                    int number = 2;

                    int[] numbers =
#if LANGVERSION12_0_OR_GREATER
                        [1, 2, 3]
#else
                        new int[] { 1, 2, 3 }
#endif
                    ;

                    // Act
                    bool result = number.IsIn(EqualityComparer<int>.Default, numbers.AsSpan());

                    // Assert
                    result.Should().BeTrue();
                }
#endif
            }
#endif
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
