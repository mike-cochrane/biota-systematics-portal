using System;

namespace SystematicsData.Models.Infrastructure.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
