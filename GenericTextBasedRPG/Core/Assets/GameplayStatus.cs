using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    [Flags]
    public enum GameplayStatus
    {
        LevelNotStarted = 1,
        Idle = 2,
        InCombat = 4,
        LevelWon = 8,
        Defeat = 16,
        Quit = 32,
        GameWon = 64,
        GameOver = GameWon | Defeat | Quit,
        LevelInProgress = Idle | InCombat, 
        ReadyForNextLevel = LevelNotStarted | LevelWon
    }
}