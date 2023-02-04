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

        public abstract Level GetLevel(GameEngine game);

       
    }
}
