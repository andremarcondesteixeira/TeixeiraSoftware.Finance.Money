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