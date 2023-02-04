using GenericRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal abstract class Command : IShallowCloneable<Command>, INameable
    {

        public abstract string Name { get; }

        internal Command()
        {

        }

        internal abstract void Execute(Game engine);

        //check if command is valid for a current stage of the game
        public abstract bool IsValid(Game engine);

        public abstract Command Clone();

        public override string ToString() => Name;

    }
}
