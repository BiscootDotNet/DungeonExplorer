using System;
using System.Media;
using System.Xml.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            //player = new Player(name, 100);
            //currentRoom = new Room("Entrance Hall", "You are standing in a dimly lit hall.");

        }
        public void Start()
        {

            currentRoom = new Room("Stellar Basement", "You are standing in a dimly lit hall.");
            player.PickUpItem("Rugged Clothes");

            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("\nPress Q to showcase your player's stats in-game.");
            Console.WriteLine("What is your name, explorer?");
            string Name = Console.ReadLine();
            player = new Player(Name, 100);


            bool playing = true;
            while (playing)
            {
                //Console.Clear();

                if (playing == true)
                {
                    Console.WriteLine("\nWelcome " + Name + ",");
                    Console.WriteLine("You stand in a hall, dimly lit and eery. This is the " + currentRoom.GetDescription());
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Look Around");
                    Console.WriteLine("2. Pick up an item"); //check inv
                    Console.WriteLine("3. Quit game");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            LookAround();
                            //Console.WriteLine("Input received: " + input);
                            break;
                        case "2":
                            ItemPickup();
                            break;
                        case "3":
                            Console.WriteLine("You quit the game.");
                            playing = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
            }
        }

        public void LookAround()
        {
            Console.WriteLine("\nYou look around the room and see a door to the north.");
        }

        public void ItemPickup()
        {
            Console.WriteLine("\nYou picked up an item.");
            player.PickUpItem("Dagger");
        }
    }

}