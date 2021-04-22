using System.Collections.Generic;

namespace TicTacToe.Models
{
    public class TicTacToeBoard
    {
        private List<Cell> cells { get; set; }

        // initalize list of cells in constructor. Include one Cell object
        // for each cell on the tic tac toe grid.


        public TicTacToeBoard()  
        {
            cells = new List<Cell>() { new Cell() { Id = "1" }, new Cell() { Id = "2" }, new Cell() { Id = "3Right" }, new Cell() { Id = "4" }, new Cell() { Id = "5" }, new Cell() { Id = "6Right" }, new Cell() { Id = "7" }, new Cell() { Id = "8" }, new Cell() { Id = "9Right" }, };

        }

        public bool HasWinner { get; set; }
        public string WinningMark { get; set; }
        public bool HasAllCellsSelected { get; set; }

        public List<Cell> GetCells() => cells;

        public void CheckForWinner(List<Cell> selectedCells)
        {
            cells = selectedCells;
            // reset winner fields before check
            HasWinner = false;
            WinningMark = string.Empty;
            HasAllCellsSelected = false;

            // check top row
            if (IsWinner(cells[0].Mark, cells[1].Mark, cells[2].Mark))
            {
                HasWinner = true;
            }

            // check middle row
            if (IsWinner(cells[3].Mark, cells[4].Mark, cells[5].Mark))
            {
                HasWinner = true;
            }

            // check bottom row
            if (IsWinner(cells[6].Mark, cells[7].Mark, cells[8].Mark))
            {
                HasWinner = true;
            }

            // check left column
            if (IsWinner(cells[0].Mark, cells[3].Mark, cells[6].Mark))
            {
                HasWinner = true;
            }

            // check middle column
            if (IsWinner(cells[1].Mark, cells[4].Mark, cells[7].Mark))
            {
                HasWinner = true;
            }

            // check right column
            if (IsWinner(cells[2].Mark, cells[5].Mark, cells[8].Mark))
            {
                HasWinner = true;
            }

            // check left-to-right diagonal
            if (IsWinner(cells[0].Mark, cells[4].Mark, cells[8].Mark))
            {
                HasWinner = true;
            }

            // check right-to-left diagonal
            if (IsWinner(cells[2].Mark, cells[4].Mark, cells[6].Mark))
            {
                HasWinner = true;
            }


            HasAllCellsSelected = cells.TrueForAll(_ => !string.IsNullOrEmpty(_.Mark));

            //// check if all cells are marked - set to true to start, then set to false if a cell is blank
            //if (cells[0].Mark == null || cells[1].Mark == null || cells[2].Mark == null || cells[3].Mark == null || cells[4].Mark == null || cells[5].Mark == null || cells[6].Mark == null || cells[7].Mark == null || cells[8].Mark == null)
            //{
            //    HasAllCellsSelected = false;
            //} else if (cells[0].Mark != null && cells[1].Mark != null && cells[2].Mark != null && cells[3].Mark != null && cells[4].Mark != null && cells[5].Mark != null && cells[6].Mark != null && cells[7].Mark != null && cells[8].Mark != null)
            //{
            //    HasAllCellsSelected = true;
            //}

        }

        private bool IsWinner(string mark1, string mark2, string mark3)
        {
            // all three marks match, and they aren't null
            return mark1 == mark2 && mark2 == mark3 && !string.IsNullOrEmpty(mark1);
        }

    }
}
