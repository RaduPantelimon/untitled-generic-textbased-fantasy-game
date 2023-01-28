using RPGUtilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGUtilities.Creatures
{
    public abstract class Creature: IAttackable, IAttacker
    {
        public string? Name { get; init; }

        private double hitpoints;
        public double HitPoints { 
            get => hitpoints; 
            private protected set {


                if (hitpoints > 0 && hitpoints <= value) 
                {
                    hitpoints = 0;
                    OnDeath(new CreatureDeathEventArgs());
                    return;
                }
                hitpoints -= value;
            } 
        }
        public double MaxHitPoints { get; internal set; }
        public virtual bool IsAlive => HitPoints > 0;

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

        private void OnDeath(CreatureDeathEventArgs args)
        {
            CreatureDied?.Invoke(this, args);
        }

        //we might want to be able to subscribe to the death event of a creature
        public event EventHandler<CreatureDeathEventArgs> CreatureDied;
    }
}
