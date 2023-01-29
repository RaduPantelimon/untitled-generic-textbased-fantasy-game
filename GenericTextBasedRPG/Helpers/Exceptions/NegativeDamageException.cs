using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRPG.Properties;
using ExceptionResources = GenericRPG.Properties.Exceptions;

namespace GenericRPG
{
    public class NegativeDamageException: ArgumentOutOfRangeException
    {
        internal NegativeDamageException()
        {
        }

        internal NegativeDamageException(string message)
            : base(message)
        {
        }

        internal NegativeDamageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
