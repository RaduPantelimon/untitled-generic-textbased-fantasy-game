﻿using RPGUtilities.Creatures;
using RPGUtilities.Creatures.Specializations;
using RPGUtilities.Equipment.Armor;
using RPGUtilities.Equipment.Weapons;
using RPGUtilities.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{
    //in some cases, a subclass that uses prototypes could be a very good addition
    internal class EnemiesFactory
    {
        
        internal virtual Creature GenerateBasicEnemy() =>
            new Fighter(Randomizer.Instance.Next(HealthLowerLimit, HealthUpperLimit),FigtherStrength);


        internal virtual Creature GenerateMeleeEnemy() =>
            new Fighter( Randomizer.Instance.Next(HealthLowerLimit, HealthUpperLimit), FigtherStrength)
                {Weapon = new Sword(SwordLowerAttack, SwordUpperAttack)};

        internal virtual Creature GenerateRangedEnemy() =>
            new SpellCaster(Randomizer.Instance.Random.Next(HealthLowerLimit, HealthUpperLimit),FigtherStrength)
                {Weapon = new Staff(StaffLowerAttack, StaffUpperAttack)};

        internal virtual Creature GenerateBoss() =>
            new Fighter((int)(Randomizer.Instance.Random.Next(HealthLowerLimit, HealthUpperLimit) * BossMultiplier), 
                (uint)(FigtherStrength * BossMultiplier))
            {
                Weapon = new Sword((int)(StaffLowerAttack * BossMultiplier), (int)(StaffUpperAttack * BossMultiplier) ),
                Armor = new Chainmail(MailArmorReduction * BossMultiplier)
            };


        protected static int CasterMana { get; }
        protected static uint FigtherStrength { get; }
        
        protected static int SwordLowerAttack { get; }
        protected static int SwordUpperAttack { get; }
        protected static int StaffLowerAttack { get; }
        protected static int StaffUpperAttack { get; }
        protected static double MailArmorReduction { get; }

        protected static int HealthUpperLimit { get; }
        protected static int HealthLowerLimit { get; }

        
        protected static double BossMultiplier { get; }

        static EnemiesFactory()
        {
            FigtherStrength = Convert.ToUInt32(Mechanics.DefaultEnemies_Fighter_Strength);
            CasterMana = Convert.ToInt32(Mechanics.DefaultEnemies_SpellCaster_Mana);

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