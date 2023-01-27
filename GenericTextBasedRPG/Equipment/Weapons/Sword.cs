using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment.Weapons
{
    public class Sword:Weapon
    {
        //stuff like edge type, blade length, etc. should be here 

        internal Sword(int minDamage, int maxDamage)
            : base(minDamage, maxDamage, DamageTypes.Slashing | DamageTypes.Piercing)
        {

        }
    }
}
