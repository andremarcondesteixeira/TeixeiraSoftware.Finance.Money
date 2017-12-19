using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>
    ///     Exception thrown when a math or a comparison operation is done with
    ///     Money instances involving different currencies
    /// </summary>
    public class CurrencyMismatchException : Exception
    {
        /// <summary>
        ///     The default message for a CurrencyMismatchException instance
        /// </summary>
        public const string DefaultMessage = "The currencies must be the same";

        /// <summary>
        ///     The left operand <see cref="Money" /> instance of the math or comparison
        ///     operation
        /// </summary>
        public Money LeftOperand { get; }

        /// <summary>
        ///     The right operand <see cref="Money" /> instance of the math or comparison
        ///     operation
        /// </summary>
        public Money RightOperand { get; }

        /// <summary>
        ///     Default constructor. This constructor will NOT save whe <see cref="Money" />
        ///     instances involved. The message will be the default message:
        ///     <see cref="DefaultMessage" />
        /// </summary>
        public CurrencyMismatchException() : this(DefaultMessage) {}

        /// <summary>
        ///     This constructor will save the <see cref="Money" /> instances involved.
        ///     The message will be the default message: <see cref="DefaultMessage" />
        /// </summary>
        /// <param name="leftOperand">
        ///     The <see cref="Money" /> instance on the left side of the math or comparison
        ///     operation
        /// </param>
        /// <param name="rightOperand">
        ///     The <see cref="Money" /> instance on the right side of the math or comparison
        ///     operation
        /// </param>
        public CurrencyMismatchException(Money leftOperand, Money rightOperand)
            : this()
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }

        /// <summary>
        ///     This constructor will NOT save the <see cref="Money" /> instances involved
        /// </summary>
        /// <param name="message">The custom exception message</param>
        public CurrencyMismatchException(string message)
            : base(message) { }

        /// <summary>
        ///     This constructor will NOT save the <see cref="Money" /> instances involved
        /// </summary>
        /// <param name="message">The custom exception message</param>
        /// <param name="inner">The inner <see cref="Exception" /> instance</param>
        public CurrencyMismatchException(string message, Exception inner)
            : base(message, inner) { }
    }
}