using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{
    public class TutorialFactory: LevelFactory
    {
        static List<Command> AvailableCommands { get; } = new List<Command>();  
        
        public Game GameInstance { get; private protected set; }

        internal TutorialFactory(Game game) : base(new EnemiesFactory())
        {
            GameInstance = game;
        }

        //create the tutorial level
        public override Level GetLevel() => 
            new TutorialLevel(GameInstance.InputStream, 
                              GameInstance.OutputStream,
                              AvailableCommands, 
                              GetEnemiesGroup(Combat.Enums.PartySize.Small));
    }
}
