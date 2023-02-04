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

        public Game CurrentGame { get; }

        public Stack<HostileParty<Creature>> EnemyEncounters { get;}

        public HostileParty<Creature>? CurrentEncounter { get; internal set; }

        public abstract bool PlayerWon { get; }
        public virtual bool PlayerLost => !(CurrentGame.Player?.IsAlive ?? true);
        public virtual bool IsOver => PlayerWon || PlayerLost;

        internal Level(Game currentGame, Stack<HostileParty<Creature>> enemyEncounters) 
            => (CurrentGame,EnemyEncounters) = (currentGame, enemyEncounters);

    }
}
