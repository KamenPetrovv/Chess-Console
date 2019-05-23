using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class GridTile
    {
        public GridTile(IFigure figure, bool isWhiteTile)
        {
            this.Figure = figure;
            this.IsWhiteTile = isWhiteTile;
        }
        public IFigure Figure { get; set; }

        public bool IsWhiteTile { get; set; }
    }
}
