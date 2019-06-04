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
            Game game = new Game();

            game.Start();
        }
    }
}
