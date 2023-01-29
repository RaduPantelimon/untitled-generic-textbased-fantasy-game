using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public class TutorialLevel: Level
    {

        HostileParty<Creature> Enemies { get;}

        internal TutorialLevel(Game currentGame, EnemiesFactory enemiesFactory, List<Command> commands) 
            : base(currentGame, commands)
        {
            Enemies = enemiesFactory.GetEnemiesGroup(Combat.Enums.PartySize.Medium);
        }

        public override bool PlayerWon => Enemies.Count == 0 && Started;
        public override bool IsOver => PlayerQuit || !(CurrentGame.Player?.Hero?.IsAlive! ?? true) || PlayerWon;
    }
}
