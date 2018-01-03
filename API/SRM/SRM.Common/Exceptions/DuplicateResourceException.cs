using System;

namespace Azynmag.Common.Exceptions
{
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException(string message) : base(message)
        {
        }
    }
}
