using System;

namespace LABank.Exceptions
{
    /// <summary>
    /// Exception class that represents errors raised in Customer class
    /// </summary>
    public class CustomerException: ApplicationException
    {
        /// <summary>
        /// Constructor that initializes exception message
        /// </summary>
        /// <param name="message">Exception message</param>
        public CustomerException(string message): base(message)
        {

        }

        /// <summary>
        /// Constructor that initializes excpetion message and inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public CustomerException(string message, Exception innerException): base(message, innerException)
        {

        }
    }
}
