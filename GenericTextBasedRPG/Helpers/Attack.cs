using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities
{
    public class Attack
    {
        public DamageTypes DamageType { get; internal set; }
        public double Damage { get; internal set; }

        internal Attack(double damage)
        {
            Damage = damage;
        }
    }
}
