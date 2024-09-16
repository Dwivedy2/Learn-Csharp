using WarriorWars.Enums;
using WarriorWars.Equipment;

namespace WarriorWars
{
    public class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;

        private int health;
        private string name;
        private bool isAlive = true;

        public bool IsAlive
        {
            get { return isAlive; }
        }

        private Weapon weapon;
        private Armour armour;
        private readonly Faction FACTION;

        // new warrior with a name and faction
        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;

            switch (faction)
            {
                case Faction.GoodGuy:
                    this.armour = new Armour(faction);
                    this.weapon = new Weapon(faction);
                    this.health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    this.armour = new Armour(faction);
                    this.weapon = new Weapon(faction);
                    this.health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armour.ArmourPoints;
            enemy.health -= damage;
            enemy.isAlive = enemy.health > 0;
            Console.WriteLine($"{this.name} attacks");
            Console.WriteLine($"{this.name} health: {this.health}");
            Console.WriteLine($"{enemy.name} health: {enemy.health}");
            Console.WriteLine("--------------------------------------");

            if (enemy.health <= 0)
            {
                Tools.ColourfulWriteLine(($"{this.name} wins!"), ConsoleColor.Green);
                Tools.ColourfulWriteLine(($"{enemy.name} loose"), ConsoleColor.Red);
            }
        }
    }
}
