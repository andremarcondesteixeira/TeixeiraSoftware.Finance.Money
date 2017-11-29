using Xunit;
using System;
using System.Collections.Generic;

namespace AndreMarcondesTeixeira
{
    public class MoneyTest
    {
        private Money TenXXX;

        public MoneyTest()
        {
            this.TenXXX = new Money(10.0m, Currency.XXX);
        }

        [Fact]
        public void Money_Intances_Are_Compatible_With_Math_Operators()
        {
            Assert.Equal(20.0m, (TenXXX + TenXXX).Amount);
            Assert.Equal(10.0m, +TenXXX.Amount);
            Assert.Equal(0.0m, (TenXXX - TenXXX).Amount);
            Assert.Equal(-10.0m, -TenXXX.Amount);
            Assert.Equal(20.0m, (TenXXX * 2.0m).Amount);
            Assert.Equal(30.0m, (3.0m * TenXXX).Amount);
            Assert.Equal(5.0m, (TenXXX / 2.0m).Amount);
            Assert.Equal(0.2m, (2.0m / TenXXX).Amount);
        }

        [Fact]
        public void Money_Intances_Are_Compatible_With_Comparison_Operators()
        {
            var anotherTenXTS = new Money(10.0m, Currency.XTS);
            var twentyXTS = new Money(20.0m, Currency.XTS);

            Assert.True(TenXXX == anotherTenXTS);
            Assert.False(TenXXX == twentyXTS);
            Assert.True(TenXXX != twentyXTS);
            Assert.False(TenXXX != anotherTenXTS);
            Assert.True(TenXXX.Equals(anotherTenXTS));
            Assert.False(TenXXX.Equals(twentyXTS));
            Assert.True(TenXXX < twentyXTS);
            Assert.False(twentyXTS < TenXXX);
            Assert.True(twentyXTS > TenXXX);
            Assert.False(TenXXX > twentyXTS);
            Assert.True(TenXXX <= anotherTenXTS);
            Assert.False(twentyXTS <= TenXXX);
            Assert.True(TenXXX >= anotherTenXTS);
            Assert.False(TenXXX >= twentyXTS);
        }

        [Fact]
        public void Unary_Plus_Operator_Keeps_The_Signal()
        {
            var minusTenXXX = new Money(-10.0m, Currency.XXX);

            Assert.Equal(-10.0m, +minusTenXXX.Amount);
            Assert.Equal(10.0m, +TenXXX.Amount);
        }

        [Fact]
        public void Unary_Minus_Operator_Inverts_The_Signal()
        {
            var minusTenXXX = new Money(-10.0m, Currency.XXX);

            Assert.Equal(10.0m, -minusTenXXX.Amount);
            Assert.Equal(-10.0m, -TenXXX.Amount);
        }

        [Fact]
        public void Money_Instances_Cannot_Use_Operators_When_Currencies_Are_Different()
        {
            var tenXXX = new Money(10.0m, Currency.XXX);
            var message = "Currencies must be the same";

            var exception1 = Assert.Throws<ArgumentException>(() => TenXXX + tenXXX);
            Assert.Equal(message, exception1.Message);

            var exception2 = Assert.Throws<ArgumentException>(() => TenXXX - tenXXX);
            Assert.Equal(message, exception2.Message);

            var exception3 = Assert.Throws<ArgumentException>(() => TenXXX == tenXXX);
            Assert.Equal(message, exception3.Message);

            var exception4 = Assert.Throws<ArgumentException>(() => TenXXX.Equals(tenXXX));
            Assert.Equal(message, exception4.Message);

            var exception5 = Assert.Throws<ArgumentException>(() => TenXXX != tenXXX);
            Assert.Equal(message, exception5.Message);

            var exception6 = Assert.Throws<ArgumentException>(() => TenXXX > tenXXX);
            Assert.Equal(message, exception6.Message);

            var exception7 = Assert.Throws<ArgumentException>(() => TenXXX < tenXXX);
            Assert.Equal(message, exception7.Message);

            var exception8 = Assert.Throws<ArgumentException>(() => TenXXX >= tenXXX);
            Assert.Equal(message, exception8.Message);

            var exception9 = Assert.Throws<ArgumentException>(() => TenXXX <= tenXXX);
            Assert.Equal(message, exception9.Message);
        }

        [Fact]
        public void Money_Instances_Can_Be_Sorted()
        {
            var collection = new List<Money>
            {
                new Money()
            };
        }
    }
}