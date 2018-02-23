using System;
using System.Collections.Generic;

namespace TeixeiraSoftware.Finance
{
    /// <summary>
    /// This abstract class works as an interface for a currency definition to the Money class, so
    /// the user can create it's own Currency classes or use any third paty libraries that may or may not
    /// implement this. In case the thirdy partie library does not implement this abstract class, you can
    /// create a proxy class to do so.
    /// </summary>
    public abstract class ICurrency : IEquatable<ICurrency>, IComparable, IComparable<ICurrency>
    {
        /// <summary>The ISO name of the currency</summary>
        public string Name { get; }

        /// <summary>The 3 letters ISO code of the currency</summary>
        public string AlphabeticCode { get; }

        /// <summary>The numeric ISO code of the currency</summary>
        public string NumericCode { get; }

        /// <summary>The ISO minor units of the currency</summary>
        public byte MinorUnits { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alphabeticCode"></param>
        /// <param name="numericCode"></param>
        /// <param name="minorUnits"></param>
        /// <param name="name"></param>
        protected ICurrency(string alphabeticCode, string numericCode, byte minorUnits, string name)
        {
            this.AlphabeticCode = alphabeticCode;
            this.NumericCode = numericCode;
            this.MinorUnits = minorUnits;
            this.Name = name;
        }

        /// <summary>
        /// Says wheter another currency matches to this one
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if the currencies are equal, false otherwise</returns>
        public abstract bool Equals(ICurrency other);

        /// <summary>
        /// Says wheter another currency matches to this one
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if the currencies are equal, false otherwise</returns>
        public override abstract bool Equals(Object other);

        /// <summary>
        /// Compares two currencies for sorting purposes
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        ///     -1 if this current currency comes before the other currency.
        ///     0 if this current currency is equal to the other currency.
        ///     1 if this current currency comes after the other currency.
        /// </returns>
        public abstract int CompareTo(object other);

        /// <summary>
        /// Compares two currencies for sorting purposes
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        ///     -1 if this current currency comes before the other currency.
        ///     0 if this current currency is equal to the other currency.
        ///     1 if this current currency comes after the other currency.
        /// </returns>
        public abstract int CompareTo(ICurrency other);

        /// <summary>
        /// Generates a hash code for this instance
        /// </summary>
        /// <returns>The generated hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -1854965745;

            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AlphabeticCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumericCode);
            hashCode = hashCode * -1521134295 + MinorUnits.GetHashCode();

            return hashCode;
        }
    }
}
