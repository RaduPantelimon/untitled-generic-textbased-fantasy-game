using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core.Commands
{
    //LIST OF Command PROTOTYPES - this will give the total collection of commands accessible in a level
    internal class CommandRepository
    {
        //once created, we do not want the list of commands to change
        protected IReadOnlyCollection<Command> Commands { get; }

        internal CommandRepository(List<Command> commands)
        {
            Commands = commands;
        }

        public IEnumerable<Command> GetEligibleCommands(Engine level) => Commands.Where(x => x.IsValid(level));

    }
}
