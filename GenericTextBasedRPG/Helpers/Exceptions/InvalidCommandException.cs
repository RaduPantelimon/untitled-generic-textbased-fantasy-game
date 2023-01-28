using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionResources = RPGUtilities.Properties.Exceptions;

namespace RPGUtilities
{

    public class InvalidCommandException : InvalidOperationException
    {
        internal InvalidCommandException() : base(ExceptionResources.Exception_InvalidInputCommand)
        {
        }
        internal InvalidCommandException(string message) : base(message)
        {
        }
    }
}
