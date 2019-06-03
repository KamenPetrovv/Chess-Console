using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public class Rook : IFigure
    {
        public Rook(Position position,bool isWhite)
        {
            this.Position = position;
            this.PossibleMoves = new List<Position>();
            this.DefaultMoves = new List<Direction>();
            this.IsAlive = true;
            this.IsWhite = isWhite;

            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateHorizontalAndVerticalDirections());
        }
        public Position Position { get; set; }

        public string Symbol { get { return "R"; } }

        public List<Position> PossibleMoves { get; private set; }

        public List<Direction> DefaultMoves { get; private set; }

        public bool IsAlive { get; private set; }

        public bool IsWhite { get; private set; }

        public void CalculatePossibleMoves()
        {
            throw new NotImplementedException();
        }

        public void Kill()
        {
            this.IsAlive = false;
        }
    }
}
