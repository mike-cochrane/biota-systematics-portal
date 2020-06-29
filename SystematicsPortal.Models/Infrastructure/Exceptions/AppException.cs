﻿using System;

namespace SystematicsPortal.Models.Infrastructure.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
