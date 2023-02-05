using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Abilities
{
    //very basic spell
    public class Fireball:OffensiveSpell
    {
        public Fireball(int minDamage, int maxDamage, int manaCost) 
            : base(minDamage, maxDamage, manaCost,DamageTypes.Magic | DamageTypes.Fire)
        {

        }
    }
}
