using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class CommandResult
    {
        public CommandStatus Status { get; protected set; }
        public string Description { get; protected set; }
        public Command Command {get;}

        public CommandResult(Command command, CommandStatus status, string description)
        {
            Status = status;
            Description = description;
            Command = command;
        }

        public static CommandResult Success(Command command, string message) 
            => new CommandResult(command, CommandStatus.Successful, message);

        public static CommandResult Failure(Command command, string message) 
            => new CommandResult(command, CommandStatus.Failed, message);

    }
}
