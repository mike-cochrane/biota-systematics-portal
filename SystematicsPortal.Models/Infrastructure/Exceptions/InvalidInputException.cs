using System;

namespace SystematicsPortal.Models.Infrastructure.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}
