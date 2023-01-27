using RPGUtilities.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment.Weapons
{
    public abstract class Weapon: Item, IWieldable
    {
        //for simplicity's sake, we will consider that a weapon cannot change it's attack once forged
        public double MinAttack { get; }
        public double MaxAttack { get; }

        public PhysicalDamageTypes DamageType { get; }

        internal Weapon(double minAttack, double maxAttack, PhysicalDamageTypes damageType) 
        {
            if (minAttack < 0) throw new ArgumentException(nameof(MinAttack));
            if (maxAttack > minAttack) throw new ArgumentOutOfRangeException(Exceptions.Exception_LowerLimitLargerThanUpperLimit);
            
            MinAttack = minAttack;
            MaxAttack = maxAttack;
            DamageType = damageType;
        }

        //basic weapon damage calculation
        public virtual double GetDamage()
        {
            return (MaxAttack - MinAttack) / 2;
        }
    }
}
