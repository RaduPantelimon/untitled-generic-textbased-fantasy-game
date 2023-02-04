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

        internal override void Execute(Game engine)
        {
            HostileParty<Creature> hostileParty = engine.CurrentLevel!.CurrentEncounter!;

            //give user instruction
            engine.SendUserMessage(Messages.Menu_ChooseMobToAttack);

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

        public override bool IsValid(Game engine) => engine.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Attack();
    }
}
