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

        internal override void Execute(Game game)
         => game.GameState.CurrentLevel!.CurrentEncounter = game.GameState.CurrentLevel.EnemyEncounters.Pop();


        public override bool IsValid(Game game) 
            => (game.GameState.Status & PlayerStatus.InCombat) == 0 
            && game.GameState is { CurrentLevel: { EnemyEncounters: { Count: > 0 } } };

        public override StartFight Clone() => new StartFight();
    }
}