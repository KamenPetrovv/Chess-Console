using Chess___Console.Classes.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class Board
    {
        public Board()
        {
            this.grid = new GridTile[8][];

            populateGridWithTiles();
            populateGridWithFigures();
        }

        private void populateGridWithFigures()
        {
            IFigure leftWhiteRook = new Rook(new Position(0, 0), true);
            grid[0][0].Figure = leftWhiteRook;

            IFigure rightWhiteRook = new Rook(new Position(0, 7), true);
            grid[0][7].Figure = rightWhiteRook;

            IFigure leftWhiteKnight = new Knight(new Position(0, 1), true);
            grid[0][1].Figure = leftWhiteKnight;

            IFigure rightWhiteKnight = new Knight(new Position(0, 6), true);
            grid[0][6].Figure = rightWhiteKnight;

            IFigure leftWhiteBishop = new Bishop(new Position(0, 2), true);
            grid[0][2].Figure = leftWhiteBishop;

            IFigure rightWhiteBishop = new Bishop(new Position(0, 5), true);
            grid[0][5].Figure = rightWhiteBishop;

            IFigure WhiteQueen = new Queen(new Position(0, 3), true);
            grid[0][3].Figure = WhiteQueen;

            IFigure WhiteKing = new King(new Position(0, 4), true);
            grid[0][4].Figure = WhiteKing;


            IFigure leftBlackRook = new Rook(new Position(7, 0), true);
            grid[7][0].Figure = leftBlackRook;

            IFigure rightBlackRook = new Rook(new Position(7, 7), true);
            grid[7][7].Figure = rightBlackRook;

            IFigure leftBlackKnight = new Knight(new Position(7, 1), true);
            grid[7][1].Figure = leftBlackKnight;

            IFigure rightBlackKnight = new Knight(new Position(7, 6), true);
            grid[7][6].Figure = leftBlackKnight;

            IFigure leftBlackBishop = new Bishop(new Position(7, 2), true);
            grid[7][2].Figure = leftBlackBishop;

            IFigure rightBlackBishop = new Bishop(new Position(7, 5), true);
            grid[7][5].Figure = rightBlackBishop;

            IFigure blackQueen = new Queen(new Position(7, 3), true);
            grid[7][3].Figure = blackQueen;

            IFigure blackKing = new King(new Position(7, 4), true);
            grid[7][4].Figure = blackKing;

            IFigure pawn;

            for (int i = 0; i < 8; i++)
            {
                pawn = new Pawn(new Position(1, i), true);
                grid[1][i].Figure = pawn;
            }

            for (int i = 0; i < 8; i++)
            {
                pawn = new Pawn(new Position(6, i), false);
                grid[6][i].Figure = pawn;
            }

        }

        private GridTile[][] grid;

        public void UpdateFigures()
        {

        }

        public bool isMovePossible(IFigure figure, Position position)
        {
            return true;
        }

        public void Draw()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (grid[i][j].Figure == null)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(grid[i][j].Figure.Symbol + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        private void populateGridWithTiles()
        {
            GridTile tempTile;
            for (int i = 0; i < 8; i++)
            {
                grid[i] = new GridTile[8];

                for (int j = 0; j < 8; j++)
                {

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            tempTile = new GridTile(null, true);
                        }
                        else
                        {
                            tempTile = new GridTile(null, false);
                        }
                        grid[i][j] = tempTile;
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            tempTile = new GridTile(null, false);
                        }
                        else
                        {
                            tempTile = new GridTile(null, true);
                        }
                        grid[i][j] = tempTile;
                    }
                }
            }
        }
    }
}
