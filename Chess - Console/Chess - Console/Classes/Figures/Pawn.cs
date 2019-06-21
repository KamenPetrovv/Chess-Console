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
            List<Position> possibleMoves = new List<Position>();

            //Calculate where the figure can move as if there are no other figures on the board
            possibleMoves = this.AddDefaultMovesToCurrentPosition();

            //Filter these possible moves accordingly to the other figures

            foreach (Position possibleMove in possibleMoves)
            {
                if (this.IsWhite)
                {
                    //(-1,-1) and (-1,1)
                    if (possibleMove.Y != this.Position.Y)
                    {
                        IFigure figure = board.GetFigureOnPosition(possibleMove);

                        //We can take this figure
                        if (figure != null)
                        {
                            this.PossibleMoves.Add(possibleMove);
                        }
                    }

                    //(-1,0)
                    if (possibleMove.X == this.Position.X - 1 && possibleMove.Y == this.Position.Y)
                    {
                        IFigure figure = board.GetFigureOnPosition(possibleMove);

                        if (figure == null)
                        {
                            this.PossibleMoves.Add(possibleMove);
                        }
                        else
                        {
                            //No reason to check for (-2,0) becasue there is a figure infront of the pawn
                            return;
                        }
                    }
                    
                    //(-2,0)
                    // 5 == 7 - 2. Whites are on the bottom
                    if (possibleMove.X == this.Position.X - 2)
                    {
                        IFigure figure = board.GetFigureOnPosition(possibleMove);

                        if (figure == null)
                        {
                            this.PossibleMoves.Add(possibleMove);
                        }
                    }
                }
                //Is black. Blacks are on top ;)
                else
                {
                    //(1,-1) and (1,1)
                    if (possibleMove.Y != this.Position.Y)
                    {
                        IFigure figure = board.GetFigureOnPosition(possibleMove);

                        //We can take this figure
                        if (figure != null)
                        {
                            this.PossibleMoves.Add(possibleMove);
                        }
                    }

                    //(1,0)
                    if (possibleMove.X == this.Position.X + 1 && possibleMove.Y == this.Position.Y)
                    {
                        IFigure figure = board.GetFigureOnPosition(possibleMove);

                        if (figure == null)
                        {
                            this.PossibleMoves.Add(possibleMove);
                        }
                        else
                        {
                            //No reason to check for (2,0) becasue there is a figure infront of the pawn
                            return;
                        }
                    }

                    //(2,0)
                    // 3 == 1 + 2. Blacks are on the top side
                    if (possibleMove.X == this.Position.X + 2)
                    {
                        IFigure figure = board.GetFigureOnPosition(possibleMove);

                        if (figure == null)
                        {
                            this.PossibleMoves.Add(possibleMove);
                        }
                    }
                }
            }
        }
    }
}
