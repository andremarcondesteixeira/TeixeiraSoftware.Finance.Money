using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>A money representation</summary>
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>The amount of money in the given currency</summary>
        public readonly decimal Amount;

        /// <summary>A <see cref="ICurrency" /> instance</summary>
        public readonly ICurrency Currency;

        /// <summary>
        ///     Set this to true if you want the operators == and != to not allow
        ///     comparisons between instances with different currencies. Defaults
        ///     to false. When it is set to true, any comparisons against different
        ///     currencies will return false. When set to false, any try to compare
        ///     instances with different currencies will throw a CurrencyMismatchException
        /// </summary>
        public static bool StrictEqualityComparisons { get; set; } = false;

        /// <summary>
        ///     Error message for when a <see cref="Money" /> instace is compared against
        ///     an object of another type
        /// </summary>
        public static string TypeMismatchErrorMessage =
            "A Money instance can only be compared against another Money instance";

        /// <summary><see cref="Money" /> constructor</summary>
        /// <param name="amount">The amount of money in the given currency</param>
        /// <param name="currency">A <see cref="ICurrency" /> instance</param>
        public Money(decimal amount, ICurrency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}