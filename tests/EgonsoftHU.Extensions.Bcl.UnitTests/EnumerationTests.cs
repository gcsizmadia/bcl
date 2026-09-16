// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
using System.Collections.Specialized;

#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif
using System.Linq;
using System.Runtime.CompilerServices;

using EgonsoftHU.Extensions.Bcl.Enumerations;

using FluentAssertions;

using Xunit;

using static EgonsoftHU.Extensions.Bcl.UnitTests.Stubs.Enums;

namespace EgonsoftHU.Extensions.Bcl.UnitTests
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public class EnumerationTests : UnitTest<EnumerationTests>
    {
        public EnumerationTests(ITestOutputHelper output, LoggingFixture<EnumerationTests> fixture)
            : base(output, fixture)
        {
        }

        public class DefaultValueTests : UnitTest<DefaultValueTests>
        {
            public DefaultValueTests(ITestOutputHelper output, LoggingFixture<DefaultValueTests> fixture)
                : base(output, fixture)
            {
            }

            [Theory]
            [InlineData(default(WithNoFlagsWithNoZero), "", false)]
            [InlineData(default(WithNoFlagsWithZero), "Zero", true)]
            [InlineData(default(WithFlagsWithNoZero), "", false)]
            [InlineData(default(WithFlagsWithZero), "Zero", true)]
            public void Default<TEnum>(TEnum enumValue, string expectedName, bool expectedIsDefined)
                where TEnum : struct, Enum
            {
                LogParameter(enumValue);

                // Arrange
                TEnum expectedValue = default;
                int expectedUnderlyingValue = 0;

                // Act
                EnumInfo<TEnum> clrDefault = EnumInfo<TEnum>.Default;

                // Assert
                clrDefault.As<object>().Should().NotBeNull();
                clrDefault.Name.Should().Be(expectedName);
                clrDefault.Value.Should().Be(expectedValue);
                clrDefault.Value.Should().HaveValue(expectedUnderlyingValue);
                clrDefault.IsDefaultValue.Should().BeTrue();
                clrDefault.IsDefined.Should().Be(expectedIsDefined);
            }

            private void LogParameter<T>(T paramValue, [CallerArgumentExpression(nameof(paramValue))] string? paramName = null)
            {
                Logger.Verbose("Dummy parameter logging as a workaround: [{ParamName}] = [{ParamValue}]", paramName, paramValue);
            }
        }

        public class DefinedMembersTest
        {
            [Fact]
            public void DefinedMembers()
            {
                // Arrange
                List<EnumInfo<WithSynonyms>> expectedMembers =
                    GetExpectedMembers(
                        WithSynonyms.Zero,
                        WithSynonyms.OneDefinedFirst,
                        WithSynonyms.OneDefinedSecond
                    );

                // Act
                IReadOnlyCollection<EnumInfo<WithSynonyms>> definedMembers = EnumInfo<WithSynonyms>.DeclaredMembers;

                // Assert
                definedMembers.Should().ContainInConsecutiveOrder(expectedMembers);
            }

            [Fact]
            public void DefinedMembersExcludingSynonyms()
            {
                // Arrange
                List<EnumInfo<WithSynonyms>> expectedMembers =
                    GetExpectedMembers(
                        WithSynonyms.Zero,
                        WithSynonyms.OneDefinedFirst
                    );

                // Act
                IReadOnlyCollection<EnumInfo<WithSynonyms>> definedMembers = EnumInfo<WithSynonyms>.DeclaredMembersExcludingSynonyms;

                // Assert
                definedMembers.Should().ContainInConsecutiveOrder(expectedMembers);
            }

            private static List<EnumInfo<WithSynonyms>> GetExpectedMembers(params WithSynonyms[] values)
            {
                return
                    values
                        .Select(EnumInfo<WithSynonyms>.FromValue)
                        .ToList();
            }
        }

        public class FromNameTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(",")]
            [InlineData(" ,")]
            [InlineData(", ")]
            public void FromNullEmptyOrWhiteSpaceName(string? name)
            {
                // Arrange

                // Act
                Action sut = () => EnumInfo<WithNoFlagsWithZero>.FromName(name!);

                // Assert
                sut.Should().ThrowExactly<ArgumentException>();
            }

            [Theory]
            [InlineData("one")]
            [InlineData("One")]
            [InlineData("oNe")]
            [InlineData("ONe")]
            [InlineData("onE")]
            [InlineData("OnE")]
            [InlineData("oNE")]
            [InlineData("ONE")]
            public void NoFlagsFromSingleDefinedNonSynonymName(string specifiedName)
            {
                // Arrange
                string expectedName = nameof(WithNoFlagsWithZero.One);
                WithNoFlagsWithZero expectedValue = WithNoFlagsWithZero.One;
                int expectedUnderlyingValue = 1;

                // Act
                var info = EnumInfo<WithNoFlagsWithZero>.FromName(specifiedName);

                // Assert
                Assert.NotNull(info);

                info.Name.Should().Be(expectedName);
                info.Value.Should().Be(expectedValue);
                info.Value.Should().HaveValue(expectedUnderlyingValue);
                info.IsDefaultValue.Should().BeFalse();
                info.IsDefined.Should().BeTrue();
            }

            [Fact]
            public void NoFlagsFromSingleDefinedSynonymName()
            {
                // Arrange
                string expectedName = nameof(WithSynonyms.OneDefinedFirst);
                WithSynonyms expectedValue = WithSynonyms.OneDefinedFirst;
                int expectedUnderlyingValue = 1;

                // Act
                var info = EnumInfo<WithSynonyms>.FromName(nameof(WithSynonyms.OneDefinedSecond));

                // Assert
                Assert.NotNull(info);

                info.Name.Should().Be(expectedName);
                info.Value.Should().Be(expectedValue);
                info.Value.Should().HaveValue(expectedUnderlyingValue);
                info.IsDefaultValue.Should().BeFalse();
                info.IsDefined.Should().BeTrue();
            }

            [Fact]
            public void NoFlagsFromSingleNotDefinedName()
            {
                // Arrange
                string specifiedName = "NotDefined";
                string expectedParameterName = "name";
                string expectedMessageWildcardPattern = $"Enum member not found.*{expectedParameterName}*";

                var expectedData =
                    new ListDictionary()
                    {
                        ["Type"] = TypeHelper.GetTypeName<WithNoFlagsWithZero>(),
                        ["OriginalValue"] = specifiedName,
                        ["InvalidValues"] = new[] { specifiedName }
                    };

                // Act
                Func<EnumInfo<WithNoFlagsWithZero>?> sut = () => EnumInfo<WithNoFlagsWithZero>.FromName(specifiedName);

                // Assert
                sut
                    .Should()
                    .ThrowExactly<ArgumentException>()
                    .WithParameterName(expectedParameterName)
                    .WithMessage(expectedMessageWildcardPattern)
                    .Which.Data.Should().BeEquivalentTo(expectedData);
            }

            [Fact]
            public void NoFlagsFromMultipleDefinedNames()
            {
                // Arrange

                // Act
                Func<EnumInfo<WithNoFlagsWithZero>?> sut = () => EnumInfo<WithNoFlagsWithZero>.FromName("One, Two");

                // Assert
                sut.Should().ThrowExactly<InvalidOperationException>();
            }

            [Theory]
            [InlineData("Two, Three")]
            [InlineData("Two,Three")]
            [InlineData(" Two ,  Three  ")]
            [InlineData("two, three")]
            [InlineData("two,three")]
            public void FlagsFromMultipleDefinedNamesWithNoDefinedMemberOfTheirLogicalOperationResult(string specifiedName)
            {
                // Arrange
                string expectedName = "Two, Three";
                WithFlagsWithZero expectedValue = WithFlagsWithZero.Two | WithFlagsWithZero.Three;
                int expectedUnderlyingValue = 6;

                // Act
                var info = EnumInfo<WithFlagsWithZero>.FromName(specifiedName);

                // Assert
                Assert.NotNull(info);

                info.Name.Should().Be(expectedName);
                info.Value.Should().Be(expectedValue);
                info.Value.Should().HaveValue(expectedUnderlyingValue);
                info.IsDefaultValue.Should().BeFalse();
                info.IsDefined.Should().BeFalse();
            }

            [Fact]
            public void FlagsFromMultipleDefinedNamesWithDefinedMemberOfTheirLogicalOperationResult()
            {
                // Arrange
                string expectedName = "All";
                WithFlagsWithZero expectedValue = WithFlagsWithZero.All;
                int expectedUnderlyingValue = 15;

                // Act
                var info = EnumInfo<WithFlagsWithZero>.FromName("Zero, One, Two, Three, Four");

                // Assert
                Assert.NotNull(info);

                info.Name.Should().Be(expectedName);
                info.Value.Should().Be(expectedValue);
                info.Value.Should().HaveValue(expectedUnderlyingValue);
                info.IsDefaultValue.Should().BeFalse();
                info.IsDefined.Should().BeTrue();
            }

            [Fact]
            public void FlagsFromMultipleNamesIncludingInvalidName()
            {
                // Arrange
                string specifiedNames = "Zero, One, Two, Five";
                string expectedParameterName = "name";
                string expectedMessageWildcardPattern = $"Enum member not found.*{expectedParameterName}*";

                var expectedData =
                    new ListDictionary()
                    {
                        ["Type"] = TypeHelper.GetTypeName<WithFlagsWithNoZero>(),
                        ["OriginalValue"] = specifiedNames,
                        ["InvalidValues"] = new[] { "Zero", "Five" }
                    };

                // Act
                Func<EnumInfo<WithFlagsWithNoZero>?> sut = () => EnumInfo<WithFlagsWithNoZero>.FromName(specifiedNames);

                // Assert
                sut
                    .Should()
                    .ThrowExactly<ArgumentException>()
                    .WithParameterName(expectedParameterName)
                    .WithMessage(expectedMessageWildcardPattern)
                    .Which.Data.Should().BeEquivalentTo(expectedData);
            }
        }

        public class FromValueTests
        {
            [Fact]
            public void NoFlagsDefinedValue()
            {
                // Arrange

                // Act
                var info = EnumInfo.FromValue(WithNoFlagsWithZero.Three);

                // Assert
                Assert.NotNull(info);

                info.IsDefined.Should().BeTrue();
                info.Name.Should().Be(nameof(WithNoFlagsWithZero.Three));
                info.Value.Should().BeDefined();
                info.Value.Should().Be(WithNoFlagsWithZero.Three);
            }

            [Fact]
            public void NoFlagsDefinedDefaultValue()
            {
                // Arrange

                // Act
                var info = EnumInfo<WithNoFlagsWithZero>.FromValue(default);

                // Assert
                Assert.NotNull(info);

                info.IsDefaultValue.Should().BeTrue();
                info.IsDefined.Should().BeTrue();
                info.Name.Should().Be(nameof(WithNoFlagsWithZero.Zero));
                info.Value.Should().BeDefined();
                info.Value.Should().Be(WithNoFlagsWithZero.Zero);
            }

            [Fact]
            public void NoFlagsNotDefinedDefaultValue()
            {
                // Arrange

                // Act
                var info = EnumInfo<WithNoFlagsWithNoZero>.FromValue(default);

                // Assert
                Assert.NotNull(info);

                info.IsDefaultValue.Should().BeTrue();
                info.IsDefined.Should().BeFalse();
                info.Name.Should().BeEmpty();
                info.Value.Should().NotBeDefined();
                info.Value.Should().HaveValue(0);
            }

            [Theory]
            [InlineData((DayOfWeek)(-1))]
            [InlineData((DayOfWeek)7)]
            public void NoFlagsNotDefinedValue(DayOfWeek value)
            {
                // Arrange

                // Act
                Action sut = () => EnumInfo.FromValue(value);

                // Assert
                sut.Should().ThrowExactly<ArgumentException>();
            }

            [Fact]
            public void FlagsNotDefinedValueExceedsMaxValue()
            {
                // Arrange

                // Act
                Action sut = () => EnumInfo.FromValue((WithFlagsWithZero)16);

                // Assert
                sut.Should().ThrowExactly<ArgumentException>();
            }

            [Fact]
            public void FlagsNotDefinedValueBelowMaxValue()
            {
                // Arrange
                string expectedName = "Two, Three";
                WithFlagsWithZero expectedValue = WithFlagsWithZero.Two | WithFlagsWithZero.Three;
                int expectedUnderlyingValue = 6;

                // Act
                var info = EnumInfo.FromValue((WithFlagsWithZero)6);

                // Assert
                Assert.NotNull(info);

                info.IsDefaultValue.Should().BeFalse();
                info.IsDefined.Should().BeFalse();
                info.Name.Should().Be(expectedName);
                info.Value.Should().NotBeDefined();
                info.Value.Should().Be(expectedValue);
                info.Value.Should().HaveValue(expectedUnderlyingValue);
            }
        }

        public class FromUnderlyingValueTests
        {
            [Fact]
            public void NoFlagsDefinedValue()
            {
                // Arrange
                int underlyingValue = 1;

                // Act
                var info = EnumInfo<WithNoFlagsWithZero>.FromUnderlyingValue(underlyingValue);

                // Assert
                Assert.NotNull(info);

                info.IsDefined.Should().BeTrue();
                info.Name.Should().Be(nameof(WithNoFlagsWithZero.One));
                info.Value.Should().BeDefined();
                info.Value.Should().Be(WithNoFlagsWithZero.One);
            }

            [Fact]
            public void NoFlagsDefinedDefaultValue()
            {
                // Arrange
                int underlyingValue = 0;

                // Act
                var info = EnumInfo<WithNoFlagsWithZero>.FromUnderlyingValue(underlyingValue);

                // Assert
                Assert.NotNull(info);

                info.IsDefaultValue.Should().BeTrue();
                info.IsDefined.Should().BeTrue();
                info.Name.Should().Be(nameof(WithNoFlagsWithZero.Zero));
                info.Value.Should().BeDefined();
                info.Value.Should().Be(WithNoFlagsWithZero.Zero);
            }

            [Fact]
            public void NoFlagsNotDefinedDefaultValue()
            {
                // Arrange
                int underlyingValue = 0;

                // Act
                var info = EnumInfo<WithNoFlagsWithNoZero>.FromUnderlyingValue(underlyingValue);

                // Assert
                Assert.NotNull(info);

                info.IsDefaultValue.Should().BeTrue();
                info.IsDefined.Should().BeFalse();
                info.Name.Should().BeEmpty();
                info.Value.Should().NotBeDefined();
                info.Value.Should().HaveValue(0);
            }

            [Fact]
            public void NoFlagsNotDefinedValue()
            {
                // Arrange
                int underlyingValue = 7;

                // Act
                Action sut = () => EnumInfo<DayOfWeek>.FromUnderlyingValue(underlyingValue);

                // Assert
                sut.Should().ThrowExactly<ArgumentException>();
            }

            [Fact]
            public void FlagsNotDefinedValueExceedsMaxValue()
            {
                // Arrange
                int underlyingValue = 16;

                // Act
                Action sut = () => EnumInfo<WithFlagsWithZero>.FromUnderlyingValue(underlyingValue);

                // Assert
                sut.Should().ThrowExactly<ArgumentException>();
            }

            [Fact]
            public void FlagsNotDefinedValueBelowMaxValue()
            {
                // Arrange
                int underlyingValue = 6;
                string expectedName = "Two, Three";
                WithFlagsWithZero expectedValue = WithFlagsWithZero.Two | WithFlagsWithZero.Three;
                int expectedUnderlyingValue = 6;

                // Act
                var info = EnumInfo<WithFlagsWithZero>.FromUnderlyingValue(underlyingValue);

                // Assert
                Assert.NotNull(info);

                info.IsDefaultValue.Should().BeFalse();
                info.IsDefined.Should().BeFalse();
                info.Name.Should().Be(expectedName);
                info.Value.Should().NotBeDefined();
                info.Value.Should().Be(expectedValue);
                info.Value.Should().HaveValue(expectedUnderlyingValue);
            }
        }

        public class BitwiseOperatorsTests
        {
            [Fact]
            public void BitwiseComplement()
            {
                // Arrange
                string expectedName = "One, Two, Four";
                int expectedValue = 1 | 2 | 8;

                // Act
                var operand = EnumInfo<WithFlagsWithZero>.FromName("Three");
                EnumInfo<WithFlagsWithZero> result = ~operand;

                // Assert
                result.IsDefaultValue.Should().BeFalse();
                result.IsDefined.Should().BeFalse();
                result.Name.Should().Be(expectedName);
                result.Value.Should().NotBeDefined();
                result.Value.Should().HaveValue(expectedValue);
            }

            [Fact]
            public void BitwiseOr()
            {
                // Arrange
                string expectedName = "One, Two, Three";
                int expectedValue = 1 | 2 | 4;

                // Act
                EnumInfo<WithFlagsWithZero> result =
                    EnumInfo<WithFlagsWithZero>.FromName("One")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Two")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Three");

                // Assert
                result.IsDefaultValue.Should().BeFalse();
                result.IsDefined.Should().BeFalse();
                result.Name.Should().Be(expectedName);
                result.Value.Should().NotBeDefined();
                result.Value.Should().HaveValue(expectedValue);
            }

            [Fact]
            public void BitwiseAnd()
            {
                // Arrange
                string expectedName = "Two, Four";
                int expectedValue = 2 | 8;

                // Act
                EnumInfo<WithFlagsWithZero> operand1 =
                    EnumInfo<WithFlagsWithZero>.FromName("Two")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Three")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Four");

                EnumInfo<WithFlagsWithZero> operand2 =
                    EnumInfo<WithFlagsWithZero>.FromName("Two")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Four");

                EnumInfo<WithFlagsWithZero> result = operand1 & operand2;

                // Assert
                result.IsDefaultValue.Should().BeFalse();
                result.IsDefined.Should().BeFalse();
                result.Name.Should().Be(expectedName);
                result.Value.Should().NotBeDefined();
                result.Value.Should().HaveValue(expectedValue);
            }

            [Fact]
            public void BitwiseXor()
            {
                // Arrange
                string expectedName = "One, Four";
                int expectedValue = 1 | 8;

                // Act
                EnumInfo<WithFlagsWithZero> operand1 =
                    EnumInfo<WithFlagsWithZero>.FromName("One")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Two");

                EnumInfo<WithFlagsWithZero> operand2 =
                    EnumInfo<WithFlagsWithZero>.FromName("Two")
                    |
                    EnumInfo<WithFlagsWithZero>.FromName("Four");

                EnumInfo<WithFlagsWithZero> result = operand1 ^ operand2;

                // Assert
                result.IsDefaultValue.Should().BeFalse();
                result.IsDefined.Should().BeFalse();
                result.Name.Should().Be(expectedName);
                result.Value.Should().NotBeDefined();
                result.Value.Should().HaveValue(expectedValue);
            }
        }

        public class EqualityTests
        {
            [Fact]
            public void EqualityOperator()
            {
                // Arrange
                EnumInfo<DayOfWeek> left = DayOfWeek.Friday;
                EnumInfo<DayOfWeek> right = DayOfWeek.Friday;

                // Act
                bool result = left == right;

                // Assert
                result.Should().BeTrue();
                left.As<object>().Should().BeSameAs(right);
            }

            [Fact]
            public void InequalityOperator()
            {
                // Arrange
                EnumInfo<DayOfWeek> left = DayOfWeek.Friday;
                EnumInfo<DayOfWeek> right = DayOfWeek.Saturday;

                // Act
                bool result = left != right;

                // Assert
                result.Should().BeTrue();
            }

            [Fact]
            public void EqualsMethod()
            {
                // Arrange
                EnumInfo<DayOfWeek> left = DayOfWeek.Friday;
                EnumInfo<DayOfWeek> right = DayOfWeek.Friday;

                // Act
                bool result = left.Equals(right);

                // Assert
                result.Should().BeTrue();
                left.As<object>().Should().BeSameAs(right);
            }

            [Fact]
            public void StaticEqualsMethod()
            {
                // Arrange
                EnumInfo<DayOfWeek> left = DayOfWeek.Friday;
                EnumInfo<DayOfWeek> right = DayOfWeek.Friday;

                // Act
                bool result = EnumInfo<DayOfWeek>.Equals(left, right);

                // Assert
                result.Should().BeTrue();
                left.As<object>().Should().BeSameAs(right);
            }
        }

        public class EnumerableTests
        {
            [Fact]
            public void NoFlagsSingleMember()
            {
                // Arrange
                EnumInfo<DayOfWeek> item = DayOfWeek.Friday;
                int expectedCount = 1;

                // Act

                // Assert
                IEnumerable<EnumInfo<DayOfWeek>> enumerable = item.As<IEnumerable<EnumInfo<DayOfWeek>>>();

                enumerable.Should().HaveCount(expectedCount);
                enumerable.Should().ContainSingle();
                enumerable.Should().HaveElementAt(0, item);
            }

            [Fact]
            public void FlagsSingleMember()
            {
                // Arrange
                EnumInfo<WithFlagsWithZero> item = WithFlagsWithZero.Three;
                int expectedCount = 1;

                // Act

                // Assert
                IEnumerable<EnumInfo<WithFlagsWithZero>> enumerable = item.As<IEnumerable<EnumInfo<WithFlagsWithZero>>>();

                enumerable.Should().HaveCount(expectedCount);
                enumerable.Should().ContainSingle();
                enumerable.Should().HaveElementAt(0, item);
            }

            [Fact]
            public void FlagsMultipleMembersAsDefined()
            {
                // Arrange
                EnumInfo<WithFlagsWithZero> item =
                    WithFlagsWithZero.One
                    |
                    WithFlagsWithZero.Two
                    |
                    WithFlagsWithZero.Three
                    |
                    WithFlagsWithZero.Four;

                int expectedCount = 1;

                // Act

                // Assert
                IEnumerable<EnumInfo<WithFlagsWithZero>> enumerable = item.As<IEnumerable<EnumInfo<WithFlagsWithZero>>>();

                enumerable.Should().HaveCount(expectedCount);
                enumerable.Should().ContainSingle();
                enumerable.Should().HaveElementAt(0, item);
            }

            [Fact]
            public void FlagsMultipleMembersAsNotDefined()
            {
                // Arrange
                EnumInfo<WithFlagsWithZero> item =
                    WithFlagsWithZero.One
                    |
                    WithFlagsWithZero.Two
                    |
                    WithFlagsWithZero.Three;

                int expectedCount = 3;

                // Act

                // Assert
                Assert.NotNull(item);

                IEnumerable<EnumInfo<WithFlagsWithZero>> enumerable = item.As<IEnumerable<EnumInfo<WithFlagsWithZero>>>();

                enumerable.Should().HaveCount(expectedCount);
                enumerable.Should().HaveElementAt(0, WithFlagsWithZero.One);
                enumerable.Should().HaveElementAt(1, WithFlagsWithZero.Two);
                enumerable.Should().HaveElementAt(2, WithFlagsWithZero.Three);
            }
        }
    }
}
