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

        internal override CommandResult Execute(Game game)
        {
            game.StartNextLevel();
            return CommandResult.Success(this, Messages.Command_SuccessResult_StartLevel);
        }
        public override bool IsValid(Game game)
            => (game.GameState.Status & GameplayStatus.ReadyForNextLevel) != 0;

        public override Command Clone() => new StartLevel();
    }
}
