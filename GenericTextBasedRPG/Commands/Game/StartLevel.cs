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

        internal override void Execute(Game game) => game.StartNextLevel();

        public override bool IsValid(Game game)
            => ((game.GameState.Status & (PlayerStatus.GameOver | PlayerStatus.LevelInProgress)) == 0);
        //&& game.GameState.CurrentLevel == null

        public override Command Clone() => new StartLevel();
    }
}
