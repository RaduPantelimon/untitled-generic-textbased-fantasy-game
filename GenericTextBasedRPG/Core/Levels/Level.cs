using GenericRPG.Commands;
using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{

    //TO DO: finish this class, add properties for map, quests, etc.
    public abstract class Level
    {
        internal Stack<HostileParty<Creature>> EnemyEncounters { get;}
        internal HostileParty<Creature>? CurrentEncounter { get; set; }

        public abstract bool LevelFinished { get; }

        internal Level(Stack<HostileParty<Creature>> enemyEncounters) => EnemyEncounters = enemyEncounters;

    }
}
