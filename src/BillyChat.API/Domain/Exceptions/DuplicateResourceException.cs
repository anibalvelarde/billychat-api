using System;

namespace BillyChat.API.Domain.Exceptions
{
    [System.Serializable]
    public class DuplicateResourceException : System.Exception
    {
        public DuplicateResourceException() { }
        public DuplicateResourceException(string message) : base(message) { }
        public DuplicateResourceException(string message, System.Exception inner) : base(message, inner) { }
        protected DuplicateResourceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}