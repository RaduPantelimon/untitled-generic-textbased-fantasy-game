using GenericRPG.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class Attack
    {
        public double Damage { get; }
        public DamageTypes DamageType { get; internal set; }

        public IAttacker Attacker { get; internal set; }

        //used in case attack suffered a mitigation/reduction effect
        //we still store the original attack
        public Attack? OriginalAttack { get; }

        internal Attack(IAttacker attacker, double damage, Attack originalAttack): this(attacker, damage)
        {
            OriginalAttack = originalAttack;
        }

        internal Attack(IAttacker attacker, double damage)
        {
            if (Damage <= 0) throw new NegativeDamageException();
            Damage = damage;
            Attacker = attacker;
        }
    }
}
