using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core.Commands
{
    internal class StartGame : Command
    {
        public override string Name {get;} = Mechanics.Command_StartGame;

        public override void Execute(Engine engine) => engine.Start();

        public override bool IsValid(Engine engine) => !engine.Started;


        public override Command Clone()
        {
            throw new NotImplementedException();
        }
    }
}
