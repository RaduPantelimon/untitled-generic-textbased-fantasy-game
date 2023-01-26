﻿using RPGUtilities.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Creatures
{
    public abstract class Creature: IAttackable, IAttacker
    {
        public double HitPoints { get; protected set; }
        public double MaxHitPoints { get; protected set; }
        public virtual bool Alive => HitPoints > 0;

        internal Creature(double hitpoints)
        {
            if(hitpoints < 0 ) throw new ArgumentOutOfRangeException(nameof(hitpoints));
            MaxHitPoints = HitPoints = hitpoints; 
        }

        public virtual void TakeDamage(double damage)
        {
            if (damage <= 0) throw new NegativeDamageException();
            HitPoints -= damage;
        }

        public abstract void DoDamage(IAttackable target);
    }
}