public class Player
{
    // The player's chosen name.
    public string Name { get; set; } = "";

    // The character class: Warrior, Mage, or Rogue.
    public string CharacterClass { get; set; } = "";

    // The player's current health points.
    public int Health { get; set; }

    // How much damage the player deals when attacking.
    public int AttackPower { get; set; }

    // Currency earned during the adventure.
    public int Gold { get; set; }
}