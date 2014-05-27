﻿using System;

namespace MobileBookStore.DataContracts.Exceptions
{
    public abstract class KnownException : Exception
    {
        protected KnownException(string message) : base(message)
        {
        }

        protected KnownException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
