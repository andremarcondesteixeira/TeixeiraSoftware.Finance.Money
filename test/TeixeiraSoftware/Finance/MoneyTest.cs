using Xunit;
using System;
using System.Collections.Generic;

namespace TeixeiraSoftware.Finance
{
    public class MoneyTest
    {
        private Money TenXXX;
        private Money TenXTS;
        private ICurrency XXXCurrency;
        private ICurrency XTSCurrency;

        public MoneyTest()
        {
            XXXCurrency = new CurrencyImplementation("XXX", "001", 0, "XXX Test Currency");
            XTSCurrency = new CurrencyImplementation("XTS", "002", 0, "XTS Test Currency");

            TenXXX = new Money(10.0m, XXXCurrency);
            TenXTS = new Money(10.0m, XTSCurrency);

            Money.StrictEqualityComparisons = false;
        }

        [Fact]
        public void Money_Can_Be_Instantiated()
        {
            var money = new Money(123.45m, XXXCurrency);

            Assert.Equal(money.Amount, 123.45m);
            Assert.Equal(money.Currency, XXXCurrency);
        }

        [Fact]
        public void Money_Is_A_Value_Type()
        {
            var money = TenXXX;
            Assert.False(Object.ReferenceEquals(TenXXX, money));
        }

        [Fact]
        public void Math_Operators()
        {
            Assert.Equal(20.0m, (TenXXX + TenXXX).Amount);
            Assert.Equal(10.0m, +TenXXX.Amount);
            Assert.Equal(11.5m, (TenXXX + 1.5m).Amount);
            Assert.Equal(11, (1 + TenXXX).Amount);
            Assert.Equal(0.0m, (TenXXX - TenXXX).Amount);
            Assert.Equal(-10.0m, -TenXXX.Amount);
            Assert.Equal(9, (TenXXX - 1).Amount);
            Assert.Equal(9.5m, (0.5m - TenXXX).Amount);
            Assert.Equal(20.0m, (TenXXX * 2.0m).Amount);
            Assert.Equal(30.0m, (3.0m * TenXXX).Amount);
            Assert.Equal(5.0m, (TenXXX / 2.0m).Amount);
        }

        [Fact]
        public void Comparison_Operators()
        {
            var anotherTenXXX = new Money(10.0m, XXXCurrency);
            var twentyXXX = new Money(20.0m, XXXCurrency);

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
            var minusTenXXX = new Money(-10.0m, XXXCurrency);

            Assert.Equal(-10.0m, +minusTenXXX.Amount);
            Assert.Equal(10.0m, +TenXXX.Amount);
        }

        [Fact]
        public void Unary_Minus_Operator_Inverts_The_Signal()
        {
            var minusTenXXX = new Money(-10.0m, XXXCurrency);

            Assert.Equal(10.0m, -minusTenXXX.Amount);
            Assert.Equal(-10.0m, -TenXXX.Amount);
        }

        [Fact]
        public void Cannot_Perform_Math_Operations_If_Currencies_Are_Different()
        {
            var exception1 = Assert.Throws<CurrencyMismatchException>(() => TenXXX + TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception1.Message);
            Assert.Equal(exception1.LeftOperand , TenXXX);
            Assert.Equal(exception1.RightOperand, TenXTS);

            var exception2 = Assert.Throws<CurrencyMismatchException>(() => TenXXX - TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception2.Message);
            Assert.Equal(exception2.LeftOperand, TenXXX);
            Assert.Equal(exception2.RightOperand, TenXTS);
        }

        [Fact]
        public void Cannot_Do_Some_Comparisons_If_Currencies_Are_Different()
        {
            var exception1 = Assert.Throws<CurrencyMismatchException>(() => TenXXX > TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception1.Message);
            Assert.Equal(exception1.LeftOperand, TenXXX);
            Assert.Equal(exception1.RightOperand, TenXTS);

            var exception2 = Assert.Throws<CurrencyMismatchException>(() => TenXXX < TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception2.Message);
            Assert.Equal(exception2.LeftOperand, TenXXX);
            Assert.Equal(exception2.RightOperand, TenXTS);

            var exception3 = Assert.Throws<CurrencyMismatchException>(() => TenXXX >= TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception3.Message);
            Assert.Equal(exception3.LeftOperand, TenXXX);
            Assert.Equal(exception3.RightOperand, TenXTS);

            var exception4 = Assert.Throws<CurrencyMismatchException>(() => TenXXX <= TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception4.Message);
            Assert.Equal(exception4.LeftOperand, TenXXX);
            Assert.Equal(exception4.RightOperand, TenXTS);
        }

        [Fact]
        public void Cannot_Do_Equality_Comparisons_If_Currencies_Are_Different_And_StrictEqualityComparisons_Is_True()
        {
            Money.StrictEqualityComparisons = true;

            var exception1 = Assert.Throws<CurrencyMismatchException>(() => TenXXX == TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception1.Message);
            Assert.Equal(exception1.LeftOperand, TenXXX);
            Assert.Equal(exception1.RightOperand, TenXTS);

            var exception2 = Assert.Throws<CurrencyMismatchException>(() => TenXXX.Equals(TenXTS));
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception2.Message);
            Assert.Equal(exception2.LeftOperand, TenXXX);
            Assert.Equal(exception2.RightOperand, TenXTS);

            var exception3 = Assert.Throws<CurrencyMismatchException>(() => TenXXX.Equals((object) TenXTS));
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception3.Message);
            Assert.Equal(exception3.LeftOperand, TenXXX);
            Assert.Equal(exception3.RightOperand, TenXTS);

            var exception4 = Assert.Throws<CurrencyMismatchException>(() => TenXXX != TenXTS);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception4.Message);
            Assert.Equal(exception4.LeftOperand, TenXXX);
            Assert.Equal(exception4.RightOperand, TenXTS);
        }

        [Fact]
        public void Money_Instances_Can_Be_Sorted()
        {
            var collection = new List<Money>
            {
                new Money(3, XXXCurrency),
                new Money(1, XXXCurrency),
                new Money(2, XXXCurrency)
            };

            collection.Sort();

            Assert.Equal(
                collection,
                new List<Money>
                {
                    new Money(1, XXXCurrency),
                    new Money(2, XXXCurrency),
                    new Money(3, XXXCurrency)
                }
            );
        }

        [Fact]
        public void Cannot_Sort_Money_Collections_With_Different_Currencies()
        {
            var money1 = new Money(1, XTSCurrency);
            var money2 = new Money(2, XXXCurrency);
            var money3 = new Money(3, XXXCurrency);

            var collection = new List<Money>
            {
                money3,
                money1,
                money2
            };

            var exception = Assert.Throws<InvalidOperationException>(() => collection.Sort());
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception.InnerException.Message);
            Assert.Equal(((CurrencyMismatchException) exception.InnerException).LeftOperand, money3);
            Assert.Equal(((CurrencyMismatchException) exception.InnerException).RightOperand, money1);
        }
    }
}