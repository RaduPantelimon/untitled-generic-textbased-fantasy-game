using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class QuitGame : Command
    {
        public override string Name { get; } = Mechanics.Command_QuitGame;

        public override void Execute(GameEngine engine) => engine.Quit();

        public override bool IsValid(GameEngine engine) => !engine.IsOver;


        public override Command Clone() => new QuitGame();

    }
}
