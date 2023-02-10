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

        internal override CommandResult Execute(Game game)
        {
            game.Quit();
            return CommandResult.Success(this, Messages.Command_SuccessResult_Quit);
        }
        public override bool IsValid(Game game) => game.GameState.Status!= GameplayStatus.Quit;

        public override Command Clone() => new QuitGame();

    }
}
