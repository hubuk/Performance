//-----------------------------------------------------------------------
// <copyright file="ProgressPercentageSpecification.cs" company="Leet">
//     © 2016 Leet. Licensed under the MIT License.
//     See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace Leet.Specifications.Performance
{
    using System;
    using System.Collections.Generic;
    using Leet;
    using Leet.Performance;
    using Xunit;

    /// <summary>
    ///     A class that specifies behavior for <see cref="ProgressPercentage"/> structure.
    /// </summary>
    public abstract class ProgressPercentageSpecification
    {
        private static readonly double OnePlusEpsilon = BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(1d) + 1);
        public static readonly IEnumerable<object[]> OnePlusEpsilonData = new[] { new object[] { OnePlusEpsilon } };
        
        [Fact]
        public void Type_Is_Structure()
        {
            // Fixture setup
            ProgressPercentage sut = new ProgressPercentage();

            // Exercise system

            // Verify outcome
            Assert.IsAssignableFrom(typeof(ValueType), sut);

            // Teardown
        }

        [Theory]
        [InlineData(typeof(IComparable))]
        [InlineData(typeof(IComparable<ProgressPercentage>))]
        [InlineData(typeof(IEquatable<ProgressPercentage>))]
        [InlineData(typeof(IFormattable))]
        public void Type_Implements_Interface(Type expectedInterfaceType)
        {
            // Fixture setup
            ProgressPercentage sut = new ProgressPercentage();

            // Exercise system

            // Verify outcome
            Assert.IsAssignableFrom(expectedInterfaceType, sut);

            // Teardown
        }

        [Theory]
        [AutoDomainData]
        public void DefaultConstructor_Always_InitializesWithDefaultValue()
        {
            // Fixture setup
            double expectedValue = default(double);

            // Exercise system
            ProgressPercentage sut = new ProgressPercentage();

            // Verify outcome
            Assert.Equal(expectedValue, sut.Value);

            // Teardown
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(1d)]
        [AutoDomainData]
        public void Constructor_CalledWithValidValue_AssignsToField(double progressPercentageValue)
        {
            // Fixture setup
            double expectedValue = progressPercentageValue;

            // Exercise system
            ProgressPercentage sut = new ProgressPercentage(progressPercentageValue);

            // Verify outcome
            Assert.Equal(expectedValue, sut.Value);

            // Teardown
        }

        [Theory]
        [InlineData(-1d)]
        [InlineData(-double.Epsilon)]
        [InlineData(double.MinValue)]
        [InlineData(double.NegativeInfinity)]
        public void Constructor_CalledWithValueLessThanZero_Throws(double value)
        {
            // Fixture setup

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
            {
                new ProgressPercentage(value);
            });

            // Teardown
        }

        [Theory]
        [InlineData(2d)]
        [MemberData(nameof(OnePlusEpsilonData))]
        [InlineData(double.MaxValue)]
        [InlineData(double.PositiveInfinity)]
        public void Constructor_CalledWithValueGreaterThanOne_Throws(double value)
        {
            // Fixture setup

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
            {
                new ProgressPercentage(value);
            });

            // Teardown
        }

        [Fact]
        public void Constructor_CalledWithNaNValue_Throws()
        {
            // Fixture setup
            double value = double.NaN;

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentException>(nameof(value), () =>
            {
                new ProgressPercentage(value);
            });

            // Teardown
        }

        [Fact]
        public void Zero_Always_HasZeroValue()
        {
            // Fixture setup
            double expectedValue = 0d;

            // Exercise system
            ProgressPercentage sut = ProgressPercentage.Zero;
            // Verify outcome
            Assert.Equal(expectedValue, sut.Value);

            // Teardown
        }

        [Fact]
        public void One_Always_HasOneValue()
        {
            // Fixture setup
            double expectedValue = 1d;

            // Exercise system
            ProgressPercentage sut = ProgressPercentage.One;
            // Verify outcome
            Assert.Equal(expectedValue, sut.Value);

            // Teardown
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(1d)]
        [AutoDomainData]
        public void ImplicitConversionToDouble_Always_ReturnsValue(double progressPercentageValue)
        {
            // Fixture setup
            ProgressPercentage sut = new ProgressPercentage(progressPercentageValue);
            double expectedValue = sut.Value;

            // Exercise system
            double actualValue = sut;

            // Verify outcome
            Assert.Equal(expectedValue, actualValue);

            // Teardown
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(1d)]
        [AutoDomainData]
        public void ImplicitConversionFromDouble_CalledWithValidValue_AssignsToField(double progressPercentageValue)
        {
            // Fixture setup
            double expectedValue = progressPercentageValue;

            // Exercise system
            ProgressPercentage sut = progressPercentageValue;

            // Verify outcome
            Assert.Equal(expectedValue, sut.Value);

            // Teardown
        }

        [Theory]
        [InlineData(-1d)]
        [InlineData(-double.Epsilon)]
        [InlineData(double.MinValue)]
        [InlineData(double.NegativeInfinity)]
        public void ImplicitConversionFromDouble_CalledWithValueLessThanZero_Throws(double value)
        {
            // Fixture setup

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
            {
                ProgressPercentage sut = value;
            });

            // Teardown
        }

        [Theory]
        [InlineData(2d)]
        [MemberData(nameof(OnePlusEpsilonData))]
        [InlineData(double.MaxValue)]
        [InlineData(double.PositiveInfinity)]
        public void ImplicitConversionFromDouble_CalledWithValueGreaterThanOne_Throws(double value)
        {
            // Fixture setup

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentOutOfRangeException>(nameof(value), () =>
            {
                ProgressPercentage sut = value;
            });

            // Teardown
        }

        [Fact]
        public void ImplicitConversionFromDouble_CalledWithNaNValue_Throws()
        {
            // Fixture setup
            double value = double.NaN;

            // Exercise system
            // Verify outcome
            Assert.Throws<ArgumentException>(nameof(value), () =>
            {
                ProgressPercentage sut = value;
            });

            // Teardown
        }

        [Fact]
        public void IsZero_ForZeroValue_ReturnsTrue()
        {
            // Fixture setup
            // Exercise system
            // Verify outcome
            Assert.True(ProgressPercentage.IsZero(ProgressPercentage.Zero));

            // Teardown
        }

        [Theory]
        [InlineData(1d)]
        [AutoDomainData]
        public void IsZero_ForNonZeroValue_ReturnsFalse(double progressPercentageValue)
        {
            // Fixture setup
            ProgressPercentage sut = new ProgressPercentage(progressPercentageValue);

            // Exercise system
            // Verify outcome
            Assert.False(ProgressPercentage.IsZero(sut));

            // Teardown
        }

        [Theory]
        [InlineData(0d)]
        [AutoDomainData]
        public void IsOne_ForNonOneValue_ReturnsFalse(double progressPercentageValue)
        {
            // Fixture setup
            ProgressPercentage sut = new ProgressPercentage(progressPercentageValue);

            // Exercise system
            // Verify outcome
            Assert.False(ProgressPercentage.IsOne(sut));

            // Teardown
        }

        [Fact]
        public void IsOne_ForOneValue_ReturnsTrue()
        {
            // Fixture setup
            // Exercise system
            // Verify outcome
            Assert.True(ProgressPercentage.IsOne(ProgressPercentage.One));

            // Teardown
        }
    }
}
