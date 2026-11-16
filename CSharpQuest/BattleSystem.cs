
public class BattleSystem
{
    public static void Battle(Player player, Monster monster)
    {
        Console.WriteLine($"A wild {monster.Name} appears!");

        while (player.Health > 0 && monster.Health > 0)
        {
            Console.WriteLine($"Your HP: {player.Health}");
            Console.WriteLine($"{monster.Name} HP: {monster.Health}");

            // We'll add the player's actions here.
        }
    }
} 