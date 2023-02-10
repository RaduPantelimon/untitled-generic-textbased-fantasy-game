using GenericRPG.Creatures;
using GenericRPG.Items.Armor;
using GenericRPG.Items.Weapons;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    //in some cases, a subclass that uses prototypes could be a very good addition
    internal class EnemiesFactory
    {
        
        internal virtual Creature GenerateBasicEnemy() =>
            new Fighter(Randomizer.Instance.Next(HealthLowerLimit, HealthUpperLimit), FigtherStrength) 
                { Name =  Mechanics.Tutorial_BasicEnemyName };

        internal virtual Creature GenerateMeleeEnemy()
        {
            Humanoid mob = new Fighter(Randomizer.Instance.Next(HealthLowerLimit, HealthUpperLimit), FigtherStrength)
            {
                Name = Mechanics.Tutorial_MeleeEnemyName
            };
            mob.Equipment.Weapon = new Dagger(DaggerLowerAttack, DaggerUpperAttack);
            return mob;
        }
           
        internal virtual Creature GenerateCasterEnemy()
        {
            Humanoid mob = new SpellCaster(Randomizer.Instance.Random.Next(HealthLowerLimit, HealthUpperLimit),
                CasterMana, new Spell[] { new Fireball(FireballLowerAttack, FireballUpperAttack, FireballManaCost) })
            {
                Name = Mechanics.Tutorial_CasterEnemyName
            };
            mob.Equipment.Weapon = new Staff(StaffLowerAttack, StaffUpperAttack);
            return mob;
        }

        internal virtual Creature GenerateBoss()
        {
            Humanoid mob = new Fighter((int)(Randomizer.Instance.Random.Next(HealthLowerLimit, HealthUpperLimit) * BossMultiplier),
                (uint)(FigtherStrength * BossMultiplier))
            {
                Name = Mechanics.Tutorial_BossName,
            };
            mob.Equipment.Weapon = new Sword((int)(SwordLowerAttack * BossMultiplier), (int)(SwordUpperAttack * BossMultiplier));
            mob.Equipment.Armor = new Chainmail(MailArmorReduction * BossMultiplier);
            return mob;
        }
       
        //very basic default implementation
        internal virtual HostileParty<Creature> GetEnemiesGroup(PartySize size) => size switch
        {
            PartySize.Small => new HostileParty<Creature> { GenerateBasicEnemy(),
                                                            GenerateMeleeEnemy() },

            PartySize.Medium => new HostileParty<Creature> { GenerateBasicEnemy(),
                                                            GenerateMeleeEnemy(),
                                                            GenerateMeleeEnemy() },

            PartySize.Large => new HostileParty<Creature> { GenerateBasicEnemy(),
                                                            GenerateMeleeEnemy(),
                                                            GenerateMeleeEnemy(),
                                                            GenerateCasterEnemy(),
                                                            GenerateBoss()},

            _ => new HostileParty<Creature> { GenerateMeleeEnemy() },
        };

        internal static int CasterMana { get; }
        internal static uint FigtherStrength { get; }

        internal static int FireballManaCost { get; }
        internal static int FireballLowerAttack { get; }
        internal static int FireballUpperAttack { get; }
        internal static int DaggerLowerAttack { get; }
        internal static int DaggerUpperAttack { get; }
        internal static int SwordLowerAttack { get; }
        internal static int SwordUpperAttack { get; }
        internal static int StaffLowerAttack { get; }
        internal static int StaffUpperAttack { get; }
        internal static double MailArmorReduction { get; }

        internal static int HealthUpperLimit { get; }
        internal static int HealthLowerLimit { get; }

        internal static double BossMultiplier { get; }

        static EnemiesFactory()
        {
            FigtherStrength = Convert.ToUInt32(Mechanics.DefaultEnemies_Fighter_Strength);
            CasterMana = Convert.ToInt32(Mechanics.DefaultEnemies_SpellCaster_Mana);

            FireballLowerAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Fireball_LowerAttack);
            FireballUpperAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Fireball_UpperAttack);
            FireballManaCost = Convert.ToInt32(Mechanics.DefaultEnemies_Fireball_ManaCost);
            DaggerLowerAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Dagger_LowerAttack);
            DaggerUpperAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Dagger_UpperAttack);
            SwordLowerAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Sword_LowerAttack);
            SwordUpperAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Sword_UpperAttack);
            StaffLowerAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Staff_LowerAttack);
            StaffUpperAttack = Convert.ToInt32(Mechanics.DefaultEnemies_Staff_UpperAttack);

            HealthUpperLimit = Convert.ToInt32(Mechanics.DefaultEnemies_HitPoints_UpperLimit);
            HealthLowerLimit = Convert.ToInt32(Mechanics.DefaultEnemies_HitPoints_LowerLimit);

            MailArmorReduction = Convert.ToDouble(Mechanics.DefaultEnemies_Mail_ArmorReduction);

            BossMultiplier = Convert.ToDouble(Mechanics.DefaultEnemies_BossMultiplier);
        }
    }


}
