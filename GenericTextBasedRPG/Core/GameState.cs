
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
                GameplayStatus status = 0;

                if (playerWon) status|= GameplayStatus.GameWon;
                if (playerQuit) status |= GameplayStatus.Quit;
                if (Player.Hero != null && !Player.Hero.IsAlive) status |= GameplayStatus.Defeat;
                if (CurrentLevel != null && CurrentLevel.LevelFinished) status |= GameplayStatus.LevelWon;

                //we consider that the player is in combat if the current encounter still has alive mobs
                if (CurrentLevel?.CurrentEncounter != null
                    && CurrentLevel.CurrentEncounter.GetAlive().Count() > 0) status |= GameplayStatus.InCombat;
                //if player is on a level, but not in combat, they are idle
                else if (CurrentLevel != null)
                    status |= GameplayStatus.Idle;

                return status;
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