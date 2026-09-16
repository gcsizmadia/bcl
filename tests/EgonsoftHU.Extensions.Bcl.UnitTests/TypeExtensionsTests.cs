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
    public class TypeExtensionsTests : UnitTest<TypeExtensionsTests>
    {
        public TypeExtensionsTests(ITestOutputHelper output, LoggingFixture<TypeExtensionsTests> fixture)
            : base(output, fixture)
        {
        }

        [Theory]
        [InlineData(typeof(sbyte?), true)]
        [InlineData(typeof(short?), true)]
        [InlineData(typeof(int?), true)]
        [InlineData(typeof(long?), true)]
        [InlineData(typeof(byte?), true)]
        [InlineData(typeof(ushort?), true)]
        [InlineData(typeof(uint?), true)]
        [InlineData(typeof(ulong?), true)]
        [InlineData(typeof(float?), true)]
        [InlineData(typeof(double?), true)]
        [InlineData(typeof(bool?), true)]
        [InlineData(typeof(ValueTask<int>?), true)]
        [InlineData(typeof(ValueTask<int?>?), true)]
        [InlineData(typeof(int), false)]
        [InlineData(typeof(string), false)]
        [InlineData(typeof(ValueTask<int>), false)]
        [InlineData(typeof(Task<int>), false)]
        public void IsNullableValueType(Type type, bool expected)
        {
            // Arrange

            // Act
            bool result = type.IsNullableValueType();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(typeof(sbyte?))]
        [InlineData(typeof(short?))]
        [InlineData(typeof(int?))]
        [InlineData(typeof(long?))]
        [InlineData(typeof(byte?))]
        [InlineData(typeof(ushort?))]
        [InlineData(typeof(uint?))]
        [InlineData(typeof(ulong?))]
        [InlineData(typeof(float?))]
        [InlineData(typeof(double?))]
        [InlineData(typeof(bool?))]
        public void AsNullableValueType_Nullable(Type type)
        {
            // Arrange

            // Act
            Type? result = type.AsNullableValueType();

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(type);
        }

        [Theory]
        [InlineData(typeof(sbyte), typeof(sbyte?))]
        [InlineData(typeof(short), typeof(short?))]
        [InlineData(typeof(int), typeof(int?))]
        [InlineData(typeof(long), typeof(long?))]
        [InlineData(typeof(byte), typeof(byte?))]
        [InlineData(typeof(ushort), typeof(ushort?))]
        [InlineData(typeof(uint), typeof(uint?))]
        [InlineData(typeof(ulong), typeof(ulong?))]
        [InlineData(typeof(float), typeof(float?))]
        [InlineData(typeof(double), typeof(double?))]
        [InlineData(typeof(bool), typeof(bool?))]
        [InlineData(typeof(ValueTask<int>), typeof(ValueTask<int>?))]
        public void AsNullableValueType_NonNullableStruct(Type type, Type? expected)
        {
            // Arrange

            // Act
            Type? result = type.AsNullableValueType();

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(Task<int>))]
        [InlineData(typeof(IEquatable<int>))]
        public void AsNullableValueType_NotStruct(Type type)
        {
            // Arrange

            // Act
            Type? result = type.AsNullableValueType();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AsNullableValueType_Null()
        {
            // Arrange
            Type? type = null;

            // Act
            Func<Type?> sut = () => type!.AsNullableValueType();

            // Assert
            sut.Should().ThrowExactly<ArgumentNullException>().WithParameterName(nameof(type));
        }

        [Fact]
        public void GetName_NotNull()
        {
            // Arrange
            Type type = typeof(string);
            string expectedTypeName = "System.String";

            // Act
            string actualTypeName = type.GetName();

            // Assert
            actualTypeName.Should().Be(expectedTypeName);
        }

        [Fact]
        public void GetName_Null()
        {
            // Arrange
            Type? type = null;
            string expectedTypeName = String.Empty;

            // Act
            string actualTypeName = type!.GetName();

            // Assert
            actualTypeName.Should().Be(expectedTypeName);
        }
    }
}
