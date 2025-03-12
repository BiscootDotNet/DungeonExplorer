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
                    Console.WriteLine("You find yourself lonesome, awaking in a dungeon of sorts, with no sign of escape. This is the " + currentRoom.GetDescription());
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Look Around");
                    Console.WriteLine("2. Check " + Name + "'s Inventory");
                    Console.WriteLine("3. Exit game");
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
            Console.WriteLine("\nYou observe your surroundings. While there appears to be no exit, you spy a dagger approximately 30 metres ahead");
            Console.WriteLine("How would you like to proceed?");
            Console.WriteLine("1. Pick up the dagger");
            Console.WriteLine("2. Search elsewhere");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ItemPickup();
                    break;
                case "2":
                    Console.WriteLine("You decide to search elsewhere.");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        public void ItemPickup()
        {
            Console.WriteLine("\nInventory");
            Console.WriteLine(player.InventoryContents());
            player.PickUpItem("Dagger");
        }
    }

}