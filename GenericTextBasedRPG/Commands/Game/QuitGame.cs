﻿using GenericRPG.Core;
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

        internal override void Execute(Game game) => game.Quit();

        public override bool IsValid(Game game) => (game.GameState.Status & PlayerStatus.Quit) == 0;

        public override Command Clone() => new QuitGame();

    }
}
