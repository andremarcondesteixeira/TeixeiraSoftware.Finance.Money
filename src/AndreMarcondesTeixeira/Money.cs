using System;

namespace AndreMarcondesTeixeira
{
    public partial struct Money
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