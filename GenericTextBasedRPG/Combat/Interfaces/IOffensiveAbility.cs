using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public interface IOffensiveAbility
    {
        public int MinDamage { get; }
        public int MaxDamage { get; }

        public DamageTypes DamageType { get; }

        //this would normally be a class, instead of an int - but that would take a bit too much time
        //I just want to quickly implement the concept in my architecture, so I'll go with an int 
        public int Modifier { get; }
    }
}
