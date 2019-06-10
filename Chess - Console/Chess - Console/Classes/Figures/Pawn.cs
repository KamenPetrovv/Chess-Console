using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public class Pawn : Figure
    {
        public Pawn(Position position, bool isWhite) :
            base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GeneratePawnDirections(this.IsWhite));
        }

        public override string Symbol { get { return "P"; } }

        public override void CalculatePossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
