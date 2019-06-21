using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public class Rook : Figure
    {
        public Rook(Position position, bool isWhite) :
            base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateHorizontalAndVerticalDirections());
        }

        public override string Symbol { get { return "R"; } }

        public override void CalculatePossibleMoves(Board board)
        {
            List<Position> possibleMoves = new List<Position>();

            //Calculate where the figure can move as if there are no other figures on the board
            possibleMoves = this.AddDefaultMovesToCurrentPosition();

            //Filter these possible moves accordingly to the other figures
            IEnumerable<Position> possibleMovesDown = possibleMoves.Where(pm => pm.X > this.Position.X && pm.Y == this.Position.Y).OrderBy(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesDown, board);

            IEnumerable<Position> possibleMovesRight = possibleMoves.Where(pm => pm.X == this.Position.X && pm.Y > this.Position.Y).OrderBy(pm => pm.Y);
            this.TrimAndAddPossibleMoves(possibleMovesRight, board);

            IEnumerable<Position> possibleMovesUp = possibleMoves.Where(pm => pm.X < this.Position.X && pm.Y == this.Position.Y).OrderByDescending(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesUp, board);

            IEnumerable<Position> possibleMovesLeft = possibleMoves.Where(pm => pm.X == this.Position.X && pm.Y < this.Position.Y).OrderByDescending(pm => pm.Y);
            this.TrimAndAddPossibleMoves(possibleMovesLeft, board);
        }

    }
}
