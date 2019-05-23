using Chess___Console.Classes.Interfaces;
using Chess___Console.Classes.Static_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class Position : Direction
    {
        public Position(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        private int x;
        public override int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (Utility.isInBounds(value))
                {
                    this.x = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid X coordiate value");
                }
            }
        }

        private int y;
        public override int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (Utility.isInBounds(value))
                {
                    this.y = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid Y coordiate value");
                }
            }
        }
    }
}
