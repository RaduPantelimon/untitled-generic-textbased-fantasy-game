
using GenericRPG.Helpers;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public class GameState
    {
        public Player Player { get; }
        public Level? CurrentLevel { get; internal set; }

        bool playerQuit;
        bool playerWon;

        public GameplayStatus Status
        {
            get
            {
                if (playerWon) return GameplayStatus.GameWon;
                if (playerQuit) return GameplayStatus.Quit;
                if (Player.Hero != null && !Player.Hero.IsAlive) return GameplayStatus.Defeat;
                
                if(CurrentLevel == null) return GameplayStatus.LevelNotStarted;
                if (CurrentLevel.LevelFinished) return GameplayStatus.LevelWon;

                //we consider that the player is in combat if the current encounter still has alive mobs
                if (CurrentLevel?.CurrentEncounter != null
                    && CurrentLevel.CurrentEncounter.GetAlive().Count() > 0) return GameplayStatus.InCombat;
                
                //otherwise, player is idle
                return GameplayStatus.Idle;
            }
        }

        internal GameState(Player player)
        {
            Player = player;
        }

        internal virtual void Quit()
        {
            if (playerWon) throw new InvalidOperationException(Exceptions.Exception_GameCannotBeWonAfterQuitting);
            playerQuit = true;
        }

        internal virtual void PlayerWon()
        {
            if (playerQuit) throw new InvalidOperationException(Exceptions.Exception_GameCannotBeWonAfterQuitting);
            playerWon = true;
        }
    }
}