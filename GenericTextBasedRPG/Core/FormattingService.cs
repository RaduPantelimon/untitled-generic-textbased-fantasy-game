using GenericRPG.Combat;
using GenericRPG.Creatures;
using GenericRPG.Helpers.Interfaces;
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
        public virtual string StatusList<T>(IEnumerable<T> items, Func<T,string> formatter, int startIndex = 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.Append(ListItemMessage(formatter(item), startIndex));
                sb.Append(Messages.Command_Separator);
                startIndex++;
            }
            return sb.ToString();
        }

        public virtual string AttackedByMessage(AttackResult attackResult)
           => String.Format(Messages.Menu_AttackedByTemplate,
               attackResult.Target.Name,
               attackResult.Attack.Attacker.Name,
               attackResult.Attack.Damage,
               attackResult.Attack.DamageType.ToString().ToLower());

        public virtual string AttackMessage(AttackResult attackResult)
            => String.Format(Messages.Menu_AttackedTemplate,
                attackResult.Attack.Attacker.Name,
                attackResult.Target.Name,
                attackResult.Attack.Damage,
                attackResult.Attack.DamageType.ToString().ToLower());

        public virtual string EntityStatusMessage(IEntity entity)
            => String.Format(Messages.Menu_MobDisplayTemplate, entity.Name, entity.DisplayStats());

        public virtual string EntitiesList(IEnumerable<IEntity> entities, int startIndex = 0)
            => StatusList(entities, EntityStatusMessage, startIndex);

        public virtual string NameableItemsList(IEnumerable<INameable> entities, int startIndex = 0)
            => StatusList(entities, x => x.Name!, startIndex);
    }
}
