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

        public CommandResult(CommandStatus status, string description)
        {
            Status = status;
            Description = description;
        }

        public static CommandResult Success(string message) => new CommandResult(CommandStatus.Successful, message);

        public static CommandResult Failure(string message) => new CommandResult(CommandStatus.Failed, message);

    }
}
