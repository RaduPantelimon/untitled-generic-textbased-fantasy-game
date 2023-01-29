using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public class TutorialFactory: LevelFactory
    {
        static List<Command> AvailableCommands { get; } = new List<Command>();  
        
        internal TutorialFactory() : base(new EnemiesFactory())
        {
        }

        //create the tutorial level
        public override Level GetLevel(Game currentGame) => 
            new TutorialLevel(currentGame,
                              EnemiesFactory,
                              AvailableCommands);

        private static TutorialFactory? instance;
        public static TutorialFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TutorialFactory();
                }
                return instance;
            }
        }
    }
}
