using GenericRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    //LIST OF Command PROTOTYPES - this will give the total collection of commands accessible in a level
    internal class CommandRepository
    {

        public static List<Command> AvailableCommands { get; } = new List<Command>()
        {
            new StartLevel(),
            new QuitGame()
        };

        //once created, we do not want the list of commands to change
        protected IReadOnlyCollection<Command> Commands { get; }

        internal CommandRepository(List<Command> commands)
        {
            Commands = commands;
        }

        public IEnumerable<Command> GetEligibleCommands(GameEngine level) => Commands.Where(x => x.IsValid(level));

    }
}
