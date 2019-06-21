using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public class Knight : Figure
    {
        public Knight(Position position, bool isWhite) :
            base(position, isWhite)
        {
            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateKnightDirections());
        }

        public override string Symbol { get { return "N"; } }

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
