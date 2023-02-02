using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class StartLevel : Command
    {
        public override string Name {get;} = Messages.Command_StartLevel;

        public override void Execute(GameEngine engine) => engine.StartNextLevel();

        public override bool IsValid(GameEngine engine) => engine.CurrentLevel is not { IsOver: false };


        public override Command Clone() => new StartLevel();
    }
}
