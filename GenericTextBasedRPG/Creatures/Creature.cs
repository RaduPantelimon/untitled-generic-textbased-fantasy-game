using GenericRPG;
using GenericRPG.Combat;
using GenericRPG.Equipment.Weapons;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericRPG.Creatures
{
    public abstract class Creature: IAttackable, IAttacker
    {
        public string? Name { get; init; }

        private double hitpoints;

        public double HitPoints 
        {
            get => hitpoints; 
            private protected set
            {
                if (HitPoints > 0 && HitPoints <= value)
                {
                    HitPoints = 0;
                    OnDeath(new DeathEventArgs(this));
                }
                else HitPoints = value;
            }
        }

        public double MaxHitPoints { get; private protected set; }
        public bool IsAlive => HitPoints > 0;

        //mitigate or absorb damage - mitigate with armor / natural defense or take it full on if armor missing
        public abstract Attack MitigateAttack(Attack attack);

        //generate attack
        public abstract Attack GenerateAttack(IAttackable target);

        public Creature(double hitpoints)
        {
            if(hitpoints < 0 ) throw new ArgumentOutOfRangeException(nameof(hitpoints));
            MaxHitPoints = HitPoints = hitpoints; 
        }

        //template method
        public AttackResult TakeDamage(Attack attack)
        {
            var mitigatedAttack = MitigateAttack(attack);
         
            //take damage
            HitPoints -= mitigatedAttack.Damage;
            AttackResult attackResult =  new AttackResult(this, attack);
            OnHit(new AttackEventArgs(attack, attackResult));
            return attackResult;
        }

        //template method
        public AttackResult DoDamage(IAttackable target)
        {
            Attack attack = GenerateAttack(target);

            AttackResult result =  target.TakeDamage(attack);
            OnAttack(new AttackEventArgs(attack, result));
            return result;
        }

        public override string? ToString() => Name ?? base.ToString();
        public virtual string DisplayStats() => "HP: " + HitPoints.ToString(Messages.Formatting_StatsNumberFormatting);

        //EVENTS
        private void OnDeath(DeathEventArgs args)=> CreatureDied?.Invoke(this, args);
        private void OnHit(AttackEventArgs args) => CreatureHit?.Invoke(this, args);
        private void OnAttack(AttackEventArgs args) => CreatureAttacks?.Invoke(this, args);

        //we might want to be able to subscribe to certain events in the life of a creature
        public event EventHandler<DeathEventArgs>? CreatureDied;
        public event EventHandler<AttackEventArgs>? CreatureHit;
        public event EventHandler<AttackEventArgs>? CreatureAttacks;
    }
}
