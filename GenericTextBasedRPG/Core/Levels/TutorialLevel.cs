using RPGUtilities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{
    public class TutorialLevel: Engine
    {

        HostileParty<Creature> Enemies { get;}

        internal TutorialLevel(Stream input, Stream output, List<Command> commands, HostileParty<Creature> enemies) 
            : base(input, output, commands)
        {
            Enemies = enemies;
        }

        public override bool PlayerWon => Enemies.Count == 0 && Started;
        public override bool IsOver => Quit || !(Player?.Hero?.IsAlive! ?? true) || PlayerWon;
    }
}
