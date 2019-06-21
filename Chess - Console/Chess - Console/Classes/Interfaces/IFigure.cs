using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public interface IFigure
    {
        Position Position { get; set; }
         
        List<Position> PossibleMoves { get; }

        List<Direction> DefaultMoves { get; }

        void CalculatePossibleMoves(Board board);

        bool ContainsPossibleMove(Move move);

        bool IsAlive { get;  }

        bool IsWhite { get; }

        void Kill();

        string Symbol { get; }
    }
}
