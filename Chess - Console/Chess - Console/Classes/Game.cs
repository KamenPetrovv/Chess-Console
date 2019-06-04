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
                Move whiteMove = Board.GetMoveFromConsole(true);

                //Board.isMovePossible()
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
