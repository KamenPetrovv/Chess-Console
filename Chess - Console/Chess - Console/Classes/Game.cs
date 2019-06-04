using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class Game
    {
        public Board Board { get; private set; }

        public void Start()
        {
            while (!isGameOver())
            {
                Board.UpdateFigures();

                Move whiteMove = Board.GetMoveFromConsole(true);

                if (Board.isMovePossible(whiteMove))
                {
                    Board.ExecuteMove(move);
                }
                
            }
        }

        private bool isGameOver()
        {
            bool whiteKingIsAlive = this.Board.ContainsFigure("K", true);
            bool blackKingIsAlive = this.Board.ContainsFigure("K", false);

            if (whiteKingIsAlive && blackKingIsAlive)
            {
                return false;
            }

            return true;
        }
    }
}
