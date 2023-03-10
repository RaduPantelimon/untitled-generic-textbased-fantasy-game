using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionResources = GenericRPG.Properties.Exceptions;

namespace GenericRPG
{

    public class InvalidCommandException : InvalidOperationException
    {
        internal InvalidCommandException()
        {
        }

        internal InvalidCommandException(string message)
            : base(message)
        {
        }

        internal InvalidCommandException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
