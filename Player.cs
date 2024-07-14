using System;

namespace MinotaurLabyrinth
{
    public class Player
    {
        private int _row;
        private int _col;
        private Room[,] _labyrinth;

        public int Row => _row;
        public int Col => _col;

        public Player(Room[,] labyrinth, int startRow, int startCol)
        {
            _labyrinth = labyrinth;
            _row = startRow;
            _col = startCol;
        }

        public void Move(int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < _labyrinth.GetLength(0) && newCol >= 0 && newCol < _labyrinth.GetLength(1))
            {
                _row = newRow;
                _col = newCol;

                Room currentRoom = _labyrinth[_row, _col];
                if (currentRoom.RoomType == RoomType.Pit)
                {
                    Console.WriteLine("You fell into a pit and died!");
                    Environment.Exit(0);
                }

                SenseNearbyRooms();
            }
        }

        private void SenseNearbyRooms()
        {
            for (int row = _row - 1; row <= _row + 1; row++)
            {
                for (int col = _col - 1; col <= _col + 1; col++)
                {
                    if (row >= 0 && row < _labyrinth.GetLength(0) && col >= 0 && col < _labyrinth.GetLength(1))
                    {
                        Room room = _labyrinth[row, col];
                        if (room.RoomType == RoomType.Pit)
                        {
                            Console.WriteLine("You sense danger nearby!");
                        }
                    }
                }
            }
        }
    }
}
