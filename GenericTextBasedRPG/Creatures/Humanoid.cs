using GenericRPG.Combat;
using GenericRPG.Commands;
using GenericRPG.Equipment;
using GenericRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    public abstract class Humanoid : Creature
    {
        //let's consider that humanoids can have fists/horns/claws or other natural weapons that can be "weilded"
        public IWieldable NaturalWeapon { get; private protected set; }

        public IWieldable? Weapon { get; internal set; }
        public IWearable? Armor { get; internal set; }

        public Humanoid(double hitpoints) : base(hitpoints) 
        {
            NaturalWeapon = new Fist();
        }

        //basic inflict damage - either weapon attack or unnarmed if weapon missing
        public override Attack GenerateAttack(IAttackable target)
                => Weapon?.GetAttack(this) ?? NaturalWeapon.GetAttack(this);

        //humanoids use armor to mitigate attack
        public override Attack MitigateAttack(Attack attack)=> Armor?.MitigateAttack(attack) ?? attack;

    }
}
