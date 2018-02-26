using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>
    /// This interface defines a boundary, so that <see cref="Money" /> has no external dependencies
    /// </summary>
    public interface ICurrency : IEquatable<ICurrency>
    {
        /// <summary>The symbol that uniquely identifies the currency</summary>
        string Symbol { get; }

        /// <summary>
        /// Says wheter another currency matches to this one
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if the currencies are equal, false otherwise</returns>
        new bool Equals(ICurrency other);
    }
}
