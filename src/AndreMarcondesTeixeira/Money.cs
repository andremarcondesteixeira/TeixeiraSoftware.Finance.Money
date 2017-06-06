using System;

namespace AndreMarcondesTeixeira
{
    public partial class Money
    {
        public readonly decimal Amount;
        public readonly Currency Currency;

        public Money(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}