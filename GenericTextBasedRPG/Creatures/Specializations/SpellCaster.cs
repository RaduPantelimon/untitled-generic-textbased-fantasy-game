using RPGUtilities.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Creatures.Specializations
{
    internal class SpellCaster: Humanoid
    {
        public double Mana { get; internal set; }
        public double MaxMana { get; internal set; }

        public override double UnnarmedDamage => Convert.ToDouble(Mechanics.SpellCaster_UnnarmedDamage);

        internal SpellCaster(string name, double hitpoints, double mana) : base(name, hitpoints)
        {
            if (mana < 0) throw new ArgumentOutOfRangeException(nameof(mana));
            MaxMana = Mana = mana;
        }

        internal SpellCaster(string name, double hitpoints) : base(name, hitpoints)
        {
            MaxMana = Mana = Convert.ToDouble(Mechanics.SpellCaster_DefaultMana);
        }

    }
}
