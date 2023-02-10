using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRPG.Items.Weapons;
using GenericRPG.Properties;

namespace GenericRPG.Creatures
{
    public class Fighter : Humanoid
    {
        uint _strength;
        public uint Strength 
        { get => _strength; 
          internal set
            {
                //I don't want to create new fist whenever I do an attack,
                //let's assume we want to optimize this and we only want to recreate the fist whenever the strength changes
                _strength = value;
                NaturalWeapon = new Fist((int)_strength);
            }
        }

        public Fighter(double hitpoints, uint strength) : base(hitpoints)
        {
            Strength = strength;
        }
        public Fighter(double hitpoints) : this(hitpoints, Convert.ToUInt32(Mechanics.Fighter_DefaultStrength))
        { }
    }
}
