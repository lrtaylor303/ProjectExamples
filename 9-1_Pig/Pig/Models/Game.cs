using System;

namespace Pig.Models
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string CurrentPlayerName { get; set; }
        public int LastRoll { get; set; }
        public static int WinningNumber = 20;
        public int CurrentTurnScore { get; set; }
    }
}
