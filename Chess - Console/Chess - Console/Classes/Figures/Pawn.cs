using Chess___Console.Classes.Static_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    class Pawn : IFigure
    {
        public Pawn(Position position, bool isWhite)
        {
            this.Position = position;
            this.PossibleMoves = new List<Position>();
            this.DefaultMoves = new List<Direction>();
            this.IsAlive = true;
            this.IsWhite = isWhite;

            //Populate the Default Moves of the Figure
            DefaultMoves.AddRange(Utility.GeneratePawnDirections(this.IsWhite));
        }

        public string Symbol { get { return "P"; } }

        public Position Position { get; set; }

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
