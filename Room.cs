namespace MinotaurLabyrinth
{
    public class Room
    {
        public RoomType RoomType { get; private set; }

        public Room(RoomType roomType)
        {
            RoomType = roomType;
        }
    }
}
