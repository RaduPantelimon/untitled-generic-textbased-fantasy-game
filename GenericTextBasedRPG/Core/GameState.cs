
using GenericRPG.Helpers;
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

        public PlayerStatus Status
        {
            get
            {
                PlayerStatus status = 0;

                if (playerWon) status|= PlayerStatus.GameWon;
                if (playerQuit) status |= PlayerStatus.Quit;
                if (Player.Hero != null && !Player.Hero.IsAlive) status |= PlayerStatus.Defeat;
                if (CurrentLevel != null && CurrentLevel.LevelFinished) status |= PlayerStatus.LevelWon;

                //we consider that the player is in combat if the current encounter still has alive mobs
                if (CurrentLevel?.CurrentEncounter != null
                    && CurrentLevel.CurrentEncounter.GetAlive().Count() > 0) status |= PlayerStatus.InCombat;
                //if player is on a level, but not in combat, they are idle
                else if (CurrentLevel != null)
                    status |= PlayerStatus.Idle;

                return status;
            }
        }

        internal GameState(Player player)
        {
            Player = player;
        }

        internal virtual void Quit()
        {
            playerQuit = true;
        }

        internal virtual void PlayerWon()
        {
            playerWon = true;
        }
    }
}