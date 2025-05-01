using System;
using System.CodeDom;
using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DungeonExplorer
{
    //main game class, which is responsible for adding the game and room logic.
    internal class Game  //the game class, which is responsible for the game's logic.
    {
        private Player player;  //stores the player object information.
        private Room currentRoom;  //tracks the player's current room.
        private Monsters monster;  //stores the monster object information.
        public bool CurrentMonsterBoss = false;  //tracks if the current monster is a boss.
        public bool ItemPickedUp = false;  //tracks if the player has collected the item. True when collected, false when not.
        public bool StorageRoomAccessed = false;  //tracks if the player has accessed the storage room.
        public bool SwordGot = false;  //tracks if the player has collected the sword.
        public bool SwordEquipped = false;  //tracks if the player has equipped the sword.
        public bool BossRoom = false;  //tracks if the player has accessed the boss room.
        public bool HasEnraged = false;  //tracks if the boss has enraged.

        public Game()
        {
            //player and room objects would be created here.
        }

        //starts the game and handles the flow.
        public void Start()
        {

            currentRoom = new Room("UNSETTLED BASEMENT", "You awake lying in a dimly lit cobble room.");

            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine("What is your name, explorer?");
            string Name = Console.ReadLine();
            player = new Player(Name, 105, 5, 0, 5);  //initializes the player object with the player's inputted name and health.


            bool playing = true;  //boolean variable to control the game loop.
            while (playing)  //while loop to keep the game running until the player quits.
            {

                if (playing = true && ItemPickedUp == false)  //this is the main gameplay loop, plays when the game is initialised and the player has not yet collected the item.
                {
                    Console.WriteLine("\n" + Name + ", You find yourself lonesome, awaking in a dungeon of sorts, with no sign of escape. This is " + currentRoom.GetDescription());
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("\nQ. Showcase your player's stats.");
                    Console.WriteLine("1. Look around");
                    Console.WriteLine("2. Check " + Name + "'s inventory");  //the string 'Name' is called on this writeline code to display the player's custom name when playing.
                    Console.WriteLine("3. Exit game");
                    string input = Console.ReadLine();  //here the console reads the player's input, and the switch case below handles the input accordingly.
                    switch (input)  //a switch case, which handles the player's input and corresponding actions.
                    {
                        case "1":  //the player's choice to 'look around' the room.
                            LookAround();
                            //Console.WriteLine("Input received: " + input);  //a simple debugging line to check the input received.
                            break;
                        case "2":  //the player's choice to check their inventory.
                            SeeInventory();
                            //Console.WriteLine("Input received: " + input);  //a simple debugging line to check the input received.
                            break;
                        case "3":  //the player's choice to exit the game.
                            Console.WriteLine("You quit the game.");
                            //Console.WriteLine("Input received: " + input);  //a simple debugging line to check the input received.
                            playing = false;
                            break;
                        case "Q":  //the player's choice to showcase their stats.
                            SeeStats();
                            break;
                        default:  //handles the player's invalid input.
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
                else if (playing = true && ItemPickedUp == true)  //the gameplay loop to run for when the player has collected the item, indicated by the boolean being true.
                {
                    Console.WriteLine(Name + ", now with a form of weaponry in-hand, how would you like to proceed?");
                    Console.WriteLine("\nQ. Showcase your player's stats."); // The console types out the lines stated here which give the player their options to proceed
                    Console.WriteLine("1. Further analyse the dungeon");
                    Console.WriteLine("2. Check " + Name + "'s inventory");
                    Console.WriteLine("3. Exit game");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":  //the player's choice to further explore the dungeon.
                            Console.WriteLine("\nHaving collected the DAGGER, you turn your attention to the room."); //a \n is used to create a new line in the console.
                            Console.WriteLine("The room is constructed with a simple cobblestone floor and gray brick walls, all poorly maintained.");
                            Console.WriteLine("Just ahead of where you located the DAGGER, you turn a corner, where stands a singular reinforced iron door leading only deeper underground.");
                            Console.WriteLine("\nHow will you proceed?");
                            Console.WriteLine("1. Examine the door");
                            Console.WriteLine("2. return to the room, maybe there's another clue somewhere.");
                            string input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "1":  //the player's choice to examine the door
                                    Console.WriteLine("\nYou approach the door, and find it to be firmly locked.");
                                    Console.WriteLine("You ominously overhear the faint sound of water dripping from the other side.");
                                    Console.WriteLine("\nThe very middle of the door featurs a keyhole, perhaps the DAGGER could force it open?");
                                    Console.WriteLine("1. Force it gently");
                                    Console.WriteLine("2. Force it with strength");
                                    Console.WriteLine("3. Return to the room");
                                    string input3 = Console.ReadLine();
                                    switch (input3)
                                    {
                                        case "1": //calls the function to respond to the player's choice to force the door gently.
                                            DoorAccess();
                                            break;
                                        case "2": //responds to the player's choice to force the door with strength.
                                            player.Health = player.Health - 20;  //function which reduces the player's health by a value of 20 from 100
                                            Console.WriteLine("You force the DAGGER into the keyslot, damaging not only the door, but the DAGGER.");
                                            Console.WriteLine("irreparably damaged, the DAGGER is no longer usable, and you take -20 RECOIL dmg.");
                                            Console.WriteLine("\nYou now have " + player.Health + " health.");
                                            Console.WriteLine("\nHow will you continue?");
                                            Console.WriteLine("1. Return to the room");
                                            Console.WriteLine("2. Wait to starve");
                                            string input4 = Console.ReadLine();
                                            switch (input4)
                                            {
                                                case "1": //calls the function to return to the room.
                                                    FurtherExplore();  //this case calls the FurtherExplore function, which handles the choice of the player's progression.
                                                    break;
                                                case "2": //handles the player's choice to wait and starve.
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
                                                default: //default handles the player's invalid input.
                                                    Console.WriteLine("Invalid input.");
                                                    break;
                                            }

                                            break;
                                        case "3": //calls the function to handle the player's choice to return to the room.
                                            FurtherExplore();
                                            break;
                                    }


                                    break;
                                case "2":  //handles the player's choice to return to the room.
                                    FurtherExplore();
                                    break;

                            }
                            break;
                        case "2":
                            SeeInventory();
                            break;
                        case "3":
                            Console.WriteLine("You quit the game.");
                            playing = false;
                            break;
                        case "Q":
                            SeeStats();
                            break;




                    }
                }
            }

        }

        public void LookAround()  //a function which handles the player's choice to 'look around' the room, hence the function name.
        {
            Console.WriteLine("\nYou observe your surroundings. While there appears to be no exit, you spy a DAGGER that lays upon the cobblestone, approximately 30 metres ahead.");
            Console.WriteLine("The DAGGER appears to be the only item in the room, and you are unsure of its significance. It's important to think this through, anything could be a trap.");
            Console.WriteLine("\nHow would you like to proceed?");
            Console.WriteLine("1. Pick up the DAGGER");
            Console.WriteLine("2. Search the remainder of the room first");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":  //calls the function to handle the player's choice to pick up the item.
                    ItemPickup();
                    break;
                case "2":  //handles the player's choice to search the remainder of the room.
                    Console.WriteLine("\nYou stand and observe the remainder of your surroundings, finding little more than an eery cobblestone dungeon setting with a singular door leading deeper.");
                    Console.WriteLine("There's no apparent entrance, and you remain confused on how you wound up in such a setting.");
                    Console.WriteLine("\nAfter this closer search, would you now like to collect the DAGGER?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        case "1":  //calls the function to handle the player's choice to pick up the item.
                            Console.WriteLine("After hesitating for a short while, you take the DAGGER and disregard your initial concern.");
                            Console.WriteLine("type anything to continue.");

                            string input3 = Console.ReadLine();
                            switch (input3)
                            {
                                default:
                                    ItemPickup();
                                    Console.WriteLine("You take the DAGGER, laying loose in your pocket.");
                                    break;
                            }
                            break;
                        case "2":  //handles the player's choice to not pick up the item.
                            player.Health = player.Health - 30;
                            Console.WriteLine("\nYou leave the DAGGER to rest, and remain fearful of venturing further.");
                            Console.WriteLine("As time passes, you grow hungry.");
                            Console.WriteLine("With no food on your person, you take -30 HUNGER dmg.");
                            Console.WriteLine("You now have " + player.Health + " health.");
                            Console.WriteLine("\nContinue to leave the DAGGER?");
                            Console.WriteLine("1. Collect the DAGGER.");
                            Console.WriteLine("2. Continue to leave it.");
                            string input4 = Console.ReadLine();
                            switch (input4)
                            {
                                case "1":  //calls the function to handle the player's choice to pick up the item.
                                    Console.WriteLine("\nStarved, you finally collect the DAGGER.");
                                    Console.WriteLine("You lack much energy to wield the weapon, and take an additional -10 HUNGER dmg");
                                    player.Health = player.Health - 10;
                                    ItemPickup();
                                    Console.Clear();
                                    break;
                                case "2":  //handles the player's choice to not pick up the item and starve.
                                    player.Health = player.Health - 70;
                                    Console.WriteLine("\nYou continue to leave the DAGGER, and with nowhere to go, you take -70 HUNGER dmg over time.");
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

        public void SeeStats()  //a function which calls the player's stats and displays them to the console.
        {
            Console.WriteLine("\nPlayer Stats");
            Console.WriteLine("Name: " + player.Name);
            Console.WriteLine("Health: " + player.Health);
            Console.WriteLine("Inventory: " + player.InventoryContents());
            Console.WriteLine("\nType any key to continue.");
            string input = Console.ReadLine();
            switch (input)
            {
                default:
                    Console.WriteLine("Resuming.");
                    Console.Clear();
                    break;
            }

        }

        public void SeeInventory()  //a simple function which displays the player's inventory to the console.
        {
            Console.WriteLine("\nInventory");
            Console.WriteLine(player.InventoryContents());
            Console.WriteLine("\nPress any key to continue");
            string input = Console.ReadLine();
            switch (input)
            {
                default:  //handles the player's choice to continue from typing any key.
                    Console.WriteLine("Resuming.");
                    Console.Clear();
                    break;
            }
        }

        public void DoorAccess()  //a function which handles the player's choice to access the door.
        {
            Console.WriteLine("\nWith careful adjustments to the DAGGER's edge within the keyhole, by some miracle, " + player.Name + " adjusts the lock mechanism perfectly, allowing the door to gradually swing open.");
            Console.WriteLine("You are met with a flight of cobblestone stairs, leading only to a dark and ominous atmosphere below, though a source of light and the sound of echoes from below tempt you down.");
            Console.WriteLine("\nHow will you proceed?");
            Console.WriteLine("1. Descend the stairs");
            Console.WriteLine("2. Return to the room");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":  //handles the player's choice to descend the stairs.
                    RoomChoice();
                    break;
                case "2":  //handles the player's choice to return to the room.
                    FurtherExplore();
                    break;
            }
        }

        public void FurtherExplore()  //a function which handles the player's choice to further explore.
        {
            Console.WriteLine("\nYou return to the room from which you entered, seeking any alternative from the iron door.");
            Console.WriteLine("Having analysed the setting for several minutes, one tiny detail catches your eye.");
            Console.WriteLine("Near to where you emerged is a small but noticable crack in the cobblestone, a crack which appears to hold something behind the wall.");
            Console.WriteLine("\nPress any key to disturb the crack with your DAGGER");
            string input = Console.ReadLine();
            switch (input)
            {
                default:  //handles the player's choice to disturb the crack with the DAGGER.
                    player.Health = player.Health - 90;
                    Console.WriteLine("\nYou disturb the crack with the DAGGER, and the entire wall crumbles.");
                    Console.WriteLine("Having not taken any precautions, you are caught directly underneath the falling rubble");
                    Console.WriteLine("You take -90 IMPACT dmg");
                    Console.WriteLine("You now have " + player.Health + " health.");
                    Console.WriteLine("\nEventually the lack of clean oxygen results in -10 SUFFOCATION dmg.");
                    Console.WriteLine("Here ends the journey of " + player.Name);
                    Console.WriteLine("\nType any key to exit.");
                    string input5 = Console.ReadLine();
                    switch (input5)
                    {
                        default:  //handles the player's death and exits the game.
                            Environment.Exit(0);
                            break;
                    }
                    break;

            }
        }

        public void RoomChoice()  //a function which handles the player's choice to enter a room.
        {
            Console.Clear();
            Console.WriteLine("You descend the stairs, and the door fleetingly closes behind you.");
            Console.WriteLine("The bottom of the cobble stairs leaves you faced with a split corridor." + "\nWould you like to proceed LEFT or RIGHT?");
            Console.WriteLine("\n(Testing note - I strongly advise taking the left path first)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "RIGHT":  //handles the player's choice to enter the left room.
                    MonsterRoom();
                    break;
                case "LEFT":  //handles the player's choice to enter the right room.
                    StorageRoom();
                    break;
                default:  //handles the player's invalid input.
                    Console.WriteLine("\nInvalid Direction.");
                    RoomChoice();
                    break;
            }
        }
        
        public void StorageRoom() //a function which handles the player's choice to enter the storage room.
        {
            if (StorageRoomAccessed == false)  //if the player has not yet accessed the storage room, this code will run.
            {
                Console.Clear();
                StorageRoomAccessed = true;  //sets the boolean to true, indicating the player has accessed the storage room.
                Room.LeftStorageRoom = new Room("STORAGE ROOM", "You are standing in a dimly lit storage room, with a few crates and chests scattered around.");
                currentRoom = Room.LeftStorageRoom;  //sets the current room to the storage room.
                Console.WriteLine("You enter the storage room, and are met with a handful of crates and chests.");
                Console.WriteLine("Many of the crates are poorly maintained, with only a chest or two in the room's centre catching your attention.");
                Console.WriteLine("You approach the chest, and find it to be locked.");
                Console.WriteLine("Would you like to search the chest to the right, or force it open with your DAGGER?");
                Console.WriteLine("1. Search the next chest");
                Console.WriteLine("2. Force it open with your DAGGER");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\nYou search the next chest, and take 2x SML Health Potion as well as an additonal DAGGER.");
                        Console.WriteLine("2x SML Health Potion added to your inventory.");
                        Console.WriteLine("DAGGER added to your inventory.");
                        player.PickUpItem("SML Health Potion");
                        player.PickUpItem("SML Health Potion");
                        player.PickUpItem("DAGGER");
                        Console.WriteLine("\nWould you like to see your inventory before returning to the corridor?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            case "1":  //calls the function to display the player's inventory.
                                SeeInventory();
                                RoomChoice();
                                break;
                            case "2":  //handles the player's choice to not check their inventory.
                                Console.WriteLine("You continue.");
                                RoomChoice();
                                break;
                        }
                        break;
                    case "2":
                        SwordGot = true;  //sets the boolean to true.
                        Console.WriteLine("\nYou break the lock with your DAGGER, breaking your DAGGER in the process.");
                        player.RemoveItem("DAGGER");
                        Console.WriteLine("Inside, however, lies a SHARP BLADE, which you take as its successor, as well as 1x LRG Health Potion");
                        Console.WriteLine("This blade feels as though it will be strong at COUNTERING surprise or follow-up attacks.");
                        Console.WriteLine("(\nThe SHARP BLADE can counter follow-up attacks from the boss, and will also apply BLEED to enemies, dealing additional DMG.)");
                        Console.WriteLine("\nSHARP BLADE added to your inventory.");
                        Console.WriteLine("1x LRG Health Potion added to your inventory.");
                        player.PickUpItem("SHARP BLADE");
                        player.PickUpItem("LRG Health Potion");
                        Console.WriteLine("You also search the chest to the right and gain 2x SML Health Potion");
                        Console.WriteLine("1x SML Health Potion added to your inventory.");
                        player.PickUpItem("SML Health Potion");
                        player.PickUpItem("SML Health Potion");
                        Console.WriteLine("\nWould you like to see your inventory before returning to the corridor?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        string input3 = Console.ReadLine();
                        switch (input3)
                        {
                            case "1":  //calls the function to display the player's inventory.
                                SeeInventory();
                                RoomChoice();
                                break;
                            case "2":  //handles the player's choice to not check their inventory.
                                Console.WriteLine("You continue.");
                                RoomChoice();
                                break;
                        }
                        break;
                }


            }
            else if (StorageRoomAccessed == true)  //if the player has already accessed the storage room, this code will run.
            {
                Console.WriteLine("\nYou have already accessed the storage room, and decide to move on.");
                Console.WriteLine("Type any key to continue.");
                string input = Console.ReadLine();
                switch (input)
                {
                    default:
                        RoomChoice();
                        break;
                }

            }

        }

        public void MonsterRoom()  //a function which handles the player's choice to enter the monster room.
        {
            Console.Clear();
            Monsters.MontsroGhoul = new Monsters("MONSTRO GHOUL", 75, 8, 1, 0);  //sets the monster to the MONSTRO GHOUL.
            monster = Monsters.MontsroGhoul;  //sets the monster to the MONSTRO GHOUL.
            Room.RightMonsterRoom = new Room("MONSTER ROOM", "You now stand in a dimly lit stone room, with a large monster limping by the back wall.");
            currentRoom = Room.RightMonsterRoom;  //sets the current room to the monster room.
            Console.WriteLine("Taking the right exit leads you to a poorly lit stone hall, filled by several empty bookcases.");
            Console.WriteLine("Though through the smoggy darkness you notice an approaching figure.");
            Console.WriteLine("You should ready yourself for a COMBAT ENCOUNTER.");
            Console.WriteLine("\nPress any key to continue.");
            string input = Console.ReadLine();
            switch (input)
            {
                default:
                    CombatEncounter();
                    break;
            }
        }

        public void CombatEncounter()  //a function which handles the player's encounter with a monster.
        {
            Console.Clear();
            Console.WriteLine(monster.Name + " appears!");
            player.AttackPower = player.AttackPower - monster.Defence;  //reduces the player's attack power by the monster's defence.

            while (player.Health  > 0 && monster.Health > 0)  //while loop to keep the combat encounter running until either the player or monster is dead.
            {
                Console.WriteLine("\nYour health: " + player.Health);
                Console.WriteLine(monster.Name + "'s health: " + monster.Health);
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Attack   2. Equip item   3. Use a potion   4. Flee.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":  //the player's choice to attack the monster.
                        monster.TakeDamage(player.AttackPower);
                        monster.Attack(player);
                        break;
                    case "2":  //the player's choice to use an item.
                        EquipItem();
                        break;
                    case "3":  //the player's choice to view their inventory.
                        UsePotion();
                        monster.Attack(player);
                        break;
                    case "4":  //the player's choice to flee.
                        Console.WriteLine("\nThere is nowhere to flee.");
                        Console.WriteLine("Press any key to return to combat.");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            default:
                                CombatEncounter();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid input.");
                        CombatEncounter();
                        break;
                }
                if (player.Health <= 0)
                {
                    Console.WriteLine("\nYou have been defeated by " + monster.Name + ".");
                    Console.WriteLine("Here ends the journey of " + player.Name);
                    Console.WriteLine("\nType any key to exit.");
                    Environment.Exit(0);
                }
                else if (monster.Health <= 0)
                {
                    Console.WriteLine("\nYou have defeated " + monster.Name + "!");
                    Console.WriteLine("you regain 15 health from a sigh of relief.");
                    player.Health = player.Health + 15;
                    //monster = null;  //sets the monster to null, indicating it has been defeated.
                    if (monster.Health <=0 && CurrentMonsterBoss)
                    {
                        Console.WriteLine("\nWith the boss now slain, its allies too dissipate into the cobble ground.");
                        Console.WriteLine("An array of golden loot scattered around the arena room, as though a reward.");
                        Console.WriteLine("And as a ladder appears from above gleaming with sunlight..");
                        Console.WriteLine("Here ends the journey of " + player.Name + ", victorious.");
                        Console.WriteLine("Thank you for playing!");
                        Console.WriteLine("\nType any key to exit.");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            default:
                                Environment.Exit(0);
                                break;
                        }
                    }


                    if (Room.currentRoom != Room.RightMonsterRoom)
                    {
                        Console.WriteLine("\nThe MONSTRO GHOUL dissipates into the ground, leaving a STURDY HELMET behind");
                        Console.WriteLine("You pick up the STURDY HELMET.");
                        Console.WriteLine(player.Name + " gained +3 DEF");
                        player.Defence = player.Defence + 3;
                        Console.WriteLine("With the enemy now disregarded, and the helmet collected, a distant spiritual voice whispers through the walls of the room");
                        Console.WriteLine("Near where the enemy first stood now appears a doorway of sorts, and with no exit elsewhere, it only seems logical to proceed");
                        Console.WriteLine("Type any key to continue.");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            default:
                                BossRoom = true;
                                InBossRoom();

                                break;
                        }
                    }

                }
                if (CurrentMonsterBoss && monster.Health <= 60 && !HasEnraged)
                {
                    HasEnraged = true;
                    Console.WriteLine("\n" + monster.Name + " is enraged. ATK & DEF ARE increased!.");
                    Console.WriteLine(monster.Name + " launches an additional follow-up attack!");
                    Monsters.WolflordGhoul.Attackpower = 15;
                    Monsters.WolflordGhoul.Defence = 9;
                    monster.FUAattackPlayer(player);
                    if (SwordEquipped == true)
                    {
                        Console.WriteLine("\nWith the blade equipped, you successfully counter " + monster.Name + "'s follow-up ATK, mitigating some DMG!");
                        player.Health = player.Health + 6;
                        player.PlayerCounter(monster);
                    }
                }
                else if (CurrentMonsterBoss && monster.Health <= 60 && HasEnraged)
                {
                    Console.WriteLine("\n" + monster.Name + " is enraged. ATK, DEF & HP is increased!.");
                    //Console.WriteLine("should only show after enrage " + monster.Defence);
                    monster.FUAattackPlayer(player);
                    if (SwordEquipped == true)
                    {
                        Console.WriteLine("\nWith the blade equipped, you successfully counter " + monster.Name + "'s follow-up ATK, mitigating some DMG!");
                        player.Health = player.Health + 5;
                        player.PlayerCounter(monster);
                    }
                }
            }

        }

        public void EquipItem()  //a function which handles the player's choice to equip an item.
        {
            Console.WriteLine("\n");
            Console.WriteLine(player.InventoryContents());
            Console.WriteLine("Which weapon would you like to equip?");
            string item = Console.ReadLine();
            switch (item)
            {
                case "DAGGER":
                    if (SwordGot == true)
                    {
                        Console.WriteLine("\nYou cannot equip your broken DAGGER, though you do have the SHARP BLADE.");
                        EquipItem();
                        break;
                    }
                    else if (SwordGot == false)
                    {
                        SwordEquipped = false;  //sets the boolean to false, indicating the player has not equipped the sword.
                        Console.WriteLine("\nYou equip your dual DAGGERs");
                        player.AttackPower = 12;
                        Console.WriteLine("Press any key to continue.");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            default:
                                CombatEncounter();
                                break;
                        }
                        break;
                    }
                    break;
                case "SHARP BLADE":
                    if (SwordGot == false)
                    {
                        Console.WriteLine("\nNo such item is found in your inventory.");
                        EquipItem();
                        break;
                    }
                    else if (SwordGot == true)
                    {
                        Console.WriteLine("\nYou equip the SHARP BLADE");
                        player.AttackPower = 19;
                        monster.Health = monster.Health - 2;
                        Console.WriteLine("Press any key to continue.");
                        SwordEquipped = true;
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            default:
                                CombatEncounter();
                                break;
                        }
                        break;
                    }
                    break;

                case "CROSSBOW":
                    SwordEquipped = false;
                    Console.WriteLine("\nYou equip the CROSSBOW");
                    player.AttackPower = 20;
                    monster.Defence = monster.Defence - 3;
                    Console.WriteLine("Press any key to continue.");
                    string input3 = Console.ReadLine();
                    switch (input3)
                    {
                        default:
                            CombatEncounter();
                            break;
                    }
                    break;

                default:
                    {
                        Console.WriteLine("\nNo such item is found in your inventory.");
                        EquipItem();
                        break;
                    }
                    
            }

        }

        public void UsePotion()  //a function which handles the player's choice to use a potion.
        {
            Console.WriteLine("\n");
            Console.WriteLine(player.InventoryContents());
            Console.WriteLine("Which potion would you like to use?");
            string item = Console.ReadLine();
            switch (item)
            {
                case "SML Health Potion":
                    player.Health = player.Health + 28;
                    player.RemoveItem("SML Health Potion");
                    Console.WriteLine("You use the SML Health Potion.");
                    monster.Attack(player);
                    Console.WriteLine("Press any key to continue.");
                    if (player.Health > 105)
                    {
                        player.Health = 105;
                    }
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        default:
                            CombatEncounter();
                            break;
                    }
                    break;
                case "LRG Health Potion":
                    player.Health = player.Health + 55;
                    player.RemoveItem("LRG Health Potion");
                    Console.WriteLine("You use the LRG Health Potion.");
                    monster.Attack(player);
                    Console.WriteLine("Press any key to continue.");
                    if (player.Health > 105)
                    {
                        player.Health = 105;
                    }

                    string input3 = Console.ReadLine();
                    switch (input3)
                    {
                        default:
                            CombatEncounter();
                            break;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("No such item is found in your inventory.");
                        CombatEncounter();
                        break;
                    }
            }
        }

        public void InBossRoom()  //a function which handles the player's choice to enter the boss room.
        {
            Console.Clear();
            currentRoom = Room.BossRoom;  //sets the current room to the boss room.
            Room.BossRoom = new Room("BOSS ROOM", "You are standing in a dimly lit stone room, with a large monster limping by the back wall.");
            Console.WriteLine("You proceed through the doorway.");
            Console.WriteLine("Sat idly next to the door lies a crate. open it?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nYou open the crate, and inside lays a CROSSBOW.");
                    Console.WriteLine("CROSSBOW added to your inventory.");
                    player.PickUpItem("CROSSBOW");
                    Console.WriteLine("\n(The CROSSBOW is a powerful weapon that ignores a small sum of enemies DEF stat)");
                    Console.WriteLine("\nSuch a powerful weapon filled with plenty ammunition, sat here idly, why?");
                    Console.WriteLine("With the whispers still murmuring, you observe the remainder of the room, noticing a group of the previously encountered MONSTRO GHOULS.");
                    Console.WriteLine("They appear to be staring towards the ceiling, where hangs a much larger-looking variant of these creatures - clearly this is their boss.");
                    Monsters.WolflordGhoul = new Monsters("WOLFLORD GHOUL", 140, 12, 5, 8);  //initialises the boss monster.
                    monster = Monsters.WolflordGhoul;  //sets the monster to the boss monster.
                    Console.WriteLine("You should ready yourself for a COMBAT ENCOUNTER.");
                    Console.WriteLine("\nPress any key to continue.");
                    CurrentMonsterBoss = true;  //sets the boolean to true, indicating the current monster is a boss.
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        default:
                            CombatEncounter();
                            break;
                    }

                    break;

                case "2":
                    Console.WriteLine("\nYou bypass the crate and continue on.");
                    Console.WriteLine("\nWith the whispers still murmuring, you observe the remainder of the room, noticing a group of the previously encountered MONSTRO GHOULS.");
                    Console.WriteLine("They appear to be staring towards the ceiling, where hangs a much larger-looking variant of these creatures - clearly this is their boss.");
                    Monsters.WolflordGhoul = new Monsters("WOLFLORD GHOUL", 140, 12, 5, 8);
                    monster = Monsters.WolflordGhoul;
                    Console.WriteLine("You should ready yourself for a COMBAT ENCOUNTER.");
                    Console.WriteLine("\nPress any key to continue.");
                    CurrentMonsterBoss = true;
                    string input3 = Console.ReadLine();
                    switch (input3)
                    {
                        default:
                            CombatEncounter();
                            break;
                    }
                    break;

                default:
                    InBossRoom();
                    break;
            
            }
        }


        public void ItemPickup()  //a function called to handle the player collecting the item. This function is what sets the boolean to true, indicating the player has collected the item, allowing the player to progress.
        {
            player.PickUpItem("DAGGER");
            ItemPickedUp = true;
            Console.WriteLine("\nYou collect the DAGGER, it sits loosely in your pocket.");
            Console.WriteLine("Would you like to check your inventory?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":  //calls the function to display the player's inventory.
                    Console.WriteLine("\nInventory");
                    Console.WriteLine(player.InventoryContents());
                    Console.WriteLine("\ntype any key to continue.");
                    string input2 = Console.ReadLine();
                    switch (input2)
                    {
                        default:
                            Console.WriteLine("You continue.");
                            Console.Clear();
                            break;
                    }
                    break;
                case "2":  //handles the player's choice to not check their inventory.
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
