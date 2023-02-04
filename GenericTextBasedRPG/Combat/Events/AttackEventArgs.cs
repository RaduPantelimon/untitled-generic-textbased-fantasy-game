using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Combat
{
    public class AttackEventArgs : EventArgs
    {
        AttackResult AttackResult { get; }
        Attack Attack { get; }

        internal AttackEventArgs(Attack attack, AttackResult attackResult)
        {
            AttackResult = attackResult;
            Attack = attack;
        }
    }
}
