using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class Flee:Command
    {
        public override string Name { get; } = Messages.Command_Flee;

        public override void Execute(GameEngine engine)
        {
            //move encounter back in the queue
            engine.CurrentLevel?.EnemyEncounters.Push(engine.CurrentLevel.CurrentEncounter!);
            engine.CurrentLevel!.CurrentEncounter = null;
        }

        public override bool IsValid(GameEngine engine) => engine.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Attack();
    }
}
