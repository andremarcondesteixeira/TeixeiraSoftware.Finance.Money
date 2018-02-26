using Xunit;
using System;
using System.Collections.Generic;

namespace TeixeiraSoftware.Finance
{
    public class MoneyTest
    {
        private ICurrency USD;
        private ICurrency EUR;
        private Money TenUSD;
        private Money TenEUR;

        public MoneyTest()
        {
            USD = new CurrencyImplementation("USD");
            EUR = new CurrencyImplementation("EUR");

            TenUSD = new Money(10.0m, USD);
            TenEUR = new Money(10.0m, EUR);

            Money.StrictEqualityComparisons = false;
        }

        [Fact]
        public void Money_Can_Be_Instantiated()
        {
            var money = new Money(123.45m, USD);

            Assert.Equal(money.Amount, 123.45m);
            Assert.Equal(money.Currency, USD);
        }

        [Fact]
        public void Money_Is_A_Value_Type()
        {
            var money = TenUSD;
            Assert.False(Object.ReferenceEquals(TenUSD, money));
        }

        [Fact]
        public void Math_Operators()
        {
            Assert.Equal(20.0m, (TenUSD + TenUSD).Amount);
            Assert.Equal(10.0m, +TenUSD.Amount);
            Assert.Equal(11.5m, (TenUSD + 1.5m).Amount);
            Assert.Equal(11, (1 + TenUSD).Amount);
            Assert.Equal(0.0m, (TenUSD - TenUSD).Amount);
            Assert.Equal(-10.0m, -TenUSD.Amount);
            Assert.Equal(9, (TenUSD - 1).Amount);
            Assert.Equal(9.5m, (0.5m - TenUSD).Amount);
            Assert.Equal(20.0m, (TenUSD * 2.0m).Amount);
            Assert.Equal(30.0m, (3.0m * TenUSD).Amount);
            Assert.Equal(5.0m, (TenUSD / 2.0m).Amount);
        }

        [Fact]
        public void Comparison_Operators()
        {
            var anotherTenUSD = new Money(10.0m, USD);
            var twentyXXX = new Money(20.0m, USD);

            // operator ==
            Assert.True(TenUSD == anotherTenUSD);
            Assert.False(TenUSD == TenEUR);
            Assert.False(TenUSD == twentyXXX);
            Assert.False(TenEUR == twentyXXX);

            // operator !=
            Assert.False(TenUSD != anotherTenUSD);
            Assert.True(TenUSD != TenEUR);
            Assert.True(TenUSD != twentyXXX);
            Assert.True(TenEUR != twentyXXX);
            
            // Equals method
            Assert.True(TenUSD.Equals(anotherTenUSD));
            Assert.True(TenUSD.Equals((object) anotherTenUSD));
            Assert.False(TenUSD.Equals(TenEUR));
            Assert.False(TenUSD.Equals((object) TenEUR));
            Assert.False(TenUSD.Equals(twentyXXX));
            Assert.False(TenUSD.Equals((object) twentyXXX));
            Assert.False(TenEUR.Equals(twentyXXX));
            Assert.False(TenEUR.Equals((object) twentyXXX));
            
            // operator <
            Assert.True(TenUSD < twentyXXX);
            Assert.False(twentyXXX < TenUSD);
            
            // operator <=
            Assert.True(TenUSD <= anotherTenUSD);
            Assert.False(twentyXXX <= TenUSD);
            
            //operator >
            Assert.True(twentyXXX > TenUSD);
            Assert.False(TenUSD > twentyXXX);
            
            // operator >=
            Assert.True(TenUSD >= anotherTenUSD);
            Assert.False(TenUSD >= twentyXXX);
        }

        [Fact]
        public void Unary_Plus_Operator_Keeps_The_Signal()
        {
            var minusTenUSD = new Money(-10.0m, USD);

            Assert.Equal(-10.0m, +minusTenUSD.Amount);
            Assert.Equal(10.0m, +TenUSD.Amount);
        }

        [Fact]
        public void Unary_Minus_Operator_Inverts_The_Signal()
        {
            var minusTenUSD = new Money(-10.0m, USD);

            Assert.Equal(10.0m, -minusTenUSD.Amount);
            Assert.Equal(-10.0m, -TenUSD.Amount);
        }

        [Fact]
        public void Cannot_Perform_Math_Operations_If_Currencies_Are_Different()
        {
            var exception1 = Assert.Throws<CurrencyMismatchException>(() => TenUSD + TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception1.Message);
            Assert.Equal(exception1.LeftOperand , TenUSD);
            Assert.Equal(exception1.RightOperand, TenEUR);

            var exception2 = Assert.Throws<CurrencyMismatchException>(() => TenUSD - TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception2.Message);
            Assert.Equal(exception2.LeftOperand, TenUSD);
            Assert.Equal(exception2.RightOperand, TenEUR);
        }

        [Fact]
        public void Cannot_Do_Some_Comparisons_If_Currencies_Are_Different()
        {
            var exception1 = Assert.Throws<CurrencyMismatchException>(() => TenUSD > TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception1.Message);
            Assert.Equal(exception1.LeftOperand, TenUSD);
            Assert.Equal(exception1.RightOperand, TenEUR);

            var exception2 = Assert.Throws<CurrencyMismatchException>(() => TenUSD < TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception2.Message);
            Assert.Equal(exception2.LeftOperand, TenUSD);
            Assert.Equal(exception2.RightOperand, TenEUR);

            var exception3 = Assert.Throws<CurrencyMismatchException>(() => TenUSD >= TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception3.Message);
            Assert.Equal(exception3.LeftOperand, TenUSD);
            Assert.Equal(exception3.RightOperand, TenEUR);

            var exception4 = Assert.Throws<CurrencyMismatchException>(() => TenUSD <= TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception4.Message);
            Assert.Equal(exception4.LeftOperand, TenUSD);
            Assert.Equal(exception4.RightOperand, TenEUR);
        }

        [Fact]
        public void Cannot_Compare_Money_Instance_Agains_Other_Types_Than_Money_When_StrictEqualityComparisons_Is_True()
        {
            Money.StrictEqualityComparisons = true;
            var exception = Assert.Throws<ArgumentException>(() => TenUSD.Equals(new Object()));
            Assert.Equal(Money.TypeMismatchErrorMessage, exception.Message);
        }

        [Fact]
        public void Cannot_Do_Equality_Comparisons_If_Currencies_Are_Different_And_StrictEqualityComparisons_Is_True()
        {
            Money.StrictEqualityComparisons = true;

            var exception1 = Assert.Throws<CurrencyMismatchException>(() => TenUSD == TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception1.Message);
            Assert.Equal(exception1.LeftOperand, TenUSD);
            Assert.Equal(exception1.RightOperand, TenEUR);

            var exception2 = Assert.Throws<CurrencyMismatchException>(() => TenUSD.Equals(TenEUR));
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception2.Message);
            Assert.Equal(exception2.LeftOperand, TenUSD);
            Assert.Equal(exception2.RightOperand, TenEUR);

            var exception3 = Assert.Throws<CurrencyMismatchException>(() => TenUSD.Equals((object) TenEUR));
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception3.Message);
            Assert.Equal(exception3.LeftOperand, TenUSD);
            Assert.Equal(exception3.RightOperand, TenEUR);

            var exception4 = Assert.Throws<CurrencyMismatchException>(() => TenUSD != TenEUR);
            Assert.Equal(CurrencyMismatchException.DefaultMessage, exception4.Message);
            Assert.Equal(exception4.LeftOperand, TenUSD);
            Assert.Equal(exception4.RightOperand, TenEUR);
        }

        [Fact]
        public void Money_Instances_Can_Be_Sorted()
        {
            var collection = new List<Money>
            {
                new Money(3, USD),
                new Money(1, USD),
                new Money(2, USD)
            };

            collection.Sort();

            Assert.Equal(
                collection,
                new List<Money>
                {
                    new Money(1, USD),
                    new Money(2, USD),
                    new Money(3, USD)
                }
            );
        }

        [Fact]
        public void Cannot_Sort_Money_Collections_With_Different_Currencies()
        {
            var money1 = new Money(1, EUR);
            var money2 = new Money(2, USD);
            var money3 = new Money(3, USD);

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

        [Fact]
        public void Cannot_Sort_Money_Collections_With_Other_Types_Than_Money()
        {
            var money = new Money(1, EUR);
            var someObject = new Object();

            var collection = new List<Object>
            {
                money,
                someObject
            };

            var exception = Assert.Throws<InvalidOperationException>(() => collection.Sort());
            Assert.IsType<ArgumentException>(exception.InnerException);
            Assert.Equal(Money.TypeMismatchErrorMessage, exception.InnerException.Message);
        }
    }
}