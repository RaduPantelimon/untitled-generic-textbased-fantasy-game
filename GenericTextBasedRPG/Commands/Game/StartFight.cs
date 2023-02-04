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

        public override void Execute(Game engine)
         => engine.CurrentLevel!.CurrentEncounter = engine.CurrentLevel.EnemyEncounters.Pop();


        public override bool IsValid(Game engine) 
            => !engine.InCombat && engine is { CurrentLevel: { EnemyEncounters: { Count: > 0 } } };

        public override StartFight Clone() => new StartFight();
    }
}