using Lemon_d.local.Database.DbModels.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lemon_d.local.Database.DbModels._AdditionalClasses
{
    public class Note
    {
        [Key]
        public Guid ID { get; set; }
        public string Text { get; set; }
        public AppUser? Author { get; set; }
    }
}
