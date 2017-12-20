using System;
using Xunit;

namespace TeixeiraSoftware.Finance
{
    public class CurrencyMismatchExceptionTest
    {
        private Money TenXXX;
        private Money TenXTS;

        public CurrencyMismatchExceptionTest()
        {
            this.TenXXX = new Money(10, Currency.XXX);
            this.TenXTS = new Money(10, Currency.XTS);
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
                this.TenXXX,
                this.TenXTS
            );

            Assert.Equal(exception.Message, CurrencyMismatchException.DefaultMessage);
            Assert.Equal(exception.LeftOperand, this.TenXXX);
            Assert.Equal(exception.RightOperand, this.TenXTS);
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
                this.TenXXX,
                this.TenXTS
            );

            Assert.Equal(exception.Message, "test");
            Assert.Equal(exception.LeftOperand, this.TenXXX);
            Assert.Equal(exception.RightOperand, this.TenXTS);
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
                this.TenXXX,
                this.TenXTS,
                new Exception("inner")
            );

            Assert.Equal(exception.Message, CurrencyMismatchException.DefaultMessage);
            Assert.Equal(exception.LeftOperand, this.TenXXX);
            Assert.Equal(exception.RightOperand, this.TenXTS);
            Assert.Equal(exception.InnerException.Message, "inner");
        }

        [Fact]
        public void Test_Constructor_String_Money_Money_Exception()
        {
            var exception = new CurrencyMismatchException(
                "test",
                this.TenXXX,
                this.TenXTS,
                new Exception("inner")
            );

            Assert.Equal(exception.Message, "test");
            Assert.Equal(exception.LeftOperand, this.TenXXX);
            Assert.Equal(exception.RightOperand, this.TenXTS);
            Assert.Equal(exception.InnerException.Message, "inner");
        }
    }
}