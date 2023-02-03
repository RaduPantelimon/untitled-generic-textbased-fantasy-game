using GenericRPG.Core;
using GenericRPG.Creatures;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Commands
{
    internal class Attack:Command
    {
        public override string Name { get; } = Messages.Command_Attack;

        public override void Execute(GameEngine engine)
        {
            HostileParty<Creature> hostileParty = engine.CurrentLevel!.CurrentEncounter!;
            //give user instruction
            engine.SendUserMessage(Messages.Menu_ChooseMobToAttack);
            engine.SendUserMessage(engine.FormattingService.MobStatusList(hostileParty)); 

            //retrieve response and interpret characters
            try
            {
                int mobIndex = int.Parse(engine.GetUserInput()) - 1;

                if (mobIndex < 0 && mobIndex < hostileParty.Count)
                    throw new InvalidOperationException(Exceptions.Exception_InvalidEnemyIndex);
                
                engine.Player!.Hero!.DoDamage(hostileParty[mobIndex]);
            }
            catch (Exception ex)
            {
                throw new InvalidCommandException(Exceptions.Exception_InvalidInputCommand, ex);
            }
        }

        public override bool IsValid(GameEngine engine) => engine.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Attack();
    }
}
