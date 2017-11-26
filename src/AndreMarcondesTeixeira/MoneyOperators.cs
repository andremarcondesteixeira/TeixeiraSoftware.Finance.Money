using System;

namespace AndreMarcondesTeixeira
{
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>Addition operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>a new Money instance</returns>
        public static Money operator + (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return new Money(left.Amount + right.Amount, left.Currency);
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
        public static Money operator - (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return new Money(left.Amount - right.Amount, left.Currency);
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
            return new Money(money.Amount * factor, money.Currency);
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

        /// <summary>Division operator</summary>
        /// <remarks>
        ///     The division operator only works against a factor, and was not
        ///     implemented to work against another Money instance
        /// </remarks>
        /// <param name="factor">A decimal factor</param>
        /// <param name="money">A Money instance</param>
        /// <returns>A new Money instance</returns>
        public static Money operator / (decimal factor, Money money)
        {
            return new Money(factor / money.Amount, money.Currency);
        }

        /// <summary>Equality comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator == (Money left, Money right)
        {
            return AreEquivalent(left, right);
        }

        /// <summary>Inequality comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator != (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Currency != right.Currency || left.Amount != right.Amount;
        }

        /// <summary>"Greater than" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator > (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount > right.Amount;
        }

        /// <summary>"Less than" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator < (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount < right.Amount;
        }

        /// <summary>"Greater than or equal to" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator >= (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount >= right.Amount;
        }

        /// <summary>"Less then or equal to" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator <= (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount <= right.Amount;
        }

        /// <summary>The Hash Code from Object</summary>
        /// <returns>The Hash Code from Object</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>Performs equality check</summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Money)
            {
                return AreEquivalent(this, (Money) obj);
            }

            return false;
        }

        /// <summary>Performs equality check<summary>
        /// <param name="other">A Money instance</param>
        /// <returns>True or false</returns>
        public bool Equals(Money other)
        {
            return AreEquivalent(this, other);
        }

        /// <summary>Performs comparison for sorting and ordering purposes</summary>
        /// <param name="obj">Any object</param>
        /// <returns>
        ///     -1 if this current instance is less than the paremeter.
        ///     0 if this current instance have the same amount of money.
        ///     1 if this current instance is greater than the parameter.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj is Money)
            {
                return this.CompareTo((Money) obj);
            }

            throw new ArgumentException(
                "A Money instance can only be compared against another Money instance"
            );
        }

        /// <summary>Performs comparison for sorting and ordering purposes</summary>
        /// <param name="other">A Money instance</param>
        /// <returns>
        ///     -1 if this current instance is less than the paremeter.
        ///     0 if this current instance have the same amount of money.
        ///     1 if this current instance is greater than the parameter.
        /// </returns>
        public int CompareTo(Money other)
        {
            if (AreEquivalent(this, other))
            {
                return 0;
            }

            if (this > other)
            {
                return 1;
            }

            return -1;
        }

        private static bool AreEquivalent(Money a, Money b)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(a, b);
            return a.Amount == b.Amount;
        }

        private static void ThrowArgumentExceptionIfCurrenciesAreNotTheSame(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Currencies must be the same");
            }
        }
    }
}