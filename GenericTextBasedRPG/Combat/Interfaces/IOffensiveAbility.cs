using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public interface IOffensiveAbility
    {
        public int MinDamage { get; }
        public int MaxDamage { get; }

        public DamageTypes DamageType { get; }

    }
}
