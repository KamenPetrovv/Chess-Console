using Chess___Console.Classes;
using Chess___Console.Classes.Figures;
using Chess___Console.Classes.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace Chess___Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Position> asd = new List<Position>() { new Position(2, 2) };

            Position q = new Position(2, 2);

            Console.WriteLine(asd.Contains(q));

            Board b = new Board();

            Move wMove = b.GetMoveFromConsole(false);

            b.Draw();
        }
    }
}
