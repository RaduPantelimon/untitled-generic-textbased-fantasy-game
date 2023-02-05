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

        internal Stack<HostileParty<Creature>> EnemyEncounters { get;}

        internal HostileParty<Creature>? CurrentEncounter { get; set; }

        private protected abstract bool WinCondition { get; }
        public bool PlayerWon => WinCondition;
        public bool PlayerLost => !(CurrentGame.Player?.IsAlive ?? true);
        public bool IsOver => PlayerWon || PlayerLost;

        internal Level(Game currentGame, Stack<HostileParty<Creature>> enemyEncounters) 
            => (CurrentGame,EnemyEncounters) = (currentGame, enemyEncounters);

    }
}
