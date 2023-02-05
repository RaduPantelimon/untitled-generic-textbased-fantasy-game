using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Abilities
{
    //Implement Add Spell Method, etc.
    internal class SpellBook : IEnumerable<Spell>
    {
        //other spells - Further breakdown into other types of spells required
        List<Spell> Spells { get; }
        //offensive spells
        List<OffensiveSpell> OffensiveSpells { get; }

        public SpellBook(IEnumerable<Spell> startingSpells)
        {
            Spells = new List<Spell>();
            OffensiveSpells = new List<OffensiveSpell>();
            //SPLIT SPELLS INTO CATEGORIES
            foreach (var spell in startingSpells)
                switch (spell)
                {
                    case OffensiveSpell x:
                        OffensiveSpells.Add(x);
                        break;
                    default:
                        Spells.Add(spell);
                        break;
                }
        }

        public IEnumerable<OffensiveSpell> GetOffensiveSpells() => OffensiveSpells.AsEnumerable();

        //lets consider that our spellbook can work as an enumeration of spells
        public IEnumerator<Spell> GetEnumerator() => Spells.Concat(OffensiveSpells).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
