using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>A money representation based on Martin Fowler's Money pattern</summary>
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>The amount of money in the given currency</summary>
        public readonly decimal Amount;

        /// <summary>A Currency instance</summary>
        public readonly Currency Currency;

        /// <summary>
        ///     Set this to true if you want the operators == and != to not allow
        ///     comparisons between instances with different currencies. Defaults
        ///     to false. When it is set to true, any comparisons against different
        ///     currencies will return false. When set to false, any try to compare
        ///     instances with different currencies will throw a CurrencyMismatchException
        /// </summary>
        public static bool StrictEqualityComparisons { get; set; } = false;

        /// <summary>AndreMarcondesTeixeira.Money constructor</summary>
        /// <param name="amount">The amount of money in the given currency</param>
        /// <param name="currency">A Currency instance</param>
        public Money(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}