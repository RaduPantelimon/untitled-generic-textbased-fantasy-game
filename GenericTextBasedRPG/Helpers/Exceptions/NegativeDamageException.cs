using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGUtilities.Properties;
using ExceptionResources = RPGUtilities.Properties.Exceptions;

namespace RPGUtilities
{
    internal class NegativeDamageException: ArgumentOutOfRangeException
    {
        public NegativeDamageException() : base(ExceptionResources.Exception_NegativeDamage)
        {
        }
        public NegativeDamageException(string message): base(message)
        {
        }
    }
}
