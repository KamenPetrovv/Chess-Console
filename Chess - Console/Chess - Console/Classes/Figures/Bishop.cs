using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public class Bishop : Figure
    {
        public Bishop(Position position, bool isWhite)
            : base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateDiagonalDirections());
        }

        public override string Symbol { get { return "B"; } }

        public override void CalculatePossibleMoves(Board board)
        {
            List<Position> possibleMoves = new List<Position>();

            //Calculate where the figure can move as if there are no other figures on the board
            possibleMoves = this.AddDefaultMovesToCurrentPosition();

            //Filter these possible moves accordingly to the other figures
            IEnumerable<Position> possibleMovesToBottomRight = possibleMoves.Where(pm => pm.X > this.Position.X && pm.Y > this.Position.Y).OrderBy(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToBottomRight, board);

            IEnumerable<Position> possibleMovesToBottomLeft = possibleMoves.Where(pm => pm.X > this.Position.X && pm.Y < this.Position.Y).OrderByDescending(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToBottomLeft, board);

            IEnumerable<Position> possibleMovesToTopLeft = possibleMoves.Where(pm => pm.X < this.Position.X && pm.Y < this.Position.Y).OrderByDescending(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToTopLeft, board);

            IEnumerable<Position> possibleMovesToTopRight = possibleMoves.Where(pm => pm.X < this.Position.X && pm.Y > this.Position.Y).OrderBy(pm => pm.X);
            this.TrimAndAddPossibleMoves(possibleMovesToTopRight, board);
        }

    }
}
