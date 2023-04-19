using Lemon_d.local.Database.DbModels._AdditionalClasses;
using Lemon_d.local.Database.DbModels.Identity;
using Lemon_d.local.Database.DbModels._AdditionalClasses.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lemon_d.local.Database.DbModels
{
    public class Project
    {
        public string Name { get; set; }
        [Key]
        public Guid ID { get; set; }
        public string GameID { get; set; }
        public string? SlugDescription { get; set; }
        public List<Image>? Images { get; set; }
        public List<Genre>? Genres { get; set; }
        public Platforms? Platforms { get; set; }
        public int GlobalRating { get; set; }
        public PersonalRating PersonalRating { get; set; }
        public List<Note>? Notes { get; set; }
        public List<Company>? Companies { get; set; }
        public DateTime? PlannedFor { get; set; }
        public Priority Priority { get; set; }
        public bool VoteForRemoval { get; set; }
        public List<UserCompletion> Completions { get; set; }
        public List<Tag>? Tags { get; set; }
        public PlayerAmount PlayerAmount { get; set; }

        public Project()
        {
            this.ID = Guid.NewGuid();
        }
    }

    public class Company
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class Platforms
    {
        [Key]
        public Guid ID { get; set; }
        public List<Platform> AvailablePlatforms { get; set; }
        public Platform? PreferredPlatform { get; set; }
    }

    public class Platform
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class PersonalRating
    {
        [Key]
        public Guid ID { get; set; }
        public int Rating { get; set; }
    }

    public class UserCompletion
    {
        [Key]
        public Guid ID { get; set; }
        public int Completion { get; set; }
        public AppUser User { get; set; }
    }

    public class Genre
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class Tag
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

    public class PlayerAmount
    {
        public Guid ID { get; set; }
        public bool Singleplayer { get; set; }
        public bool OfflineCoop { get; set; }
        public bool LocalCoop { get; set; }
        public bool OnlineCoop { get; set; }
    }
}
