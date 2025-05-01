namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        static public Room RightMonsterRoom { get; set; }
        static public Room LeftStorageRoom { get; set; }
        static public Room BossRoom { get; set; }
        static public Room currentRoom { get; set; }

        public Room(string description, string v)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
    }

}