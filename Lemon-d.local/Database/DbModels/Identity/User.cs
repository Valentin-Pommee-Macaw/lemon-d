using Lemon_d.local.Database.DbModels._AdditionalClasses;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lemon_d.local.Database.DbModels.Identity
{
    public class AppUser : IdentityUser
    {
        [Key]
        public Guid AppUserID { get; set; }
        public int AverageRating { get; set; }
        public Project? MostWanted { get; set; }
        public Project? Favourite { get; set; }
        public int? AverageCompletion { get; set; }
        public Project? CurrentlyPlaying { get; set; }
        public Platforms? PlatformsOwned { get; set; }
        public List<Note>? Notes { get; set; }
    }
}
