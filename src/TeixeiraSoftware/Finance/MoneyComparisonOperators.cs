using System;

namespace TeixeiraSoftware.Finance
{
    public partial struct Money : IComparable, IComparable<Money>, IEquatable<Money>
    {
        /// <summary>Equality comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator == (Money left, Money right)
        {
            return left.Equals(right);
        }

        /// <summary>Inequality comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator != (Money left, Money right)
        {
            return !(left == right);
        }

        /// <summary>"Greater than" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator > (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount > right.Amount;
        }

        /// <summary>"Less than" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator < (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount < right.Amount;
        }

        /// <summary>"Greater than or equal to" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator >= (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount >= right.Amount;
        }

        /// <summary>"Less then or equal to" comparison operator</summary>
        /// <param name="left">A Money instance</param>
        /// <param name="right">A Money instance</param>
        /// <returns>True or false</returns>
        public static bool operator <= (Money left, Money right)
        {
            ThrowArgumentExceptionIfCurrenciesAreNotTheSame(left, right);
            return left.Amount <= right.Amount;
        }
    }
}