using GenericRPG.Combat;
using GenericRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public interface IAttacker: IEntity
    {
        public AttackResult DoDamage(IAttackable target);
    }
}
