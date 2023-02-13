using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Items.Weapons
{
    public abstract class Weapon: Item, IWieldable
    {
        //for simplicity's sake, we will consider that a weapon cannot change it's attack once forged
        public int MinDamage { get; }
        public int MaxDamage { get; }

        //some of the weapons we will use might chip or suffer changes that will update the Modifier
        public int Modifier { get; private protected set; } = 0;

        public DamageTypes DamageType { get; }

        public Weapon(int minDamage, int maxDamage, DamageTypes damageType) 
        {
            if (minDamage < 0) throw new ArgumentException(nameof(MinDamage));
            if (maxDamage < minDamage) throw new ArgumentOutOfRangeException(Exceptions.Exception_LowerLimitLargerThanUpperLimit);
            
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            DamageType = damageType;
        }

        //basic weapon damage calculation
        public virtual Attack GetAttack(IAttacker attacker)
        {
            //the modifiers should be represented by a Class Hierarchy
            //to simplify things, I'll just use the following very basic implementation, even if its a bit ugly
            return  new Attack(attacker, 
                Randomizer.Instance.Random.Next(
                    Math.Max(0,MinDamage + Modifier), 
                    Math.Max(0, MaxDamage + Modifier))) {  DamageType = DamageType };
        }
    }
}
