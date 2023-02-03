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

        public override void Execute(GameEngine engine)
         => engine.CurrentLevel!.CurrentEncounter = engine.CurrentLevel.EnemyEncounters.Pop();


        public override bool IsValid(GameEngine engine) 
            => engine is { 
                            CurrentLevel: { CurrentEncounter: { Count: 0 } or null } or 
                                          { EnemyEncounters: { Count: > 0 } } };


        public override StartFight Clone() => new StartFight();

    }
}


/*

                                                        || engine ;

            engine ?.CurrentLevel?.CurrentEncounter?.Count == 0 
                                                        && engine?.CurrentLevel?.EnemyEncounters.Count > 0 ; 
 
*/
