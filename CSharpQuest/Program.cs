using System;

// Create the monster that the player may encounter.
Monster monster = new Monster();
monster.Name = "Wild Beast";

// Display the game's introduction.
Console.WriteLine("=== C# Quest ===");
Console.WriteLine("Welcome, adventurer!");
Console.WriteLine("You find yourself in a mysterious land filled with challenges and treasures.");
Console.WriteLine("Your quest is to explore this land, overcome obstacles, and discover hidden secrets.");

// Ask the player for their name.
Console.WriteLine("Enter your name, brave adventurer:");
string playerName = Console.ReadLine() ?? string.Empty;

// Create a Player object and store the player's name.
Player player = new Player();
player.Name = playerName;

Console.WriteLine($"Greetings, {player.Name}, your journey begins now!");
Console.WriteLine($"Welcome to C# Quest, {player.Name}!");

// Allow the player to choose a character class.
Console.WriteLine("Choose your class: (1) Warrior, (2) Mage, (3) Rogue");
string playerClass = Console.ReadLine() ?? "";

// Assign different stats based on the selected class.
if (playerClass == "1")
{
    Console.WriteLine("You have chosen the Warrior class!");
    Console.WriteLine("As a Warrior, you excel in close combat and have high strength and endurance.");

    player.CharacterClass = "Warrior";
    player.Health = 100;
    player.AttackPower = 30;
}
else if (playerClass == "2")
{
    Console.WriteLine("You have chosen the Mage class!");
    Console.WriteLine("As a Mage, you possess powerful magical abilities and can cast devastating spells.");

    player.CharacterClass = "Mage";
    player.Health = 80;
    player.AttackPower = 40;
}
else if (playerClass == "3")
{
    Console.WriteLine("You have chosen the Rogue class!");
    Console.WriteLine("As a Rogue, you are swift and cunning, with high agility and the ability to strike from the shadows.");

    player.CharacterClass = "Rogue";
    player.Health = 70;
    player.AttackPower = 35;
}
else
{
    // Default to Warrior if the player enters an invalid choice.
    Console.WriteLine("Invalid choice. Defaulting to Warrior class.");

    player.CharacterClass = "Warrior";
    player.Health = 100;
    player.AttackPower = 30;
}

// Display the player's starting statistics.
Console.WriteLine($"Class: {player.CharacterClass}");
Console.WriteLine($"Health: {player.Health}");
Console.WriteLine($"Attack Power: {player.AttackPower}");

// Let the player choose which path to explore.
Console.WriteLine("Choose your path: (1) Forest, (2) Mountain, (3) River");
string playerPath = Console.ReadLine() ?? "";

// Set the monster's statistics based on the chosen path.
if (playerPath == "1")
{
    Console.WriteLine("You have chosen the Forest path!");
    Console.WriteLine("The forest is dense and filled with hidden dangers, but also treasures.");
    Console.WriteLine("While exploring the forest, you encounter a wild beast!");

    monster.Health = 150;
    monster.AttackPower = 15;
}
else if (playerPath == "2")
{
    Console.WriteLine("You have chosen the Mountain path!");
    Console.WriteLine("The mountains are treacherous and challenging, but the view from the top is breathtaking.");
    Console.WriteLine("While climbing the mountain, you encounter a wild beast!");

    monster.Health = 100;
    monster.AttackPower = 15;
}
else if (playerPath == "3")
{
    // The River path does not contain a monster encounter.
    Console.WriteLine("You have chosen the River path!");
    Console.WriteLine("The river is calm and serene, but beware of the creatures that lurk beneath its surface.");
    Console.WriteLine("You manage to cross the river without any monster encounters.");
}
else
{
    // Use the Forest path if the input is invalid.
    Console.WriteLine("Invalid choice. Defaulting to Forest path.");

    playerPath = "1";
    monster.Health = 150;
    monster.AttackPower = 15;
}

// Track the battle result and the player's gold.
bool monsterDefeated = false;
int gold = 0;

// Continue combat while both characters are alive.
// The River path skips this loop because monster.Health is 0.
while (player.Health > 0 && monster.Health > 0)
{
    Console.WriteLine($"Your health: {player.Health}, Monster's health: {monster.Health}");
    Console.WriteLine("Choose your action: (1) Attack, (2) Defend, (3) Run");

    string playerAction = Console.ReadLine() ?? "";

    // Track whether the monster should attack this turn.
    bool monsterTurn = true;
    bool defending = false;

    if (playerAction == "1")
    {
        // Reduce the monster's health by the player's attack power.
        Console.WriteLine("You attack the monster!");

        monster.Health -= player.AttackPower;

        Console.WriteLine($"You dealt {player.AttackPower} damage to the monster.");
    }
    else if (playerAction == "2")
    {
        // Defending reduces the damage from the next monster attack.
        Console.WriteLine("You prepare to defend against the monster!");

        defending = true;
    }
    else if (playerAction == "3")
    {
        // Give the player a 50% chance of escaping.
        Console.WriteLine("You attempt to run away!");

        if (Random.Shared.Next(0, 2) == 0)
        {
            Console.WriteLine("You successfully escaped!");
            break;
        }

        Console.WriteLine("You failed to escape!");
    }
    else
    {
        // Invalid actions use up the player's turn.
        Console.WriteLine("Invalid action! The monster prepares to attack.");
    }

    // Check whether the monster was defeated.
    if (monster.Health <= 0)
    {
        Console.WriteLine("Congratulations! You have defeated the monster!");

        monsterDefeated = true;

        // Award a random amount of gold between 10 and 50.
        int goldEarned = Random.Shared.Next(10, 51);
        gold += goldEarned;

        Console.WriteLine($"You earned {goldEarned} gold!");
        break;
    }

    // The monster attacks if it is still alive.
    if (monsterTurn && monster.Health > 0)
    {
        int damage = monster.AttackPower;

        // Reduce damage by half when the player defends.
        if (defending)
        {
            damage /= 2;
        }

        player.Health -= damage;

        Console.WriteLine($"The monster attacks you for {damage} damage.");
    }

    // End the battle if the player's health reaches zero.
    if (player.Health <= 0)
    {
        Console.WriteLine("You have been defeated by the monster. Game over.");
        break;
    }
}

// Display the story after a successful battle.
if (monsterDefeated)
{
    Console.WriteLine();
    Console.WriteLine("After the battle, you discover a hidden treasure chest.");
    Console.WriteLine($"You now have {gold} gold!");

    Console.WriteLine();
    Console.WriteLine("You continue down the path...");
    Console.WriteLine("After a long journey, you finally reach a peaceful village.");

    Console.WriteLine("You made it to the village safely!");
    Console.WriteLine("You can now rest and recover.");
    Console.WriteLine("The village mayor approaches you...");
}
else if (playerPath == "3")
{
    // The River path reaches the village without combat.
    Console.WriteLine("You safely crossed the river!");
    Console.WriteLine("You arrive at the peaceful village.");
    Console.WriteLine("The village mayor approaches you...");
}
