using WarriorWars.Enums;

namespace WarriorWars
{
    public class Start
    {
        static Random rn = new Random();
        public static void Main(string[] args)
        {
            Warrior goodGuy = new Warrior("Aman", Faction.GoodGuy);
            Warrior badGuy = new Warrior("Satyam", Faction.BadGuy);

            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                
                int number = rn.Next(1, 10);
                if (number > 5) 
                {
                    goodGuy.Attack(badGuy);
                }
                else
                {
                    badGuy.Attack(goodGuy);
                }
            }
        }
    }
}