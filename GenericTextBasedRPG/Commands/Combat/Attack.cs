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

        internal override CommandResult Execute(Game game)
        {
            HostileParty<Creature> hostileParty = game.GameState.CurrentLevel!.CurrentEncounter!;

            //give user instruction
            game.SendUserMessage(Messages.Menu_ChooseMobToAttack);

            //retrieve response and interpret characters
            
            bool parsingSuccessful = int.TryParse(game.GetUserInput(),out int mobIndex);

            if (!parsingSuccessful || mobIndex < 0 || mobIndex > hostileParty.Count)
                return CommandResult.Failure(Exceptions.Exception_InvalidEnemyIndex);
                
            AttackResult attResult = game.GameState.Player!.Hero!.DoDamage(hostileParty[mobIndex]);
            game.SendUserMessage(String.Empty);
            game.SendUserMessage(game.FormattingService.AttackMessage(attResult));

            return CommandResult.Success(Messages.Command_SuccessResult_Attack);
        }

        public override bool IsValid(Game game) => game.GameState.CurrentLevel?.CurrentEncounter?.Count > 0;


        public override Command Clone() => new Attack();
    }
}
