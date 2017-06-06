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
        public void Money_Instances_Cannot_Use_Operators_Against_Null()
        {
            var message = "Money must not be null";
            Money nullMoney = null;

            // Math Operators
            var exception01 = Assert.Throws<ArgumentException>(() => (+nullMoney));
            Assert.Equal(message, exception01.Message);

            var exception02 = Assert.Throws<ArgumentException>(() => (nullMoney + TenXTS));
            Assert.Equal(message, exception02.Message);

            var exception03 = Assert.Throws<ArgumentException>(() => (TenXTS + nullMoney));
            Assert.Equal(message, exception03.Message);

            var exception04 = Assert.Throws<ArgumentException>(() => (-nullMoney));
            Assert.Equal(message, exception04.Message);

            var exception05 = Assert.Throws<ArgumentException>(() => (nullMoney - TenXTS));
            Assert.Equal(message, exception05.Message);

            var exception06 = Assert.Throws<ArgumentException>(() => (TenXTS - nullMoney));
            Assert.Equal(message, exception06.Message);

            var exception07 = Assert.Throws<ArgumentException>(() => (nullMoney * 2));
            Assert.Equal(message, exception07.Message);

            var exception08 = Assert.Throws<ArgumentException>(() => (2 * nullMoney));
            Assert.Equal(message, exception08.Message);

            var exception09 = Assert.Throws<ArgumentException>(() => (nullMoney / 2));
            Assert.Equal(message, exception09.Message);

            var exception10 = Assert.Throws<ArgumentException>(() => (2 / nullMoney));
            Assert.Equal(message, exception10.Message);

            // Comparison Operators
            var exception11 = Assert.Throws<ArgumentException>(() => (nullMoney == TenXTS));
            Assert.Equal(message, exception11.Message);

            var exception12 = Assert.Throws<ArgumentException>(() => (TenXTS == nullMoney));
            Assert.Equal(message, exception12.Message);

            var exception13 = Assert.Throws<ArgumentException>(() => (nullMoney != TenXTS));
            Assert.Equal(message, exception13.Message);

            var exception14 = Assert.Throws<ArgumentException>(() => (TenXTS != nullMoney));
            Assert.Equal(message, exception14.Message);

            var exception15 = Assert.Throws<ArgumentException>(() => (TenXTS.Equals(nullMoney)));
            Assert.Equal(message, exception15.Message);

            var exception16 = Assert.Throws<ArgumentException>(() => (nullMoney < TenXTS));
            Assert.Equal(message, exception16.Message);

            var exception17 = Assert.Throws<ArgumentException>(() => (TenXTS < nullMoney));
            Assert.Equal(message, exception17.Message);

            var exception18 = Assert.Throws<ArgumentException>(() => (nullMoney > TenXTS));
            Assert.Equal(message, exception18.Message);

            var exception19 = Assert.Throws<ArgumentException>(() => (TenXTS > nullMoney));
            Assert.Equal(message, exception19.Message);

            var exception20 = Assert.Throws<ArgumentException>(() => (nullMoney <= TenXTS));
            Assert.Equal(message, exception20.Message);

            var exception21 = Assert.Throws<ArgumentException>(() => (TenXTS <= nullMoney));
            Assert.Equal(message, exception21.Message);

            var exception22 = Assert.Throws<ArgumentException>(() => (nullMoney >= TenXTS));
            Assert.Equal(message, exception22.Message);

            var exception23 = Assert.Throws<ArgumentException>(() => (TenXTS >= nullMoney));
            Assert.Equal(message, exception23.Message);
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