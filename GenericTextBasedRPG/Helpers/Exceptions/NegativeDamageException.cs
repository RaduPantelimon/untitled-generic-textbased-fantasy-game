using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGUtilities.Properties;
using ExceptionResources = RPGUtilities.Properties.Exceptions;

namespace RPGUtilities
{
    public class NegativeDamageException: ArgumentOutOfRangeException
    {
        internal NegativeDamageException() : base(ExceptionResources.Exception_NegativeDamage)
        {
        }
        internal NegativeDamageException(string message): base(message)
        {
        }
    }
}
