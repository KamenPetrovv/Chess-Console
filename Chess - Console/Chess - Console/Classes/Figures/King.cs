
using System;
using System.Collections.Generic;
using System.Text;
using Chess___Console.Classes.Misc;

namespace Chess___Console.Classes.Figures
{
    public class King : IFigure
    {
        public King(Position position, bool isWhite)
        {
            this.Position = position;
            this.PossibleMoves = new List<Position>();
            this.DefaultMoves = new List<Direction>();
            this.IsAlive = true;
            this.IsWhite = isWhite;

            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GenerateKnightDirections());
        }
        public Position Position { get;  set; }

        public List<Position> PossibleMoves { get; private set; }

        public List<Direction> DefaultMoves { get; private set; }

        public string Symbol { get { return "K"; } }

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
