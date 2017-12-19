using System;

namespace TeixeiraSoftware.Finance
{
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>Addition operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>a new Money instance</returns>
        /// <exception cref="CurrencyMismatchException">
        ///     Thrown when the currencies are not the same
        /// </exception>
        public static Money operator + (Money left, Money right)
        {
            CheckForCurrencyMismatch(left, right);
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        /// <summary>Addition operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A decimal value</param>
        /// <returns>a new Money instance</returns>
        public static Money operator + (Money left, decimal right)
        {
            return left + new Money(right, left.Currency);
        }

        /// <summary>Addition operator</summary>
        /// <param name="left">A decimal value</param>
        /// <param name="right">A Money instance</param>
        /// <returns>a new Money instance</returns>
        public static Money operator + (decimal left, Money right)
        {
            return right + left;
        }

        /// <summary>Unary plus operator</summary>
        /// <param name="money">A Money instance</param>
        /// <returns>a new Money instance</returns>
        public static Money operator + (Money money)
        {
            return new Money(money.Amount, money.Currency);
        }

        /// <summary>Subtraction operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>a new Money instance</returns>
        /// <exception cref="CurrencyMismatchException">
        ///     Thrown when the currencies are not the same
        /// </exception>
        public static Money operator - (Money left, Money right)
        {
            CheckForCurrencyMismatch(left, right);
            return new Money(left.Amount - right.Amount, left.Currency);
        }

        /// <summary>Subtraction operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A decimal value</param>
        /// <returns>a new Money instance</returns>
        public static Money operator - (Money left, decimal right)
        {
            return left - new Money(right, left.Currency);
        }

        /// <summary>Subtraction operator</summary>
        /// <param name="left">A decimal value</param>
        /// <param name="right">A Money instance</param>
        /// <returns>a new Money instance</returns>
        public static Money operator - (decimal left, Money right)
        {
            return right - left;
        }

        /// <summary>Unary minus operator</summary>
        /// <param name="money">A Money instance</param>
        /// <returns>a new Money instance</returns>
        public static Money operator - (Money money)
        {
            return new Money(money.Amount * (-1), money.Currency);
        }

        /// <summary>Multiplication operator</summary>
        /// <remarks>
        ///     The multiplication operator only works against a factor, and was not
        ///     implemented to work against another Money instance
        /// </remarks>
        /// <param name="money">A Money instance</param>
        /// <param name="factor">A decimal factor</param>
        /// <returns>A new Money instance</returns>
        public static Money operator * (Money money, decimal factor)
        {
            return new Money(money.Amount * factor, money.Currency);
        }

        /// <summary>Multiplication operator</summary>
        /// <remarks>
        ///     The multiplication operator only works against a factor, and was not
        ///     implemented to work against another Money instance
        /// </remarks>
        /// <param name="factor">A decimal factor</param>
        /// <param name="money">A Money instance</param>
        /// <returns>A new Money instance</returns>
        public static Money operator * (decimal factor, Money money)
        {
            return money * factor;
        }

        /// <summary>Division operator</summary>
        /// <remarks>
        ///     The division operator only works against a factor, and was not
        ///     implemented to work against another Money instance
        /// </remarks>
        /// <param name="money">A Money instance</param>
        /// <param name="factor">A decimal factor</param>
        /// <returns>A new Money instance</returns>
        public static Money operator / (Money money, decimal factor)
        {
            return new Money(money.Amount / factor, money.Currency);
        }
    }
}