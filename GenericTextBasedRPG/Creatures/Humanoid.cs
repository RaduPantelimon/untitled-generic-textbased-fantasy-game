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
        public override void DoDamage(IAttackable target)=> target.TakeDamage(Weapon?.GetAttack()?? 
                                                new Attack(UnnarmedDamage){ DamageType = DamageTypes.Blunt});

        //basic take damage - mitigate with armor or take full on if armor missing
        public override void TakeDamage(Attack attack)=> base.TakeDamage(Armor?.MitigateAttack(attack) ?? attack);

    }
}
