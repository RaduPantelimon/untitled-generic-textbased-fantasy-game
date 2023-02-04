using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Combat
{
    public class AttackResult
    {
        public bool IsFatal { get; }
        public Attack Attack { get; }
        internal IAttackable Target {get; }

        internal AttackResult(IAttackable target, Attack attack, bool isFatal)
        {
            IsFatal = isFatal;
            Attack = attack;
            Target = target;
        }
    }
}
