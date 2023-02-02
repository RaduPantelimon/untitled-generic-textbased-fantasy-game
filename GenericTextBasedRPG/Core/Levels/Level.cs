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

        public TutorialGame CurrentGame { get; }

        public Stack<HostileParty<Creature>> EnemyEncounters { get;}

        public HostileParty<Creature>? CurrentEncounter { get; internal set; }

        public virtual bool InCombat => CurrentEncounter?.Count > 0;

        public bool Started { get; private protected set; }
        public bool PlayerQuit { get; private protected set; }

        public abstract bool PlayerWon { get; }
        public virtual bool PlayerLost => !(CurrentGame.Player?.Hero?.IsAlive ?? true);
        public virtual bool IsOver => PlayerQuit || PlayerLost;

        internal Level(TutorialGame currentGame, Stack<HostileParty<Creature>> enemyEncounters) 
            => (CurrentGame,EnemyEncounters) = (currentGame, enemyEncounters);

    }
}
