using RPGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGUtilities.Creatures
{
    public abstract class Creature: IAttackable, IAttacker
    {
        public string? Name { get; init; }

        public double HitPoints { get; internal set; }
        public double MaxHitPoints { get; internal set; }
        public virtual bool Alive => HitPoints > 0;

        internal Creature(double hitpoints)
        {
            if(hitpoints < 0 ) throw new ArgumentOutOfRangeException(nameof(hitpoints));
            MaxHitPoints = HitPoints = hitpoints; 
        }

        public virtual void TakeDamage(Attack attack)
        {
            if (attack.Damage <= 0) throw new NegativeDamageException();
            HitPoints -= attack.Damage;
        }
       
        public abstract void DoDamage(IAttackable target);

        public override string? ToString() => Name ?? base.ToString();
    }
}
