using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Items.Armor
{
    public class Chainmail:Armor
    {
        public Chainmail(double ProtectionPercentage)
            : base(ProtectionPercentage) { }

        public override Attack MitigateAttack(Attack attack)
        {
            if(attack.DamageType == DamageTypes.Slashing) attack.DamageType = DamageTypes.Blunt;
            return base.MitigateAttack(attack);
        }
    }
}
