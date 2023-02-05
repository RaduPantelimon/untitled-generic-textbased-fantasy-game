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
        Normal = 0,
        Piercing = 1,
        Slashing = 2,
        Blunt = 4,
        Magic = 8,
        Frost = 16,
        Fire = 32
    }
}
