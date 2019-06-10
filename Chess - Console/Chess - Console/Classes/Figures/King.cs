
using System;
using System.Collections.Generic;
using System.Text;
using Chess___Console.Classes.Misc;

namespace Chess___Console.Classes.Figures
{
    public class King : Figure
    {
        public King(Position position, bool isWhite)
            : base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateKnightDirections());
        }

        public override string Symbol { get { return "K"; } }

        public override void CalculatePossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
