using Xunit;
using System;

namespace AndreMarcondesTeixeira
{
    public class MoneyTest
    {
        private Money TenXTS;

        public MoneyTest()
        {
            this.TenXTS = new Money(10.0m, Currency.XTS);
        }

        [Fact]
        public void Money_Instances_Are_Immutable()
        {
            Assert.False(Object.ReferenceEquals(TenXTS, +TenXTS));
            Assert.False(Object.ReferenceEquals(TenXTS, -TenXTS));
            Assert.False(Object.ReferenceEquals(TenXTS, TenXTS + TenXTS));
            Assert.False(Object.ReferenceEquals(TenXTS, TenXTS - TenXTS));
            Assert.False(Object.ReferenceEquals(TenXTS, 2 * TenXTS));
            Assert.False(Object.ReferenceEquals(TenXTS, TenXTS * 2));
            Assert.False(Object.ReferenceEquals(TenXTS, 1 / TenXTS));
            Assert.False(Object.ReferenceEquals(TenXTS, TenXTS / 1));
        }

        [Fact]
        public void Money_Intances_Are_Compatible_With_Math_And_Comparison_Operators()
        {
            var anotherTenXTS = new Money(10.0m, Currency.XTS);
            var twentyXTS = new Money(20.0m, Currency.XTS);

            // Math Operators
            Assert.Equal(20.0m, (TenXTS + TenXTS).Amount);
            Assert.Equal(10.0m, +TenXTS.Amount);
            Assert.Equal(0.0m, (TenXTS - TenXTS).Amount);
            Assert.Equal(-10.0m, -TenXTS.Amount);
            Assert.Equal(20.0m, (TenXTS * 2.0m).Amount);
            Assert.Equal(30.0m, (3.0m * TenXTS).Amount);
            Assert.Equal(5.0m, (TenXTS / 2.0m).Amount);
            Assert.Equal(0.2m, (2.0m / TenXTS).Amount);

            // Comparison Operators
            Assert.True(TenXTS == anotherTenXTS);
            Assert.False(TenXTS == twentyXTS);
            Assert.True(TenXTS != twentyXTS);
            Assert.False(TenXTS != anotherTenXTS);
            Assert.True(TenXTS.Equals(anotherTenXTS));
            Assert.False(TenXTS.Equals(twentyXTS));
            Assert.True(TenXTS < twentyXTS);
            Assert.False(twentyXTS < TenXTS);
            Assert.True(twentyXTS > TenXTS);
            Assert.False(TenXTS > twentyXTS);
            Assert.True(TenXTS <= anotherTenXTS);
            Assert.False(twentyXTS <= TenXTS);
            Assert.True(TenXTS >= anotherTenXTS);
            Assert.False(TenXTS >= twentyXTS);
        }

        [Fact]
        public void Unary_Plus_Operator_Keeps_The_Signal()
        {
            var minusTenXTS = new Money(-10.0m, Currency.XTS);

            Assert.Equal(-10.0m, +minusTenXTS.Amount);
            Assert.Equal(10.0m, +TenXTS.Amount);
        }

        [Fact]
        public void Unary_Minus_Operator_Inverts_The_Signal()
        {
            var minusTenXTS = new Money(-10.0m, Currency.XTS);

            Assert.Equal(10.0m, -minusTenXTS.Amount);
            Assert.Equal(-10.0m, -TenXTS.Amount);
        }

        [Fact]
        public void Money_Instances_Cannot_Use_Operators_When_Currencies_Are_Different()
        {
            var tenXXX = new Money(10.0m, Currency.XXX);
            var message = "Currencies must be the same";

            var exception1 = Assert.Throws<ArgumentException>(() => TenXTS + tenXXX);
            Assert.Equal(message, exception1.Message);

            var exception2 = Assert.Throws<ArgumentException>(() => TenXTS - tenXXX);
            Assert.Equal(message, exception2.Message);

            var exception3 = Assert.Throws<ArgumentException>(() => TenXTS == tenXXX);
            Assert.Equal(message, exception3.Message);

            var exception4 = Assert.Throws<ArgumentException>(() => TenXTS.Equals(tenXXX));
            Assert.Equal(message, exception4.Message);

            var exception5 = Assert.Throws<ArgumentException>(() => TenXTS != tenXXX);
            Assert.Equal(message, exception5.Message);

            var exception6 = Assert.Throws<ArgumentException>(() => TenXTS > tenXXX);
            Assert.Equal(message, exception6.Message);

            var exception7 = Assert.Throws<ArgumentException>(() => TenXTS < tenXXX);
            Assert.Equal(message, exception7.Message);

            var exception8 = Assert.Throws<ArgumentException>(() => TenXTS >= tenXXX);
            Assert.Equal(message, exception8.Message);

            var exception9 = Assert.Throws<ArgumentException>(() => TenXTS <= tenXXX);
            Assert.Equal(message, exception9.Message);
        }
    }
}