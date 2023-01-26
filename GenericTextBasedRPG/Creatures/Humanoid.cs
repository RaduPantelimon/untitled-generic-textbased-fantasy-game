using RPGUtilities.Equipment;
using RPGUtilities.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Creatures
{
    public abstract class Humanoid : Creature
    {
        public string Name { get; init; }
        
        public abstract double UnnarmedDamage { get; }

        public IWieldable? Weapon { get; protected set; }
        public IWearable? Armor { get; protected set; }

        internal Humanoid(string name, double hitpoints) : base(hitpoints)
        {
            Name = name;
        }

        //basic do damage - either weapon attack or unnarmed if weapon missing
        public override void DoDamage(IAttackable target)=> target.TakeDamage(Weapon?.GetDamage()??UnnarmedDamage);

        //basic take damage - mitigate with armor or take full on if armor missing
        public override void TakeDamage(double damage)=> base.TakeDamage(Armor?.MitigateAttack(damage)??damage);

        public override string ToString() => Name;
    }
}
