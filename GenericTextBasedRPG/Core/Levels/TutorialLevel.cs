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
            : base(new Stack<HostileParty<Creature>>(new HostileParty<Creature>[]
                        {
                            //enemiesFactory.GetEnemiesGroup(PartySize.Single)
                            enemiesFactory.GetEnemiesGroup(PartySize.Large),
                            enemiesFactory.GetEnemiesGroup(PartySize.Medium)
                        }))
        {
        }

        public override bool LevelFinished => CurrentEncounter is not { Count: > 0 } && EnemyEncounters.Count == 0;

    }
}
