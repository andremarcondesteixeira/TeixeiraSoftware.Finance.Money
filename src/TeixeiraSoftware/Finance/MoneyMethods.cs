using System;

namespace TeixeiraSoftware.Finance
{
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
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
                return ((Money) obj).Equals(this);
            }

            return false;
        }

        /// <summary>Performs equality check</summary>
        /// <param name="other">A Money instance</param>
        /// <returns>True or false</returns>
        public bool Equals(Money other)
        {
            if (StrictEqualityComparisons)
            {
                return AreEquivalent(this, other);
            }

            return other.Currency == this.Currency && other.Amount == this.Amount;
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