using DungeonExplorer;
using System;
using System.Data.SqlTypes;
using System.Collections.Generic;
namespace DungeonExplorer
{
    public class Monsters
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attackpower { get; set; }
        public int FUAattack { get; set; }

        static public Monsters WolflordGhoul { get; set; }
        static public Monsters MontsroGhoul { get; set; }

        public int Defence { get; set; }
        public Monsters(string name, int health, int attack, int defence, int FUApower)
        {
            Name = name;
            Health = health;
            Attackpower = attack;
            FUAattack = FUApower;
            Defence = defence;
        }
        public void Attack(DungeonExplorer.Player player)
        {
            int damage = Attackpower - player.Defence;
            player.Health -= Attackpower;
            Console.WriteLine($"\n{Name} attacks {player.Name} for {Attackpower} DMG!");
        }
        public void FUAattackPlayer(DungeonExplorer.Player player)
        {
            int damage = FUAattack - player.Defence;
            player.Health -= FUAattack;
            Console.WriteLine($"\n{Name} uses a follow-up attack on {player.Name} for {FUAattack} DMG!");
        }
        public void TakeDamage(int damage)
        {
            damage = damage - Defence;
            Health -= damage;
            Console.WriteLine($"\n{Name} takes {damage} DMG!");
        }

    }
}
