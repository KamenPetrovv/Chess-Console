using Chess___Console.Classes.Interfaces;
using Chess___Console.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class Direction : IPosition
    {
        public Direction(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        private int x;
        public virtual int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (Utility.isInBounds( Math.Abs(value)))
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
        public virtual int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (Utility.isInBounds(Math.Abs(value)))
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
