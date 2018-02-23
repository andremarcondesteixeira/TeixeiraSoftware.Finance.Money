using System;
using System.Collections.Generic;

namespace TeixeiraSoftware.Finance
{
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>Gets the hash code for this object</summary>
        /// <returns>The generated hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -1854965745;

            hashCode = hashCode * -1521134295 + EqualityComparer<decimal>.Default.GetHashCode(Amount);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICurrency>.Default.GetHashCode(Currency);

            return hashCode;
        }

        /// <summary>Performs equality check</summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or false</returns>
        /// <exception cref="CurrencyMismatchException">
        ///     Thrown when the currencies are not the same and the
        ///     <see cref="StrictEqualityComparisons" /> static property is set to true
        /// </exception>
        public override bool Equals(object obj)
        {
            if (obj is Money)
            {
                return this.Equals((Money) obj);
            }

            if (StrictEqualityComparisons)
            {
                throw new ArgumentException(
                    "A Money instance can only be compared against another Money instance"
                );
            }

            return false;
        }

        /// <summary>Performs equality check</summary>
        /// <param name="other">A Money instance</param>
        /// <returns>True or false</returns>
        /// <exception cref="CurrencyMismatchException">
        ///     Thrown when the currencies are not the same and the
        ///     <see cref="StrictEqualityComparisons" /> static property is set to true
        /// </exception>
        public bool Equals(Money other)
        {
            if (StrictEqualityComparisons)
            {
                return AreEquivalent(this, other);
            }

            return other.Currency.Equals(this.Currency) && other.Amount == this.Amount;
        }

        /// <summary>Performs comparison for sorting and ordering purposes</summary>
        /// <param name="other">Any object</param>
        /// <returns>
        ///     -1 if this current instance is less than the paremeter.
        ///     0 if this current instance have the same amount of money.
        ///     1 if this current instance is greater than the parameter.
        /// </returns>
        /// <exception cref="CurrencyMismatchException">
        ///     Thrown when the currencies are not the same
        /// </exception>
        public int CompareTo(object other)
        {
            if (other is Money)
            {
                return this.CompareTo((Money) other);
            }

            throw new ArgumentException(
                "A Money instance can only be compared against another Money instance"
            );
        }

        /// <summary>Performs comparison for sorting and ordering purposes</summary>
        /// <param name="other">A <see cref="Money" /> instance</param>
        /// <returns>
        ///     -1 if this current instance is less than the paremeter.
        ///     0 if this current instance have the same amount of money.
        ///     1 if this current instance is greater than the parameter.
        /// </returns>
        /// <exception cref="CurrencyMismatchException">
        ///     Thrown when the currencies are not the same
        /// </exception>
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

        private static bool AreEquivalent(Money left, Money right)
        {
            CheckForCurrencyMismatch(left, right);
            return left.Amount == right.Amount;
        }

        private static void CheckForCurrencyMismatch(Money left, Money right)
        {
            if (left.Currency.Equals(right.Currency))
            {
                throw new CurrencyMismatchException(left, right);
            }
        }
    }
}