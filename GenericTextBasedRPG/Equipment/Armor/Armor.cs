using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Equipment.Armor
{
    public abstract class Armor: IWearable
    {
        //for simplicity's sake, we will consider that an armor cannot change it's protection once crafted
        public double ProtectionPercentage { get; }

        public Armor(double protectionPercentage)
        {
            if (protectionPercentage < 0 || protectionPercentage >= 1) throw new ArgumentException(nameof(protectionPercentage));

            ProtectionPercentage = protectionPercentage;
        }

        public virtual Attack MitigateAttack(Attack originalAttack)
        {
            return new Attack(originalAttack.Attacker, originalAttack.Damage * (1 - ProtectionPercentage), originalAttack);
        }
    }
}
