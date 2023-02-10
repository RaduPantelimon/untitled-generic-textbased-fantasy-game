using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    //Implement Add Spell Method, etc.
    internal class SpellBook : IEnumerable<Spell>
    {
        //other spells - Further breakdown into other types of spells required
        List<Spell> Spells { get; }

        //This is sort of like a currency that will be used to learn new spells
        public int TalentPoints { get; internal set; }

        public SpellBook(IEnumerable<Spell> startingSpells)
        {
            Spells = new List<Spell>(startingSpells);
        }

        public void LearnNewSpell(Spell spell) => throw new NotImplementedException();

        //lets consider that our spellbook can work as an enumeration of spells
        public IEnumerator<Spell> GetEnumerator() => Spells.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
