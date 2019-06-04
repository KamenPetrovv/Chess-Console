using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes
{
    public class Move
    {
        public Move(Position fromPosition, Position toPosition)
        {
            this.FromPosition = fromPosition;
            this.ToPosition = toPosition;
        }

        public Move()
        {
            this.FromPosition = new Position();
            this.ToPosition = new Position();
        }
        public Position FromPosition { get; private set; }

        public Position ToPosition { get; private set; }

        //Input format "X,Y"
        public void ParseFrom(string input)
        {
            ParsePosition(input, this.FromPosition);
        }

        public void ParseTo(string input)
        {
            ParsePosition(input, this.ToPosition);
        }

        private void ParsePosition(string input, Position position)
        {
            string[] splitInput = input.Split(',');

            position.X = int.Parse(splitInput[0]);
            position.Y = int.Parse(splitInput[1]);
        }
    }
}
