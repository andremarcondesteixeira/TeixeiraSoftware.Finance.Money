using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>
    /// The <see cref="ICurrency" interface defines a boundary, so that
    /// <see cref="Money" /> has no external dependencies
    /// </summary>
    public interface ICurrency : IEquatable<ICurrency>
    {
        /// <summary>The symbol that uniquely identifies the currency</summary>
        string Symbol { get; }

        /// <summary>Tells whether another currency matches to this one</summary>
        /// <param name="other">The other currency</param>
        /// <returns>True if the currencies are the same, false otherwise</returns>
        new bool Equals(ICurrency other);
    }
}
