using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public class Queen : Figure
    {
        public Queen(Position position, bool isWhite) :
            base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateDiagonalDirections());
            DefaultMoves.AddRange(Utility.GenerateHorizontalAndVerticalDirections());
        }

        public override string Symbol { get { return "Q"; } }

        public override void CalculatePossibleMoves(Board board)
        {
            List<Position> possibleMoves = new List<Position>();

            //Calculate where the figure can move as if there are no other figures on the board

            //Diagonals
            possibleMoves = this.AddDefaultMovesToCurrentPosition();

            IEnumerable<Position> possibleMovesToBottomRight = possibleMoves.Where(pm => pm.X > this.Position.X && pm.Y > this.Position.Y).OrderBy(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToBottomRight, board);

            IEnumerable<Position> possibleMovesToBottomLeft = possibleMoves.Where(pm => pm.X > this.Position.X && pm.Y < this.Position.Y).OrderByDescending(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToBottomLeft, board);

            IEnumerable<Position> possibleMovesToTopLeft = possibleMoves.Where(pm => pm.X < this.Position.X && pm.Y < this.Position.Y).OrderByDescending(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToTopLeft, board);

            IEnumerable<Position> possibleMovesToTopRight = possibleMoves.Where(pm => pm.X < this.Position.X && pm.Y > this.Position.Y).OrderBy(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToTopRight, board);

            //Straight lines
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
