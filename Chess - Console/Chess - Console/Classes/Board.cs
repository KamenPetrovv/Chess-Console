using Chess___Console.Classes.Figures;
using Chess___Console.Classes.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chess___Console.Classes
{
    public class Board
    {
        public Board()
        {
            this.grid = new GridTile[8][];
            this.borderSymbols = GenerateBoarderSymbols();

            populateGridWithTiles();
            populateGridWithFigures();
        }

        private BorderSymbols GenerateBoarderSymbols()
        {
            JsonSerializer serializer = new JsonSerializer();
            BorderSymbols BorderSymbols = serializer.Deserialize<BorderSymbols>(new JsonTextReader(File.OpenText(@"..\..\..\Classes\Misc\BoardSymbols.json")));

            return BorderSymbols;
        }

        public void ExecuteMove(Move move)
        {
            GridTile fromGridTile = grid[move.FromPosition.X][move.FromPosition.Y];
            GridTile toGridTile = grid[move.ToPosition.X][move.ToPosition.Y];

            IFigure figure = grid[move.ToPosition.X][move.ToPosition.Y].Figure;

            if (figure != null)
            {
                figure.Kill();
                this.killedFigures.Add(figure);
                toGridTile = null;
            }

            toGridTile.Figure = fromGridTile.Figure;
            fromGridTile.Figure = null;
        }

        public bool ContainsFigure(string figureSymbol, bool isWhite)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bool symbolMatches = grid[i][j].Figure != null ? grid[i][j].Figure.Symbol == figureSymbol : false;
                    bool colorMatches = grid[i][j].Figure != null ? grid[i][j].Figure.IsWhite == isWhite : false;

                    if (symbolMatches && colorMatches)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private BorderSymbols borderSymbols { get; set; }
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


            IFigure leftBlackRook = new Rook(new Position(7, 0), false);
            grid[7][0].Figure = leftBlackRook;

            IFigure rightBlackRook = new Rook(new Position(7, 7), false);
            grid[7][7].Figure = rightBlackRook;

            IFigure leftBlackKnight = new Knight(new Position(7, 1), false);
            grid[7][1].Figure = leftBlackKnight;

            IFigure rightBlackKnight = new Knight(new Position(7, 6), false);
            grid[7][6].Figure = leftBlackKnight;

            IFigure leftBlackBishop = new Bishop(new Position(7, 2), false);
            grid[7][2].Figure = leftBlackBishop;

            IFigure rightBlackBishop = new Bishop(new Position(7, 5), false);
            grid[7][5].Figure = rightBlackBishop;

            IFigure blackQueen = new Queen(new Position(7, 3), false);
            grid[7][3].Figure = blackQueen;

            IFigure blackKing = new King(new Position(7, 4), false);
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

        private List<IFigure> killedFigures { get; set; }

        private GridTile[][] grid;

        public void UpdateFigures()
        {

        }

        public bool isMovePossible(Move move)
        {
            IFigure figure = grid[move.FromPosition.X][move.FromPosition.Y].Figure;

            if (figure.ContainsPossibleMove(move))
            {
                return true;
            }

            return false;
        }

        

        public void Draw()
        {
            Console.Clear();

            string emptyTileSymbol = " ";

            Console.WriteLine(GenerateTopBorder());

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(borderSymbols.VerticalSideWithoutLine);
                    }

                    if (grid[i][j].Figure == null)
                    {
                        Console.Write(" " + emptyTileSymbol + " ");
                    }
                    else
                    {
                        Console.Write(" " + grid[i][j].Figure.Symbol + " ");
                    }

                    if (j < 7)
                    {
                        Console.Write(borderSymbols.VerticalSideWithoutLine);
                    }

                    if (j == 7)
                    {
                        Console.WriteLine(borderSymbols.VerticalSideWithoutLine);
                    }
                }

                if (i < 7)
                {
                    Console.WriteLine(GenerateMiddleCrossLine());
                }
            }

            Console.WriteLine(GenerateBottomBorder());
        }

        private string GenerateMiddleBorder()
        {
            return (char)218 + new String((char)196, 6) + (char)191;
        }

        private string GenerateTopBorder()
        {
            string topBorder = "";

            topBorder += borderSymbols.TopLeftCorner;

            for (int i = 0; i < 7; i++)
            {
                topBorder += repeatString(borderSymbols.HorizontalSideWithoutLine, 3);
                topBorder += borderSymbols.HorizontalSideWithLineToTheBottom;
            }

            topBorder += repeatString(borderSymbols.HorizontalSideWithoutLine, 3);
            topBorder += borderSymbols.TopRightCorner;

            return topBorder;
        }

        private string GenerateBottomBorder()
        {
            string bottomBorder = "";

            bottomBorder += borderSymbols.BottomLeftCorver;

            for (int i = 0; i < 7; i++)
            {
                bottomBorder += repeatString(borderSymbols.HorizontalSideWithoutLine, 3);
                bottomBorder += borderSymbols.HorizontalSideWithLineToTheTop;
            }

            bottomBorder += repeatString(borderSymbols.HorizontalSideWithoutLine, 3);
            bottomBorder += borderSymbols.BottomRightCorver;

            return bottomBorder;
        }

        private string GenerateMiddleCrossLine()
        {
            string midLine = "";

            midLine += borderSymbols.VerticalSideWithLineTotheRight;

            for (int i = 0; i < 7; i++)
            {
                midLine += repeatString(borderSymbols.HorizontalSideWithoutLine, 3);
                midLine += borderSymbols.Cross;
            }

            midLine += repeatString(borderSymbols.HorizontalSideWithoutLine, 3);
            midLine += borderSymbols.VerticalSideWithLineToTheLeft;

            return midLine;
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

        public Move GetMoveFromConsole(bool isWhitesMove)
        {
            Console.Write("{0} move from: ", isWhitesMove ? "Whites" : "Blacks");

            Move move = new Move();

            move.ParseFrom(Console.ReadLine());
            Console.WriteLine();

            Console.Write("To: ");

            move.ParseTo(Console.ReadLine());
            Console.WriteLine();

            return move;
        }

        private string repeatString(string str, int numberOfRepeats)
        {
            string generatedString = "";

            for (int i = 0; i < numberOfRepeats; i++)
            {
                generatedString += str;
            }

            return generatedString;
        }
    }
}
