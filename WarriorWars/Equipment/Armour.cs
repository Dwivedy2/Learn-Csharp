using WarriorWars.Enums;

namespace WarriorWars.Equipment
{
    public class Armour
    {
        private const int GOOD_GUY_ARMOUR_POINTS = 5;
        private const int BAD_GUY_ARMOUR_POINTS = 5;

        private int armourPoints;

        public int ArmourPoints { get { return armourPoints; } }

        public Armour(Faction faction)
        {
            switch (faction)
            {
                case Faction.GoodGuy:
                    armourPoints = GOOD_GUY_ARMOUR_POINTS;
                    break;
                case Faction.BadGuy:
                    armourPoints = BAD_GUY_ARMOUR_POINTS;
                    break;
                default:
                    break;
            }
        }
    }
}