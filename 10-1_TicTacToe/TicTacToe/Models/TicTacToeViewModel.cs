using System;
using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class TicTacToeViewModel
    {
        public List<Cell> Cells { get; set; }
        public Cell Selected { get; set; }
        public bool IsGameOver { get; set; }

        internal static object Equals(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
