using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Items.Weapons
{
    public class Fist:NaturalWeapon
    {
        public Fist() : this(DefaultFistDamage, 0) { }

        public Fist(int damage, int modifier) : base(damage, damage, DamageTypes.Blunt)
        {

        }

        protected static int DefaultFistDamage { get; } = int.Parse(Mechanics.Default_Humanoid_FistDamage);
    }
}
