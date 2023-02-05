using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Combat.Interfaces
{
    public interface ICastable
    {
        public int ManaCost { get; }
        public bool CanBeCastedBy(SpellCaster caster) => caster.Mana >= ManaCost;
    }
}
