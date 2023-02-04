using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRPG.Properties;

namespace GenericRPG.Creatures
{
    public class Fighter : Humanoid
    {
        public uint Strength { get; internal set; }

        public override double UnnarmedDamage => Strength;

        public Fighter(double hitpoints, uint strength): base(hitpoints) => Strength = strength;

        public Fighter(double hitpoints) : base(hitpoints)
        {
            Strength = Convert.ToUInt32(Mechanics.Fighter_DefaultStrength);
        }
    }
}
