using Xunit;
using System;
using System.Collections.Generic;

namespace TeixeiraSoftware.Finance
{
    public class MoneyTest
    {
        private Money TenXXX;
        private Money TenXTS;

        public MoneyTest()
        {
            this.TenXXX = new Money(10.0m, Currency.XXX);
            this.TenXTS = new Money(10.0m, Currency.XTS);
            Money.StrictEqualityComparisons = false;
        }

        [Fact]
        public void Math_Operators()
        {
            Assert.Equal(20.0m, (TenXXX + TenXXX).Amount);
            Assert.Equal(10.0m, +TenXXX.Amount);
            Assert.Equal(0.0m, (TenXXX - TenXXX).Amount);
            Assert.Equal(-10.0m, -TenXXX.Amount);
            Assert.Equal(20.0m, (TenXXX * 2.0m).Amount);
            Assert.Equal(30.0m, (3.0m * TenXXX).Amount);
            Assert.Equal(5.0m, (TenXXX / 2.0m).Amount);
        }

        [Fact]
        public void Comparison_Operators()
        {
            var anotherTenXXX = new Money(10.0m, Currency.XXX);
            var twentyXXX = new Money(20.0m, Currency.XXX);

            // operator ==
            Assert.True(TenXXX == anotherTenXXX);
            Assert.False(TenXXX == TenXTS);
            Assert.False(TenXXX == twentyXXX);
            Assert.False(TenXTS == twentyXXX);

            // operator !=
            Assert.False(TenXXX != anotherTenXXX);
            Assert.True(TenXXX != TenXTS);
            Assert.True(TenXXX != twentyXXX);
            Assert.True(TenXTS != twentyXXX);
            
            // Equals method
            Assert.True(TenXXX.Equals(anotherTenXXX));
            Assert.True(TenXXX.Equals((object) anotherTenXXX));
            Assert.False(TenXXX.Equals(TenXTS));
            Assert.False(TenXXX.Equals((object) TenXTS));
            Assert.False(TenXXX.Equals(twentyXXX));
            Assert.False(TenXXX.Equals((object) twentyXXX));
            Assert.False(TenXTS.Equals(twentyXXX));
            Assert.False(TenXTS.Equals((object) twentyXXX));
            
            // operator <
            Assert.True(TenXXX < twentyXXX);
            Assert.False(twentyXXX < TenXXX);
            
            // operator <=
            Assert.True(TenXXX <= anotherTenXXX);
            Assert.False(twentyXXX <= TenXXX);
            
            //operator >
            Assert.True(twentyXXX > TenXXX);
            Assert.False(TenXXX > twentyXXX);
            
            // operator >=
            Assert.True(TenXXX >= anotherTenXXX);
            Assert.False(TenXXX >= twentyXXX);
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
        public void Cannot_Perform_Math_Operations_If_Currencies_Are_Different()
        {
            var message = "Currencies must be the same";

            var exception1 = Assert.Throws<ArgumentException>(() => TenXXX + TenXTS);
            Assert.Equal(message, exception1.Message);

            var exception2 = Assert.Throws<ArgumentException>(() => TenXXX - TenXTS);
            Assert.Equal(message, exception2.Message);
        }

        [Fact]
        public void Cannot_Do_Some_Comparisons_If_Currencies_Are_Different()
        {
            var message = "Currencies must be the same";

            var exception1 = Assert.Throws<ArgumentException>(() => TenXXX > TenXTS);
            Assert.Equal(message, exception1.Message);

            var exception2 = Assert.Throws<ArgumentException>(() => TenXXX < TenXTS);
            Assert.Equal(message, exception2.Message);

            var exception3 = Assert.Throws<ArgumentException>(() => TenXXX >= TenXTS);
            Assert.Equal(message, exception3.Message);

            var exception4 = Assert.Throws<ArgumentException>(() => TenXXX <= TenXTS);
            Assert.Equal(message, exception4.Message);
        }

        [Fact]
        public void Cannot_Do_Equality_Comparison_If_Currencies_Are_Different_And_StrictEqualityComparisons_Is_True()
        {
            var message = "Currencies must be the same";
            Money.StrictEqualityComparisons = true;

            var exception1 = Assert.Throws<ArgumentException>(() => TenXXX == TenXTS);
            Assert.Equal(message, exception1.Message);

            var exception2 = Assert.Throws<ArgumentException>(() => TenXXX.Equals(TenXTS));
            Assert.Equal(message, exception2.Message);

            var exception3 = Assert.Throws<ArgumentException>(() => TenXXX.Equals((object) TenXTS));
            Assert.Equal(message, exception3.Message);

            var exception4 = Assert.Throws<ArgumentException>(() => TenXXX != TenXTS);
            Assert.Equal(message, exception4.Message);
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