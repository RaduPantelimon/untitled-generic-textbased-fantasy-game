using GenericRPG.Commands;
using GenericRPG.Creatures;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    //A BASE CLASS NAMED SPELL COULD ALSO BE CREATED
    public abstract class OffensiveSpell: Spell, IOffensiveAbility
    {
        public int MinDamage { get; }
        public int MaxDamage { get; }

        public DamageTypes DamageType { get; }

        //spells might suffer some changes to their base damage, depending on certain conditions
        public int Modifier { get; private protected set; } = 0;

        public OffensiveSpell(int minDamage, int maxDamage, int manaCost, DamageTypes damageType): base(manaCost)
        {
            if (minDamage < 0) throw new ArgumentException(nameof(MinDamage));
            if (maxDamage < minDamage) throw new ArgumentOutOfRangeException(Exceptions.Exception_LowerLimitLargerThanUpperLimit);

            MinDamage = minDamage;
            MaxDamage = maxDamage;
            DamageType = damageType;
        }

        //basic spell damage calculation
        public virtual Attack Cast(SpellCaster caster, IAttackable target)
        {
            caster.CastSpell(this);
            return new Attack(caster,
                                Randomizer.Instance.Random.Next(
                                    Math.Max(0, MinDamage + Modifier),
                                    Math.Max(0, MaxDamage + Modifier)))
                                { DamageType = DamageType };
        }
    }
}
