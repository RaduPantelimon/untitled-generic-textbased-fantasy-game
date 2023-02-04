using GenericRPG.Commands;
using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public class TutorialLevel: Level
    {
        internal TutorialLevel(GameEngine currentGame, EnemiesFactory enemiesFactory)
            : base(currentGame,
                    new Stack<HostileParty<Creature>>( new HostileParty<Creature>[] 
                        {
                            enemiesFactory.GetEnemiesGroup(Combat.Enums.PartySize.Large),
                            enemiesFactory.GetEnemiesGroup(Combat.Enums.PartySize.Medium)
                        }))
        {
        }

        public override bool PlayerWon => EnemyEncounters.Count == 0 && Started;
        public override bool IsOver => PlayerQuit || !(CurrentGame.Player?.Hero?.IsAlive! ?? true) || PlayerWon;
    }
}
