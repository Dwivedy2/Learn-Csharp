using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDay.Entities
{
    [Table("accountholders")]
    public class AccountHolder
    {
        public int Id { get; set; }
        public string? UserName { get; set; }

        public void printName()
        {
            Console.WriteLine("Prateek");
        }

        public bool isPrintNameWorking()
        {
            if (this.UserName == null)
            {
                return false;
            }
            return true;
        }
    }
}
