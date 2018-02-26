using System;
using Xunit;

namespace TeixeiraSoftware.Finance
{
    public class CurrencyMismatchExceptionTest
    {
        private Money TenUSD;
        private Money TenEUR;

        public CurrencyMismatchExceptionTest()
        {
            var USD = new CurrencyImplementation("USD");
            var EUR = new CurrencyImplementation("EUR");

            this.TenUSD = new Money(10, USD);
            this.TenEUR = new Money(10, EUR);
        }

        [Fact]
        public void Test_Constructor_Parameterless()
        {
            var exception = new CurrencyMismatchException();

            Assert.Equal(exception.Message, CurrencyMismatchException.DefaultMessage);
            Assert.Null(exception.LeftOperand);
            Assert.Null(exception.RightOperand);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void Test_Constructor_String()
        {
            var exception = new CurrencyMismatchException("test");

            Assert.Equal(exception.Message, "test");
            Assert.Null(exception.LeftOperand);
            Assert.Null(exception.RightOperand);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void Test_Constructor_Money_Money()
        {
            var exception = new CurrencyMismatchException(
                this.TenUSD,
                this.TenEUR
            );

            Assert.Equal(exception.Message, CurrencyMismatchException.DefaultMessage);
            Assert.Equal(exception.LeftOperand, this.TenUSD);
            Assert.Equal(exception.RightOperand, this.TenEUR);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void Test_Constructor_Exception()
        {
            var exception = new CurrencyMismatchException(new Exception("inner"));

            Assert.Equal(exception.Message, CurrencyMismatchException.DefaultMessage);
            Assert.Null(exception.LeftOperand);
            Assert.Null(exception.RightOperand);
            Assert.Equal(exception.InnerException.Message, "inner");
        }

        [Fact]
        public void Test_Constructor_String_Money_Money()
        {
            var exception = new CurrencyMismatchException(
                "test",
                this.TenUSD,
                this.TenEUR
            );

            Assert.Equal(exception.Message, "test");
            Assert.Equal(exception.LeftOperand, this.TenUSD);
            Assert.Equal(exception.RightOperand, this.TenEUR);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void Test_Constructor_String_Exception()
        {
            var exception = new CurrencyMismatchException(
                "test",
                new Exception("inner")
            );

            Assert.Equal(exception.Message, "test");
            Assert.Null(exception.LeftOperand);
            Assert.Null(exception.RightOperand);
            Assert.Equal(exception.InnerException.Message, "inner");
        }

        [Fact]
        public void Test_Constructor_Money_Money_Exception()
        {
            var exception = new CurrencyMismatchException(
                this.TenUSD,
                this.TenEUR,
                new Exception("inner")
            );

            Assert.Equal(exception.Message, CurrencyMismatchException.DefaultMessage);
            Assert.Equal(exception.LeftOperand, this.TenUSD);
            Assert.Equal(exception.RightOperand, this.TenEUR);
            Assert.Equal(exception.InnerException.Message, "inner");
        }

        [Fact]
        public void Test_Constructor_String_Money_Money_Exception()
        {
            var exception = new CurrencyMismatchException(
                "test",
                this.TenUSD,
                this.TenEUR,
                new Exception("inner")
            );

            Assert.Equal(exception.Message, "test");
            Assert.Equal(exception.LeftOperand, this.TenUSD);
            Assert.Equal(exception.RightOperand, this.TenEUR);
            Assert.Equal(exception.InnerException.Message, "inner");
        }
    }
}