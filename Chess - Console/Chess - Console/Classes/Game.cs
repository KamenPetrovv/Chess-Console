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

                while (!Board.isMovePossible(whiteMove))
                {
                    Board.Draw();
                    Console.WriteLine("Move wasn't possible. Try again");
                    whiteMove = Board.GetMoveFromConsole(true);
                }

                Board.ExecuteMove(whiteMove);

                Board.UpdateFigures();

                Board.Draw();

                Move blackMove = Board.GetMoveFromConsole(false);

                while (!Board.isMovePossible(blackMove))
                {
                    Board.Draw();
                    Console.WriteLine("Move wasn't possible. Try again");
                    blackMove = Board.GetMoveFromConsole(false);
                }

                Board.ExecuteMove(blackMove);
            }
            Console.WriteLine("Game is over!");
            bool whiteKingIsAlive = this.Board.ContainsFigure("K", true);
            bool blackKingIsAlive = this.Board.ContainsFigure("K", false);

            if (!whiteKingIsAlive)
            {
                Console.WriteLine("Blacks win!");
            }
            if (!blackKingIsAlive)
            {
                Console.WriteLine("Whites win!");
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
