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
    public class TutorialLevel : Level
    {
        internal TutorialLevel(Game currentGame, EnemiesFactory enemiesFactory)
            : base(currentGame,
                    new Stack<HostileParty<Creature>>(new HostileParty<Creature>[]
                        {
                            enemiesFactory.GetEnemiesGroup(PartySize.Single)
                            //enemiesFactory.GetEnemiesGroup(PartySize.Large),
                            //enemiesFactory.GetEnemiesGroup(PartySize.Medium)
                        }))
        {
        }
        public override bool PlayerWon => CurrentEncounter is not { Count: > 0 } &&
                                        EnemyEncounters.Count == 0 && 
                                        CurrentGame is { Player: { IsAlive: true } };

        public override bool IsOver => CurrentGame is { Player:{IsAlive: false }} || PlayerWon;
    }
}
