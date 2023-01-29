using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    [Flags]
    public enum DamageTypes
    {
        Piercing = 1,
        Slashing = 2,
        Blunt = 4,
    }
}
