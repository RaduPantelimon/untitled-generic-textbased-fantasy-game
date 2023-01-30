using GenericRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal abstract class Command : IShallowCloneable<Command>
    {

        public abstract string Name { get; }

        public Command()
        {

        }

        public abstract void Execute(Engine engine);

        //check if command is valid for a current stage of the game
        public abstract bool IsValid(Engine engine);

        public abstract Command Clone();

        public override string ToString() => Name;

    }
}
