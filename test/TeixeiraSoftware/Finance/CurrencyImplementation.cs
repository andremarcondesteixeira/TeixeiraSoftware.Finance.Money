namespace TeixeiraSoftware.Finance
{
    internal class CurrencyImplementation : ICurrency
    {
        public CurrencyImplementation(
            string alphabeticCode,
            string numericCode,
            byte minorUnits,
            string name
        ) : base(alphabeticCode, numericCode, minorUnits, name)
        { }

        public override int CompareTo(object other)
        {
            throw new System.NotImplementedException();
        }

        public override int CompareTo(ICurrency other)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(ICurrency other)
        {
            return this.AlphabeticCode == other.AlphabeticCode;
        }

        public override bool Equals(object other)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
