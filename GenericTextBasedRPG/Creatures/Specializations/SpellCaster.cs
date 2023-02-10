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

        private protected SpellBook SpellBook { get; }

        public SpellCaster(double hitpoints, double mana, IEnumerable<Spell> spells) : base(hitpoints)
        {
            SpellBook = new SpellBook(spells);
            if (mana < 0) throw new ArgumentOutOfRangeException(nameof(mana));
            MaxMana = Mana = mana;
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

        //choose a spell to attack with, instead of using a basic attack
        private protected OffensiveSpell? ChooseOffensiveSpell() 
            => SpellBook.OfType<OffensiveSpell>().Where(x => x.CanBeCastedBy(this)).FirstOrDefault();

        //basic inflict damage - either cast spell or do base humanoid attack if not possible
        //basic implementation, only good for very basic NPCs
        public override Attack GenerateAttack(IAttackable target)
        {
            //choose a valid spell and cast it
            OffensiveSpell? spell = ChooseOffensiveSpell();
            if (spell != null) return spell.Cast(this, target);

            //if no spells are available, just do a basic attack
            return base.GenerateAttack(target);
        }
               
        public override string DisplayStats() => base.DisplayStats() +"; MP: " + Mana.ToString(Messages.Formatting_StatsNumberFormatting);
    }
}
