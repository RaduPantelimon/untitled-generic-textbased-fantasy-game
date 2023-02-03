using GenericRPG.Commands;
using System;
using System.Collections.Generic;
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
        public override Level GetLevel(TutorialGame currentGame) =>  new TutorialLevel(currentGame, EnemiesFactory);

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
