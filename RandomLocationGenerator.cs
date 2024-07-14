using System;

namespace MinotaurLabyrinth
{
    public static class RandomLocationGenerator
    {
        private static Random _random = new Random();

        public static (int row, int col) GenerateRandomEdgeLocation(int rows, int cols)
        {
            int row, col;
            int edge = _random.Next(4);

            switch (edge)
            {
                case 0: // Top edge
                    row = 0;
                    col = _random.Next(cols);
                    break;
                case 1: // Bottom edge
                    row = rows - 1;
                    col = _random.Next(cols);
                    break;
                case 2: // Left edge
                    row = _random.Next(rows);
                    col = 0;
                    break;
                default: // Right edge
                    row = _random.Next(rows);
                    col = cols - 1;
                    break;
            }

            return (row, col);
        }

        public static (int row, int col) GenerateRandomLocation(int rows, int cols, params (int row, int col)[] excludeLocations)
        {
            int row, col;

            do
            {
                row = _random.Next(rows);
                col = _random.Next(cols);
            }
            while (IsAdjacent(row, col, excludeLocations) || IsExcluded(row, col, excludeLocations));

            return (row, col);
        }

        private static bool IsAdjacent(int row, int col, (int row, int col)[] locations)
        {
            foreach (var location in locations)
            {
                if (Math.Abs(row - location.row) <= 1 && Math.Abs(col - location.col) <= 1)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsExcluded(int row, int col, (int row, int col)[] locations)
        {
            foreach (var location in locations)
            {
                if (row == location.row && col == location.col)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
