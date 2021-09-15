using System;
using System.Runtime.Serialization;

namespace ErrorsAndFailures
{
    [Serializable]
    public class ChargeFailedException : Exception
    {
        public ChargeFailedException()
        {
        }

        public ChargeFailedException(string message)
            : base(message)
        {
        }

        public ChargeFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ChargeFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
