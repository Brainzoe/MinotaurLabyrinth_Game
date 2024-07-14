using System;

namespace MinotaurLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the dimensions of the labyrinth
            int rows = 10;
            int cols = 10;

            // Create an instance of the LabyrinthCreator
            LabyrinthCreator labyrinthCreator = new LabyrinthCreator(rows, cols);

            // Create the labyrinth
            labyrinthCreator.CreateLabyrinth();

            // Retrieve the labyrinth
            Room[,] labyrinth = labyrinthCreator.GetLabyrinth();

            // Find the entrance location
            (int entranceRow, int entranceCol) = FindEntranceLocation(labyrinth);

            // Create the player at the entrance
            Player player = new Player(labyrinth, entranceRow, entranceCol);

            // Main game loop
            while (true)
            {
                Console.Clear();
                labyrinthCreator.DisplayLabyrinth(player);
                Console.WriteLine("Enter your move (WASD): ");
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input == null || input.Length != 1 || !"WASD".Contains(input))
                {
                    Console.WriteLine("Invalid input. Use W, A, S, or D to move.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                int newRow = player.Row;
                int newCol = player.Col;

                switch (input)
                {
                    case "W":
                        newRow -= 1;
                        break;
                    case "A":
                        newCol -= 1;
                        break;
                    case "S":
                        newRow += 1;
                        break;
                    case "D":
                        newCol += 1;
                        break;
                }

                // Move the player
                player.Move(newRow, newCol);
            }
        }

        private static (int, int) FindEntranceLocation(Room[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col].RoomType == RoomType.Entrance)
                    {
                        return (row, col);
                    }
                }
            }

            throw new InvalidOperationException("Entrance not found in the labyrinth.");
        }
    }
}
