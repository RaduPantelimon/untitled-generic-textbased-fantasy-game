using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment.Weapons
{
    public class Staff: Weapon
    {
        internal Staff(int minDamage, int maxDamage)
            : base(minDamage, maxDamage, DamageTypes.Blunt)
        {

        }
    }
}
