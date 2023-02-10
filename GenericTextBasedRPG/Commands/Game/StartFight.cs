using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class StartFight : Command
    {
        public override string Name { get; } = Messages.Command_StartFight;

        internal override CommandResult Execute(Game game)
        {
            Level currentLevel = game.GameState.CurrentLevel!;
            currentLevel.CurrentEncounter = currentLevel.EnemyEncounters.Pop();

            return CommandResult.Success(this, Messages.Command_SuccessResult_StartFight);
        }

        public override bool IsValid(Game game) 
            => !game.GameState.Status.HasFlag(GameplayStatus.InCombat) 
            && game.GameState is { CurrentLevel: { EnemyEncounters: { Count: > 0 } } };

        public override StartFight Clone() => new StartFight();
    }
}