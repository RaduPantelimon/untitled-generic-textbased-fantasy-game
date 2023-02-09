using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class Flee:Command
    {
        public override string Name { get; } = Messages.Command_Flee;

        internal override CommandResult Execute(Game game)
        {
            //move encounter back in the queue
            Level currentLevel = game.GameState.CurrentLevel!;
            currentLevel!.EnemyEncounters.Push(currentLevel.CurrentEncounter!);
            currentLevel!.CurrentEncounter = null;

            game.SendUserMessage(Messages.Event_Flee);

            return CommandResult.Success(this, Messages.Command_SuccessResult_Flee);
        }

        public override bool IsValid(Game game) => game.GameState.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Flee();
    }
}
