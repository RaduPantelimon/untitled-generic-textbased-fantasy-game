using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities
{
    [Flags]
    public enum PhysicalDamageTypes
    {
        Piercing = 1,
        Slashing = 2,
        Bludgeoning = 4,
    }
}
