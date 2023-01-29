using GenericRPG.Combat.Enums;
using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    //this is just a very simple base class for level
    //in the future, it should be made abstract
    //now it's just a simple, simple factory with some basic limitations
    public abstract class LevelFactory
    {

        private protected EnemiesFactory EnemiesFactory { get; }

        internal LevelFactory(EnemiesFactory enemiesFactory)
        {
            EnemiesFactory = enemiesFactory;
        }

        public abstract Level GetLevel(Game game);

        //very basic default implementation
        public virtual HostileParty<Creature> GetEnemiesGroup(PartySize size) => size switch
        {
            PartySize.Small => new HostileParty<Creature> { EnemiesFactory.GenerateMeleeEnemy(),
                                                            EnemiesFactory.GenerateRangedEnemy() },

            PartySize.Medium => new HostileParty<Creature> { EnemiesFactory.GenerateMeleeEnemy(),
                                                            EnemiesFactory.GenerateMeleeEnemy(),
                                                            EnemiesFactory.GenerateRangedEnemy() },

            PartySize.Large => new HostileParty<Creature> { EnemiesFactory.GenerateMeleeEnemy(),
                                                            EnemiesFactory.GenerateMeleeEnemy(),
                                                            EnemiesFactory.GenerateRangedEnemy(),
                                                            EnemiesFactory.GenerateRangedEnemy(),
                                                            EnemiesFactory.GenerateBoss()},

            _ => new HostileParty<Creature> { EnemiesFactory.GenerateMeleeEnemy() },
        };
    }
}
