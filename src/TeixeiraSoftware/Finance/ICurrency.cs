using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>
    /// This interface defines a boundary, so that <see cref="Money" /> has no external dependencies
    /// </summary>
    public interface ICurrency : IEquatable<ICurrency>
    {
        /// <summary>The ISO name of the currency</summary>
        string Name { get; }

        /// <summary>The alphabetic ISO code of the currency</summary>
        string AlphabeticCode { get; }

        /// <summary>The numeric ISO code of the currency</summary>
        string NumericCode { get; }

        /// <summary>The ISO minor units of the currency</summary>
        byte MinorUnits { get; }

        /// <summary>
        /// Says wheter another currency matches to this one
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if the currencies are equal, false otherwise</returns>
        new bool Equals(ICurrency other);
    }
}
