using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{
    internal abstract class Command: IShallowCloneable<Command>
    {

        public Command()
        {

        }

        public abstract void Execute();

        //check if command is valid for a current stage of the game
        public abstract bool IsValid(Engine levelEngine);

        public abstract Command Clone();
    }
}
