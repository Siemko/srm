using System;

namespace Azynmag.Common.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(string message) : base(message)
        {
        }
    }
}
