using GenericRPG.Combat;
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

        internal override void Execute(Game game)
        {
            HostileParty<Creature> hostileParty = game.GameState.CurrentLevel!.CurrentEncounter!;

            //give user instruction
            game.SendUserMessage(Messages.Menu_ChooseMobToAttack);

            //retrieve response and interpret characters
            try
            {
                int mobIndex = int.Parse(game.GetUserInput()) - 1;

                if (mobIndex < 0 && mobIndex < hostileParty.Count)
                    throw new InvalidOperationException(Exceptions.Exception_InvalidEnemyIndex);
                
                AttackResult attResult = game.GameState.Player!.Hero!.DoDamage(hostileParty[mobIndex]);
                game.SendUserMessage(String.Empty);
                game.SendUserMessage(game.FormattingService.AttackMessage(attResult));
            }
            catch (Exception ex)
            {
                throw new InvalidCommandException(Exceptions.Exception_InvalidInputCommand, ex);
            }
        }

        public override bool IsValid(Game game) => game.GameState.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Attack();
    }
}
