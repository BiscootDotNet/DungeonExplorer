namespace DungeonExplorer
{
    public class Room
    {
        private string description;

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