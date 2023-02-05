using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Equipment
{
    //other stuff specific to wieldable items should go here
    public interface IWieldable:IOffensiveAbility
    {
        public Attack GetAttack(IAttacker attacker);
    }
}
