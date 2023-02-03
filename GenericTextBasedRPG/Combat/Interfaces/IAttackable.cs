using GenericRPG.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public interface IAttackable
    {
        public bool IsAlive { get; }

        public AttackResult TakeDamage(Attack attack);
    }
}
