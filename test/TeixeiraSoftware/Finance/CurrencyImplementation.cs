namespace TeixeiraSoftware.Finance
{
    internal struct CurrencyImplementation : ICurrency
    {
        public string Name { get; }
        public string AlphabeticCode { get; }
        public string NumericCode { get; }
        public byte MinorUnits { get; }

        public CurrencyImplementation(
            string alphabeticCode,
            string numericCode,
            byte minorUnits,
            string name
        )
        {
            this.AlphabeticCode = alphabeticCode;
            this.NumericCode = numericCode;
            this.MinorUnits = minorUnits;
            this.Name = name;
        }

        public bool Equals(ICurrency other)
        {
            return this.AlphabeticCode == other.AlphabeticCode;
        }
    }
}
