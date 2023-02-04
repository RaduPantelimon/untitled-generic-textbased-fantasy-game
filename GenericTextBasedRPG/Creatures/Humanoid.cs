using GenericRPG.Combat;
using GenericRPG.Commands;
using GenericRPG.Equipment;
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

        public Humanoid(double hitpoints) : base(hitpoints) { }

        //basic inflict damage - either weapon attack or unnarmed if weapon missing
        public override Attack GenerateAttack(IAttackable target)
                => Weapon?.GetAttack(this) ?? new Attack(this, UnnarmedDamage) { DamageType = DamageTypes.Blunt };

        //humanoids use armor to mitigate attack
        public override Attack MitigateAttack(Attack attack)=> Armor?.MitigateAttack(attack) ?? attack;

    }
}
