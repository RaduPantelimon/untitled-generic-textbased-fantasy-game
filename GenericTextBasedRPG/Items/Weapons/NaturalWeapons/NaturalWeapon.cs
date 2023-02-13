using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Items.Weapons
{
    public abstract class NaturalWeapon:Weapon
    {
        public NaturalWeapon(int minDamage, int maxDamage, DamageTypes damageType):base(minDamage, maxDamage, damageType)
        {
        }

        //give a direct way to change the modifier (natural weapons can suffer modifier changes depending on what happens to the creature)
        internal virtual void UpdateAttackModifier(int modifier)
        {
            Modifier = modifier;
        }

    }
}
