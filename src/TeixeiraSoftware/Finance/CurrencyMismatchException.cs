using System;

namespace TeixeiraSoftware.Finance
{
    /// <summary>
    ///     Exception thrown when a math or comparison operation is done with
    ///     <see cref="Money" /> instances involving different currencies
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
        public Money? LeftOperand { get; }

        /// <summary>
        ///     The right operand <see cref="Money" /> instance of the math or comparison
        ///     operation
        /// </summary>
        public Money? RightOperand { get; }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: The default message: <see cref="DefaultMessage" />.</para>
        ///     <para>LeftOperand: Will be null.</para>
        ///     <para>RightOperand: Will be null.</para>
        ///     <para>InnerException: Will be null.</para>
        /// </summary>
        public CurrencyMismatchException()
            : this(DefaultMessage, null, null, null) { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: According to the given parameter value.</para>
        ///     <para>LeftOperand: Will be null.</para>
        ///     <para>RightOperand: Will be null.</para>
        ///     <para>InnerException: Will be null.</para>
        /// </summary>
        /// <param name="message">The exception message</param>
        public CurrencyMismatchException(string message)
            : this(message, null, null, null) { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: The default message: <see cref="DefaultMessage" />.</para>
        ///     <para>LeftOperand: According to the given parameter value.</para>
        ///     <para>RightOperand: According to the given parameter value.</para>
        ///     <para>InnerException: Will be null.</para>
        /// </summary>
        /// <param name="leftOperand">The left operand of the operation</param>
        /// <param name="rightOperand">The right operand of the operation</param>
        public CurrencyMismatchException(Money leftOperand, Money rightOperand)
            : this(DefaultMessage, leftOperand, rightOperand, null)
        { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: The default message: <see cref="DefaultMessage" />.</para>
        ///     <para>LeftOperand: Will be null.</para>
        ///     <para>RightOperand: Will be null.</para>
        ///     <para>InnerException: According to the given parameter value.</para>
        /// </summary>
        /// <param name="inner">The inner exception</param>
        public CurrencyMismatchException(Exception inner)
            : this(DefaultMessage, null, null, inner) { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: According to the given parameter value.</para>
        ///     <para>LeftOperand: According to the given parameter value.</para>
        ///     <para>RightOperand: According to the given parameter value.</para>
        ///     <para>InnerException: Will be null.</para>
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="leftOperand">The left operand of the operation</param>
        /// <param name="rightOperand">The right operand of the operation</param>
        public CurrencyMismatchException(
            string message,
            Money leftOperand,
            Money rightOperand
        ) : this(message, leftOperand, rightOperand, null) { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: According to the given parameter value.</para>
        ///     <para>LeftOperand: Will be null.</para>
        ///     <para>RightOperand: Will be null.</para>
        ///     <para>InnerException: According to the given parameter value.</para>
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public CurrencyMismatchException(string message, Exception inner)
            : this(message, null, null, inner) { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: The default message: <see cref="DefaultMessage" />.</para>
        ///     <para>LeftOperand: According to the given parameter value.</para>
        ///     <para>RightOperand: According to the given parameter value.</para>
        ///     <para>InnerException: According to the given parameter value.</para>
        /// </summary>
        /// <param name="leftOperand">The left operand of the operation</param>
        /// <param name="rightOperand">The right operand of the operation</param>
        /// <param name="inner">The inner exception</param>
        public CurrencyMismatchException(
            Money leftOperand,
            Money rightOperand,
            Exception inner
        ) : this(DefaultMessage, leftOperand, rightOperand, inner) { }

        /// <summary>
        ///     This constructor will set the Exception's attributes in the following manner:
        ///     <para>Message: According to the given parameter value.</para>
        ///     <para>LeftOperand: According to the given parameter value.</para>
        ///     <para>RightOperand: According to the given parameter value.</para>
        ///     <para>InnerException: According to the given parameter value.</para>
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="leftOperand">The left operand of the operation</param>
        /// <param name="rightOperand">The right operand of the operation</param>
        /// <param name="inner">The inner exception</param>
        public CurrencyMismatchException(
            string message,
            Money? leftOperand,
            Money? rightOperand,
            Exception inner
        ) : base(message, inner)
        {
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
        }
    }
}