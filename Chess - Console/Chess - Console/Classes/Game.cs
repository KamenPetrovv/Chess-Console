using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class Game
    {
        public Game()
        {
            this.Board = new Board();
        }

        public Board Board { get; private set; }

        public void Start()
        {
            while (!isGameOver())
            {
                Board.UpdateFigures();

                Board.Draw();

                Move whiteMove = Board.GetMoveFromConsole(true);

                if (Board.isMovePossible(whiteMove))
                {
                    Board.ExecuteMove(whiteMove);
                }

                Board.Draw();

                Move blackMove = Board.GetMoveFromConsole(false);

                if (Board.isMovePossible(blackMove))
                {
                    Board.ExecuteMove(blackMove);
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
