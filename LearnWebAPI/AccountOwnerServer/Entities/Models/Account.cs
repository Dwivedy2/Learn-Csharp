using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("account")]
    public class Account
    {
        [Column("AccountId")]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
