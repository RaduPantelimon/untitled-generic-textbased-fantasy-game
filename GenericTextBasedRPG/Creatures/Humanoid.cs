using GenericRPG.Combat;
using GenericRPG.Commands;
using GenericRPG.Equipment;
using GenericRPG.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    public abstract class Humanoid : Creature
    {
        
        public abstract double UnnarmedDamage { get; }

        public IWieldable? Weapon { get; internal set; }
        public IWearable? Armor { get; internal set; }

        internal Humanoid(double hitpoints) : base(hitpoints) { }

        //basic inflict damage - either weapon attack or unnarmed if weapon missing
        protected private override Attack GenerateAttack(IAttackable target)
                => Weapon?.GetAttack(this) ?? new Attack(this, UnnarmedDamage) { DamageType = DamageTypes.Blunt };
            
        //humanoids use armor to mitigate attack
        protected private override Attack MitigateAttack(Attack attack)=> Armor?.MitigateAttack(attack) ?? attack;

    }
}
