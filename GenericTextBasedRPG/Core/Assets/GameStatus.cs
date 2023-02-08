using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    [Flags]
    public enum PlayerStatus
    {
        Idle = 1,
        InCombat = 2,
        LevelWon = 4,
        Defeat = 8,
        Quit = 16,
        GameWon = 32,
        GameOver = GameWon | Defeat | Quit,
        LevelInProgress = Idle | InCombat, 
    }
}

/*

        public bool PlayerWon => WinCondition;
        public bool PlayerLost => !(Player?.Hero?.IsAlive ?? true);
        public bool IsOver => PlayerQuit || PlayerLost || PlayerWon;
        public bool InCombat => CurrentLevel is { CurrentEncounter: { Count: > 0 } }; 
 
*/