using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Equipment.Weapons
{
    public class Staff: Weapon
    {
        public Staff(int minDamage, int maxDamage)
            : base(minDamage, maxDamage, DamageTypes.Blunt)
        {

        }
    }
}
