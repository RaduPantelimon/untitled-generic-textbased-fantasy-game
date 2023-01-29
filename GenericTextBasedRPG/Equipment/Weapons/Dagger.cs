using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Equipment.Weapons
{
    internal class Dagger : Weapon
    {
        internal Dagger(int minDamage, int maxDamage)
            : base(minDamage, maxDamage, DamageTypes.Piercing)
        {
        }
    }
}
