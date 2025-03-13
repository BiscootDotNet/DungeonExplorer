﻿using System;
using System.Media;
using System.Xml.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public bool ItemPickedUp = false;

        public Game()
        {
            //player = new Player(name, 100);
            //currentRoom = new Room("Entrance Hall", "You are standing in a dimly lit hall.");

        }
        public void Start()
        {

            currentRoom = new Room("Stellar Basement", "You are standing in a dimly lit hall.");

            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("What is your name, explorer?");
            string Name = Console.ReadLine();
            player = new Player(Name, 100);


            bool playing = true;
            while (playing)
            {

                if (playing = true && ItemPickedUp == false)
                {
                    //Console.WriteLine("\nWelcome " + Name + ",");
                    Console.WriteLine(Name + ", You find yourself lonesome, awaking in a dungeon of sorts, with no sign of escape. This is the " + currentRoom.GetDescription());
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("\nQ. Showcase your player's stats.");
                    Console.WriteLine("1. Look around");
                    Console.WriteLine("2. Check " + Name + "'s inventory");
                    Console.WriteLine("3. Exit game");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            LookAround();
                            //Console.WriteLine("Input received: " + input);
                            break;
                        case "2":
                            SeeInventory();
                            //Console.WriteLine("Input received: " + input);
                            break;
                        case "3":
                            Console.WriteLine("You quit the game.");
                            //Console.WriteLine("Input received: " + input);
                            playing = false;
                            break;
                        case "Q":
                            SeeStats();
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
                else if (playing = true && ItemPickedUp == true)
                {
                    Console.WriteLine(Name + ", now with a form of weaponry in-hand, how would you like to proceed?");
                    Console.WriteLine("\nQ. Showcase your player's stats.");
                    Console.WriteLine("1. Further analyse the dungeon");
                    Console.WriteLine("2. Check " + Name + "'s inventory");
                    Console.WriteLine("3. Exit game");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("\nHaving collected the dagger, you turn your attention to the room.");
                            Console.WriteLine("The room is constructed with a simple cobblestone floor and gray brick walls, all poorly maintained.");
                            Console.WriteLine("Just ahead of where you located the dagger, you turn a corner, where stands a singular reinforced iron door leading only deeper underground.");
                            Console.WriteLine("\nHow will you proceed?");
                            Console.WriteLine("1. Examine the door");
                            Console.WriteLine("2. return to the room, maybe there's another clue somewhere.");
                            string input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "1":
                                    Console.WriteLine("\nYou approach the door, and find it to be firmly locked.");
                                    Console.WriteLine("You ominously overhear the faint sound of water dripping from the other side.");
                                    Console.WriteLine("\nThe very middle of the door featurs a keyhole, perhaps the dagger could force it open?");
                                    Console.WriteLine("1. Force it gently");
                                    Console.WriteLine("2. Force it with strength");
                                    Console.WriteLine("3. Return to the room");
                                    string input3 = Console.ReadLine();
                                    switch (input3)
                                    {
                                        case "1":
                                            DoorAccess();
                                            break;
                                        case "2":
                                            player.Health = player.Health - 20;
                                            Console.WriteLine("You force the dagger into the keyslot, damaging not only the door, but the dagger.");
                                            Console.WriteLine("irreparably damaged, the dagger is no longer usable, and you take -20 RECOIL dmg.");
                                            Console.WriteLine("\nYou now have " + player.Health + " health.");
                                            Console.WriteLine("\nHow will you continue?");
                                            Console.WriteLine("1. Return to the room");
                                            Console.WriteLine("2. Wait to starve");
                                            string input4 = Console.ReadLine();
                                            switch (input4)
                                            {
                                                case "1":
                                                    FurtherExplore();
                                                    break;
                                                case "2":
                                                    player.Health = player.Health - 80;
                                                    Console.WriteLine("\nYou await patiently whilst you starve in pain. At this point, even the cobblestone fills your appetite, though you remind yourself several times that stone is not edible.");
                                                    Console.WriteLine("You take -80 HUNGER dmg, finally succumbing to your arrogance.");
                                                    Console.WriteLine("Here ends the journey of " + player.Name);
                                                    Console.WriteLine("\nType any key to exit.");
                                                    string input5 = Console.ReadLine();
                                                    switch (input5)
                                                    {
                                                        default:
                                                            Environment.Exit(0);
                                                            break;
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid input.");
                                                    break;
                                            }

                                            break;
                                        case "3":
                                            FurtherExplore();
                                            break;
                                    }


                                    break;

                            }
                            break;


                            

                    }
                }
            }

        }

        public void LookAround()
        {
            Console.WriteLine("\nYou observe your surroundings. While there appears to be no exit, you spy a dagger that lays upon the cobblestone, approximately 30 metres ahead.");
            Console.WriteLine("The dagger appears to be the only item in the room, and you are unsure of its significance. It's important to think this through, anything could be a trap.");
            Console.WriteLine("\nHow would you like to proceed?");
            Console.WriteLine("1. Pick up the dagger");
            Console.WriteLine("2. Search the remainder of the room first");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ItemPickup();
                    break;
                case "2":
                    Console.WriteLine("\nYou stand and observe the remainder of your surroundings, finding little more than an eery cobblestone dungeon setting with a singular door leading deeper.");
                    Console.WriteLine("There's no apparent entrance, and you remain confused on how you wound up in such a setting.");
                    Console.WriteLine("After this closer search, would you now like to collect the dagger?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        case "1":
                            Console.WriteLine("After hesitating for a short while, you take the dagger and disregard your initial concern.");
                            Console.WriteLine("type anything to continue.");

                            string input3 = Console.ReadLine();
                            switch (input3)
                            {
                                default:
                                    ItemPickup();
                                    Console.WriteLine("You take the dagger, laying loose in your pocket.");
                                    break;
                            }
                            break;
                        case "2":
                            player.Health = player.Health - 30;
                            Console.WriteLine("\nYou leave the dagger to rest, and remain fearful of venturing further.");
                            Console.WriteLine("As time passes, you grow hungry.");
                            Console.WriteLine("With no food on your person, you take -30 HUNGER dmg.");
                            Console.WriteLine("You now have " + player.Health + " health.");
                            Console.WriteLine("\nContinue to leave the dagger?");
                            Console.WriteLine("1. Collect the dagger.");
                            Console.WriteLine("2. Continue to leave it.");
                            string input4 = Console.ReadLine();
                            switch (input4)
                            {
                                case "1":
                                    Console.WriteLine("\nStarved, you finally collect the dagger.");
                                    Console.WriteLine("You lack much energy to wield the weapon, and take an additional -10 HUNGER dmg");
                                    player.Health = player.Health - 10;
                                    ItemPickup();
                                    Console.Clear();
                                    break;
                                case "2":
                                    player.Health = player.Health - 70;
                                    Console.WriteLine("\nYou continue to leave the dagger, and with nowhere to go, you take -70 HUNGER dmg over time.");
                                    Console.WriteLine("Eventually, you gruelingly collapse from starvation, not a hero nor a legacy left behind.");
                                    Console.WriteLine("Here ends the journey of " + player.Name);
                                    Console.WriteLine("\nType any key to exit.");
                                    string input5 = Console.ReadLine();
                                    switch (input5)
                                    {
                                        default:
                                            Environment.Exit(0);
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid input.");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        public void SeeStats()
        {
            Console.WriteLine("\nPlayer Stats");
            Console.WriteLine("Name: " + player.Name);
            Console.WriteLine("Health: " + player.Health);
            Console.WriteLine("Inventory: " + player.InventoryContents());
            Console.WriteLine("Continue?");
            Console.WriteLine("Q. Yes");
            Console.WriteLine("E. Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Q":
                    Console.WriteLine("Resuming.");
                    Console.Clear();
                    break;
                case "E":
                    Console.WriteLine("You quit the game.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid input.");
                    break;
            }

        }

        public void SeeInventory()
        {
            Console.WriteLine("\nInventory");
            Console.WriteLine(player.InventoryContents());
            Console.WriteLine("Ready to continue?");
            Console.WriteLine("1. Yes");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Resuming.");
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("\nInvalid input.");
                    break;
            }
        }

        public void DoorAccess()
        {
            Console.WriteLine("\nWith careful adjustments to the dagger's edge within the keyhole, by some miracle, " + player.Name + " adjusts the lock mechanism perfectly, allowing the door to gradually swing open.");
            Console.WriteLine("You are met with a flight of cobblestone stairs, leading only to a dark and ominous atmosphere below, though a source of light and the sound of flowing water from the very bottom tempt you down.");
            Console.WriteLine("\nHow will you proceed?");
            Console.WriteLine("1. Descend the stairs");
            Console.WriteLine("2. Return to the room");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("You descend the stairs, and the door fleetingly closes behind you.");
                    Console.WriteLine("To be continued...");
                    Console.WriteLine("Type any key to exit.");
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        default:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                case "2":
                    FurtherExplore();
                    break;
            }
        }

        public void FurtherExplore()
        {
            Console.WriteLine("\nYou return to the room from which you entered, seeking any alternative from the iron door.");
            Console.WriteLine("Having analysed the setting for several minutes, one tiny detail catches your eye.");
            Console.WriteLine("Near to where you emerged is a small but noticable crack in the cobblestone, a crack which appears to hold something behind the wall.");
            Console.WriteLine("\nPress any key to disturb the crack with your dagger");
            string input = Console.ReadLine();
            switch (input)
            {
                default:
                    player.Health = player.Health - 90;
                    Console.WriteLine("\nYou disturb the crack with the dagger, and the entire wall crumbles.");
                    Console.WriteLine("Having not taken any precautions, you are caught directly underneath the falling rubble");
                    Console.WriteLine("You take -90 IMPACT dmg");
                    Console.WriteLine("You now have " + player.Health + " health.");
                    Console.WriteLine("\nEventually the lack of clean oxygen results in -10 SUFFOCATION dmg.");
                    Console.WriteLine("Here ends the journey of " + player.Name);
                    Console.WriteLine("\nType any key to exit.");
                    string input5 = Console.ReadLine();
                    switch (input5)
                    {
                        default:
                            Environment.Exit(0);
                            break;
                    }
                    break;

            }
        }


        public void ItemPickup()
        {
            player.PickUpItem("Dagger");
            ItemPickedUp = true;
            Console.WriteLine("\nYou collect the dagger, it sits loosely in your pocket.");
            Console.WriteLine("Would you like to check your inventory?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nInventory");
                    Console.WriteLine(player.InventoryContents());
                    Console.WriteLine("\nContinue?");
                    Console.WriteLine("1. Yes");
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        case "1":
                            Console.WriteLine("You continue.");
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("You continue.");
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

}