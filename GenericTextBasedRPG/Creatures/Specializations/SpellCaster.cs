using GenericRPG.Abilities.Spells;
using GenericRPG.Combat;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    public class SpellCaster: Humanoid
    {
        public double Mana { get; private protected set; }
        public double MaxMana { get; private protected set; }

        public override double UnnarmedDamage => Convert.ToDouble(Mechanics.SpellCaster_DefaultUnnarmedDamage);

        public SpellCaster(double hitpoints, double mana) : base(hitpoints)
        {
            if (mana < 0) throw new ArgumentOutOfRangeException(nameof(mana));
            MaxMana = Mana = mana;
        }

        public SpellCaster(double hitpoints) : base(hitpoints)
        {
            MaxMana = Mana = Convert.ToDouble(Mechanics.SpellCaster_DefaultMana);
        }


        //this could be converted to a template method depending on how we want to implement spells
        //or other resources necessary for casting them
        public virtual void CastSpell(Spell spell)
        {
            //take damage
            if (spell.ManaCost > Mana)
                throw new InvalidOperationException(Exceptions.Exception_ManaCostExceedsManaPool);

            Mana-=spell.ManaCost;

        }

        public override string DisplayStats() => base.DisplayStats() +"; MP: " + Mana.ToString(Messages.Formatting_StatsNumberFormatting);
    }
}
