using GenericRPG.Combat;
using GenericRPG.Creatures;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    //simple class we use to store the logic for formatting various objects
    //can be inherited in case we plan to support multiple formattings
    internal class FormattingService
    {
        private static FormattingService instance = new FormattingService();
        public static FormattingService Instance => instance;

        private FormattingService()
        {
        }

        public virtual string ListItemMessage<T>(T item, int index)
           => String.Format(Messages.Menu_ListDisplayTemplate, index, item);

        //generate a formatted list string starting from a collection of items and a formatter delegate
        public virtual string StatusList<T>(IEnumerable<T> items, Func<T,string> formatter)
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var item in items)
            {
                sb.Append(ListItemMessage(formatter(item), i));
                sb.Append(Messages.Command_Separator);
                i++;
            }
            return sb.ToString();
        }

        public virtual string AttackedByMessage(AttackResult attackResult)
           => String.Format("{0} was attacked by {1} for {2:0.##} {3} damage!",
               attackResult.Target,
               attackResult.Attack.Attacker,
               attackResult.Attack.Damage,
               attackResult.Attack.DamageType.ToString().ToLower());

        public virtual string AttackMessage(AttackResult attackResult)
            => String.Format("{0} attacked {1} for {2:0.##} {3} damage!",
                attackResult.Attack.Attacker,
                attackResult.Target,
                attackResult.Attack.Damage,
                attackResult.Attack.DamageType.ToString().ToLower());

        public virtual string MobStatusMessage(Creature creature)
            => String.Format(Messages.Menu_MobDisplayTemplate, creature.ToString(), creature.DisplayStats());

        public virtual string MobStatusList(IEnumerable<Creature> creatures)
            => StatusList(creatures, MobStatusMessage);
    }
}
