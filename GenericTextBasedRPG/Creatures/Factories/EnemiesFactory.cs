using GenericRPG.Creatures;
using GenericRPG.Creatures.Specializations;
using GenericRPG.Equipment.Armor;
using GenericRPG.Equipment.Weapons;
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


        internal virtual Creature GenerateMeleeEnemy() =>
            new Fighter( Randomizer.Instance.Next(HealthLowerLimit, HealthUpperLimit), FigtherStrength)
            { 
                Name = Mechanics.Tutorial_MeleeEnemyName, 
                Weapon = new Dagger(DaggerLowerAttack, DaggerUpperAttack)
            };

        internal virtual Creature GenerateCasterEnemy() =>
            new SpellCaster(Randomizer.Instance.Random.Next(HealthLowerLimit, HealthUpperLimit),CasterMana)
            { 
                Name = Mechanics.Tutorial_CasterEnemyName,
                Weapon = new Staff(StaffLowerAttack, StaffUpperAttack)
            };

        internal virtual Creature GenerateBoss() =>
            new Fighter((int)(Randomizer.Instance.Random.Next(HealthLowerLimit, HealthUpperLimit) * BossMultiplier), 
                (uint)(FigtherStrength * BossMultiplier))
            {
                Name = Mechanics.Tutorial_BossName,
                Weapon = new Sword((int)(SwordLowerAttack * BossMultiplier), (int)(SwordUpperAttack * BossMultiplier) ),
                Armor = new Chainmail(MailArmorReduction * BossMultiplier)
            };

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

        private protected static int CasterMana { get; }
        private protected static uint FigtherStrength { get; }

        private protected static int DaggerLowerAttack { get; }
        private protected static int DaggerUpperAttack { get; }
        private protected static int SwordLowerAttack { get; }
        private protected static int SwordUpperAttack { get; }
        private protected static int StaffLowerAttack { get; }
        private protected static int StaffUpperAttack { get; }
        private protected static double MailArmorReduction { get; }

        private protected static int HealthUpperLimit { get; }
        private protected static int HealthLowerLimit { get; }

        private protected static double BossMultiplier { get; }

        static EnemiesFactory()
        {
            FigtherStrength = Convert.ToUInt32(Mechanics.DefaultEnemies_Fighter_Strength);
            CasterMana = Convert.ToInt32(Mechanics.DefaultEnemies_SpellCaster_Mana);

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
