using GenericRPG.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    //TO DO POPULATE CLASS
    public class DeathEventArgs: EventArgs
    {
        IAttackable Target { get; }

        internal DeathEventArgs(IAttackable target)
        {
            Target = target;
        }
    }
}
