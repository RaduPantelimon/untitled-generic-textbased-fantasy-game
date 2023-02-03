using GenericRPG.Combat;
using GenericRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRPG.Helpers.Interfaces;

namespace GenericRPG
{
    public interface IAttacker: IEntity
    {
        public AttackResult DoDamage(IAttackable target);
    }
}
