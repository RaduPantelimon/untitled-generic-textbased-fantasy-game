using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Abilities
{
    internal class SpellBook
    {
        List<Spell> Spells { get; }

        public SpellBook(IEnumerable<Spell> startingSpells)
        {
            Spells = new List<Spell>(startingSpells); 
        }
    }
}
