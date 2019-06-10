using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
