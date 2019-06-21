
using System;
using System.Collections.Generic;
using System.Text;
using Chess___Console.Classes.Misc;
using System.Linq;

namespace Chess___Console.Classes.Figures
{
    public class King : Figure
    {
        public King(Position position, bool isWhite)
            : base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateKingDirections());
        }

        public override string Symbol { get { return "K"; } }

        public override void CalculatePossibleMoves(Board board)
        {
            List<Position> possibleMoves = new List<Position>();
           
            //Calculate where the figure can move as if there are no other figures on the board
            possibleMoves = this.AddDefaultMovesToCurrentPosition();

            //Filter these possible moves accordingly to the other figures

            this.AddPossibleMoves(possibleMoves, board);
        }
    }
}
