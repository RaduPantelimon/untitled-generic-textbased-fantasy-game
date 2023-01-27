using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGUtilities.Properties;

namespace RPGUtilities.Creatures
{
    public class Fighter : Humanoid
    {
        public uint Strength { get; internal set; }

        public override double UnnarmedDamage => Strength;

        internal Fighter(string name, double hitpoints, uint strength): base(name, hitpoints) => Strength = strength;

        internal Fighter(string name, double hitpoints) : base(name, hitpoints)
        {
            Strength = Convert.ToUInt32(Mechanics.Fighter_DefaultStrength);
        }
    }
}
