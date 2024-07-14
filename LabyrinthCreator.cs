using System;

namespace MinotaurLabyrinth
{
    public class LabyrinthCreator
    {
        private Room[,] _labyrinth;
        private int _rows;
        private int _cols;
        private int _pitCount = 3; // Number of pits to be placed in the labyrinth

        public LabyrinthCreator(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _labyrinth = new Room[rows, cols];
        }

        public void CreateLabyrinth()
        {
            InitializeEmptyLabyrinth();

            // Randomize the entrance location
            var entranceLocation = RandomLocationGenerator.GenerateRandomEdgeLocation(_rows, _cols);
            _labyrinth[entranceLocation.row, entranceLocation.col] = new Room(RoomType.Entrance);

            // Randomize the sword location
            var swordLocation = RandomLocationGenerator.GenerateRandomLocation(_rows, _cols, entranceLocation);
            _labyrinth[swordLocation.row, swordLocation.col] = new Room(RoomType.Sword);

            // Randomize pit locations
            for (int i = 0; i < _pitCount; i++)
            {
                var pitLocation = RandomLocationGenerator.GenerateRandomLocation(_rows, _cols, entranceLocation, swordLocation);
                _labyrinth[pitLocation.row, pitLocation.col] = new Room(RoomType.Pit);
            }
        }

        public Room[,] GetLabyrinth()
        {
            return _labyrinth;
        }

        private void InitializeEmptyLabyrinth()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    _labyrinth[row, col] = new Room(RoomType.Empty);
                }
            }
        }

        public void DisplayLabyrinth(Player player)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    if (row == player.Row && col == player.Col)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        switch (_labyrinth[row, col].RoomType)
                        {
                            case RoomType.Empty:
                                Console.Write(". ");
                                break;
                            case RoomType.Entrance:
                                Console.Write("E ");
                                break;
                            case RoomType.Sword:
                                Console.Write("S ");
                                break;
                            case RoomType.Pit:
                                Console.Write("P ");
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
