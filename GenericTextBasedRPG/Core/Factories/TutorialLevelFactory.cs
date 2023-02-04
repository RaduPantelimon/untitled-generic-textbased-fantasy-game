using GenericRPG.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public class TutorialLevelFactory: LevelFactory
    {        
        internal TutorialLevelFactory() : base(new EnemiesFactory())
        {
        }

        //create the tutorial level
        public override Level GetLevel(Game currentGame) =>  new TutorialLevel(currentGame, EnemiesFactory);
        //not available as part of the tutorial
        public override Level GetLevel(Game game, MappingType mapSize) 
            => throw new NotImplementedException();
        public override Level GetLevel(Game game, MappingType mapSize, Difficulty difficulty) 
            => throw new NotImplementedException();

        private static TutorialLevelFactory? instance;
        public static TutorialLevelFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TutorialLevelFactory();
                }
                return instance;
            }
        }
    }
}
