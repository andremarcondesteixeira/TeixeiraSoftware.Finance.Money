namespace TeixeiraSoftware.Finance
{
    internal struct CurrencyImplementation : ICurrency
    {
        public string Symbol { get; }

        public CurrencyImplementation(string symbol)
        {
            this.Symbol = symbol;
        }

        public bool Equals(ICurrency other)
        {
            return this.Symbol == other.Symbol;
        }
    }
}
