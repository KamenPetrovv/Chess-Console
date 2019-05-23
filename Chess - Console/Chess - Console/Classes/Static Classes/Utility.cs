using System;
using System.Collections.Generic;
using System.Text;

namespace Chess___Console.Classes.Static_Classes
{
    public static class Utility
    {
        public static bool isInBounds(Position position)
        {
            if (isInBounds(position.X) && isInBounds(position.Y))
            {
                return true;
            }

            return false;
        }

        public static bool isInBounds(int number)
        {
            if (0 <= number && number <= 7)
            {
                return true;
            }

            return false;
        }

        public static List<Direction> GenerateDiagonalDirections()
        {
            List<Direction> diagonalDirections = new List<Direction>();

            for (int i = 1; i <= 7; i++)
            {
                Direction tempDirection = new Direction(i, i);
                diagonalDirections.Add(tempDirection);

                tempDirection = new Direction(-i, -i);
                diagonalDirections.Add(tempDirection);

                tempDirection = new Direction(i, -i);
                diagonalDirections.Add(tempDirection);

                tempDirection = new Direction(-i, i);
                diagonalDirections.Add(tempDirection);
            }

            return diagonalDirections;
        }

        public static List<Direction> GenerateHorizontalAndVerticalDirections()
        {
            List<Direction> horizontalAndVerticalDirections = new List<Direction>();

            for (int i = 1; i <= 7; i++)
            {
                Direction tempDirection = new Direction(0, i);
                horizontalAndVerticalDirections.Add(tempDirection);

                tempDirection = new Direction(0, -i);
                horizontalAndVerticalDirections.Add(tempDirection);

                tempDirection = new Direction(i, 0);
                horizontalAndVerticalDirections.Add(tempDirection);

                tempDirection = new Direction(-i, 0);
                horizontalAndVerticalDirections.Add(tempDirection);
            }

            return horizontalAndVerticalDirections;
        }

        public static List<Direction> GeneratePawnDirections(bool isWhite)
        {
            List<Direction> pawnDirections = new List<Direction>();

            //Whites play on the bottom side
            if (isWhite)
            {
                Direction up = new Direction(-1, 0);
                Direction doubleUp = new Direction(-2, 0);
                Direction takeLeft = new Direction(-1, -1);
                Direction takeRight = new Direction(-1, 1);

                pawnDirections.Add(up);
                pawnDirections.Add(doubleUp);
                pawnDirections.Add(takeLeft);
                pawnDirections.Add(takeRight);
            }
            else
            {
                Direction down = new Direction(1, 0);
                Direction doubleDown = new Direction(2, 0);
                Direction takeLeft = new Direction(1, -1);
                Direction takeRight = new Direction(1, 1);

                pawnDirections.Add(down);
                pawnDirections.Add(doubleDown);
                pawnDirections.Add(takeLeft);
                pawnDirections.Add(takeRight);
            }

            return pawnDirections;
        }

        public static List<Direction> GenerateKnightDirections()
        {
            List<Direction> knightDirections = new List<Direction>();

            Direction temp = new Direction(-2, 1);
            knightDirections.Add(temp);

            temp = new Direction(-1, 2);
            knightDirections.Add(temp);

            temp = new Direction(1, 2);
            knightDirections.Add(temp);

            temp = new Direction(2, 1);
            knightDirections.Add(temp);

            temp = new Direction(2, -1);
            knightDirections.Add(temp);

            temp = new Direction(1, -2);
            knightDirections.Add(temp);

            temp = new Direction(-1, -2);
            knightDirections.Add(temp);

            temp = new Direction(-2, -1);
            knightDirections.Add(temp);

            return knightDirections;
        }

        public static List<Direction> GenerateKingDirections()
        {
            List<Direction> knightDirections = new List<Direction>();

            Direction temp;

            temp = new Direction(1, 0);
            knightDirections.Add(temp);

            temp = new Direction(-1, 0);
            knightDirections.Add(temp);

            temp = new Direction(0, 1);
            knightDirections.Add(temp);

            temp = new Direction(0, -1);
            knightDirections.Add(temp);

            temp = new Direction(1, 1);
            knightDirections.Add(temp);

            temp = new Direction(1, -1);
            knightDirections.Add(temp);

            temp = new Direction(-1, 1);
            knightDirections.Add(temp);

            temp = new Direction(-1, -1);
            knightDirections.Add(temp);

            return knightDirections;
        }
    }

}
