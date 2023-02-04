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

        public override void Execute(Game engine)
        {
            //move encounter back in the queue
            engine.CurrentLevel?.EnemyEncounters.Push(engine.CurrentLevel.CurrentEncounter!);
            engine.CurrentLevel!.CurrentEncounter = null;

            engine.SendUserMessage(Messages.Event_Flee);
        }

        public override bool IsValid(Game engine) => engine.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Flee();
    }
}
