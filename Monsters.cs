using DungeonExplorer;
using System;
using System.Data.SqlTypes;

public class Monsters
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attackpower { get; set; }
    public int defblock { get; set; }

    static public Monsters WolflordGhoul { get; set; }

    public int Defence { get; set; }
    public Monsters(string name, int health, int attack, int defence)
    {
        Name = name;
        Health = health;
        Attackpower = attack;
        Defence = defence;
    }
    public void Attack(DungeonExplorer.Player player)
    {
        Attackpower = Attackpower - player.Defence;
        player.Health -= Attackpower;
        Console.WriteLine($"\n{Name} attacks {player.Name} for {Attackpower} damage!");
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"\n{Name} takes {damage} damage!");
    }

    public void Bosswolflordghoul()
    {
        WolflordGhoul = new Monsters("Wolflord Ghoul", 140, 12, 5);
        if (WolflordGhoul.Health <= 60)
        {
            Console.WriteLine($"\n{Name} is enraged and calls in minions.");
            Attackpower = 8;
        }
    }
}
