using RPGUtilities.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment.Armor
{
    public abstract class Armor: IWearable
    {
        //for simplicity's sake, we will consider that an armor cannot change it's protection once crafted
        public double ProtectionPercentage { get; }

        internal Armor(double protectionPercentage)
        {
            if (protectionPercentage < 0 || protectionPercentage >= 1) throw new ArgumentException(nameof(protectionPercentage));

            ProtectionPercentage = protectionPercentage;
        }

        public virtual Attack MitigateAttack(Attack attack)
        {
            attack.Damage *= ProtectionPercentage;
            return attack;
        }
    }
}
