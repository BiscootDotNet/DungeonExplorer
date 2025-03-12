using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            player = new Player("Hero", 100);
            currentRoom = new Room("Entrance Hall", "You are standing in a dimly lit hall.");

        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Dungeon Explorer!");
                Console.WriteLine(currentRoom.GetDescription());


                if (playing == true)
                {
                    Console.WriteLine("\nYou stand in a hall, dimly lit and eery. This is the " + currentRoom.GetDescription());
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Move to another room");
                    Console.WriteLine("2. Pick up an item");
                    Console.WriteLine("3. Check inventory");
                    Console.WriteLine("4. Quit game");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("You moved to another room.");
                            break;
                        case "2":
                            Console.WriteLine("You picked up an item.");
                            break;
                        case "3":
                            Console.WriteLine("You checked your inventory.");
                            break;
                        case "4":
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
    }

}