using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int AttackPower { get; set; } = 3; // Default attack power
        public int Defence { get; set; } = 0;
        public int Counter { get; set; }

        private List<string> inventory = new List<string>();

        public Player(string name, int health, int attack, int defence, int counter) 
        {
            Name = name;
            Health = health;
            AttackPower = attack;
            Defence = defence;
            Counter = counter;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public void UseItem(string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                // Logic to use the item can be added here
            }
        }
        public void RemoveItem(string item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }
        public string InventoryContents()
        {
            return inventory.Count == 0 ? "Your inventory is empty." : string.Join(", ", inventory);
        }
        public void PlayerCounter(DungeonExplorer.Monsters monster)
        {
            int damage = Counter - monster.Defence;
            monster.Health -= Counter;
            Console.WriteLine($"\n{Name} uses a COUNTER on {monster.Name} for {Counter} DMG!");
        }
    }
}