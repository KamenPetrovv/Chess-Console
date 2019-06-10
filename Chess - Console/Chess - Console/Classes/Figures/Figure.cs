﻿using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes.Figures
{
    public abstract class Figure : IFigure
    {
        public Figure(Position position, bool isWhite)
        {
            this.Position = position;
            this.PossibleMoves = new List<Position>();
            this.DefaultMoves = new List<Direction>();
            this.IsAlive = true;
            this.IsWhite = isWhite;
        }
        public Position Position { get; set; }

        public List<Position> PossibleMoves { get; set; }

        public List<Direction> DefaultMoves { get; set; }

        public bool IsAlive { get; private set; }

        public bool IsWhite { get; set; }

        public abstract string Symbol { get; }

        public abstract void CalculatePossibleMoves(Board board);

        public bool ContainsPossibleMove(Move move)
        {
            for (int i = 0; i < this.PossibleMoves.Count; i++)
            {
                bool xIsTheSame = this.PossibleMoves[i].X == move.ToPosition.X;
                bool yIsTheSame = this.PossibleMoves[i].Y == move.ToPosition.Y;

                if (xIsTheSame && yIsTheSame)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Position> AddDefaultMovesToCurrentPosition()
        {
            List<Position> possibleMovesInsideTheBorders = new List<Position>();

            //Position is from (0,0) to (7,7)
            //Direction is from (-7,-7) to (7,7)
            //Calculate the possible moves that are inside the board.
            for (int i = 0; i < this.DefaultMoves.Count; i++)
            {
                int possibleMoveX = this.Position.X + this.DefaultMoves[i].X;
                int possibleMoveY = this.Position.Y + this.DefaultMoves[i].Y;

                if (Utility.isInBounds(possibleMoveX) && Utility.isInBounds(possibleMoveY))
                {
                    Position possibleMove = new Position(possibleMoveX, possibleMoveY);
                    possibleMovesInsideTheBorders.Add(possibleMove);
                }
            }

            return possibleMovesInsideTheBorders;
        }

        public void Kill()
        {
            this.IsAlive = false;
        }

        public void ReviveAndPlace(Position position)
        {
            this.IsAlive = true;

            this.Position = position;
        }
    }
}
