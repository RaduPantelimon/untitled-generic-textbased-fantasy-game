using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Items.Weapons
{
    public class Sword:Weapon
    {
        //stuff like edge type, blade length, etc. should be here 

        public Sword(int minDamage, int maxDamage)
            : base(minDamage, maxDamage, DamageTypes.Slashing | DamageTypes.Piercing)
        {

        }
    }
}
