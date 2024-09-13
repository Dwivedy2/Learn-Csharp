using EntryPoint.User;
using EntryPoint.Enums;
using EntryPoint.ExceptionHandeling;

namespace EntryPoint.Enums
{
    public class EnumController
    {
        public static void MakeUser(Race userRace)
        {
            CommonUser user = new CommonUser();

            user.race = userRace;

            if(user.race == Race.Marsian)
            {
                Console.WriteLine($"User is a martian, given +{(int)Race.Marsian} point.");
            }
            else
            {
                Console.WriteLine($"User is a earthling, given +{(int)Race.Eathling} point.");
            }
        }
    }
}
