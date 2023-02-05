using GenericRPG.Combat.Interfaces;
using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    public abstract class Spell:ICastable
    {
        public int ManaCost { get; }

        public Spell(int manaCost)
        {
            ManaCost = manaCost;
        }

        public bool CanBeCastedBy(SpellCaster caster) => caster.Mana >= ManaCost;
    }
}
