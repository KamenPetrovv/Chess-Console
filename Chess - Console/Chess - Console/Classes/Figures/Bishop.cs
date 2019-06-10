using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
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

            possibleMoves = this.AddDefaultMovesToCurrentPosition();

            //TODO
        }

    }
}
