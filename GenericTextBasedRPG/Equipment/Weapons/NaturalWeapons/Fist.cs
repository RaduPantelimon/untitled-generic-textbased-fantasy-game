using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Equipment.Weapons
{
    public class Fist:Weapon
    {
        public Fist() : this(DefaultFistDamage) { }

        public Fist(int damange): base(damange, damange, DamageTypes.Blunt)
        {

        }

        protected static int DefaultFistDamage { get; } = int.Parse(Mechanics.Default_Humanoid_FistDamage);
    }
}
