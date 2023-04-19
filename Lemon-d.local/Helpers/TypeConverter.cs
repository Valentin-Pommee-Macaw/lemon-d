using Lemon_d.local.Database.DbModels;
using Lemon_d.local.Database.DbModels._AdditionalClasses;
using Lemon_d.local.Database.DbModels._AdditionalClasses.Enums;
using Lemon_d.local.Models;

namespace Lemon_d.local.Helpers
{
    public class TypeConverter
    {
        public Project Convert(SearchResultModel.GamePartialQuery.Item item)
        {
            Project output = new Project()
            {
                Name = item.name,
                Images = new List<Image>(),
                Genres = new List<Genre>(),
                Companies = new List<Company>(),
                GlobalRating = (int)item.total_rating,
                Platforms = new Platforms() { ID = Guid.NewGuid() },
                PlayerAmount = new PlayerAmount(),
                GameID = item.id,
                SlugDescription = item.storyline,
                Priority = Priority.Medium,
                PersonalRating = new PersonalRating() { ID = Guid.NewGuid(), Rating = 0 }
            };
            if (item.cover != null)
            {
                output.Images.Add(new Image() { ID = Guid.NewGuid(), Type = ImageType.Cover, ImageID = item.cover.image_id, URL = $"https://images.igdb.com/igdb/image/upload/t_cover_big/{item.cover.image_id}.jpg" });
                output.Images.Add(new Image() { ID = Guid.NewGuid(), Type = ImageType.Thumbnail, ImageID = item.cover.image_id, URL = $"https://images.igdb.com/igdb/image/upload/t_screenshot_huge/{item.cover.image_id}.jpg" });
            }
            if(item.genres != null)
            {
                foreach (SearchResultModel.GamePartialQuery.Item.Genre g in item.genres)
                {
                    output.Genres.Add(new Genre()
                    {
                        ID = g.id,
                        Name = g.name
                    });
                }
            }
            if(item.involved_companies != null)
            {
                foreach (SearchResultModel.GamePartialQuery.Item.InvolvedCompany c in item.involved_companies)
                {
                    output.Companies.Add(new Company()
                    {
                        ID = c.company.id,
                        Name = c.company.name
                    });
                }
            }
            output.Platforms.AvailablePlatforms = new List<Platform>();
            if (item.platforms != null)
            {
                foreach (var p in item.platforms)
                {
                    output.Platforms.AvailablePlatforms.Add(new Platform()
                    {
                        ID = p.id,
                        Name = p.name
                    });
                }
            }
            if(item.multiplayer_modes != null)
            {
                output.PlayerAmount.LocalCoop = item.multiplayer_modes.Any(m => m.lancoop == true);
                output.PlayerAmount.OnlineCoop = item.multiplayer_modes.Any(m => m.onlinecoop == true);
                output.PlayerAmount.OfflineCoop = item.multiplayer_modes.Any(m => m.offlinecoop == true);
                if (!output.PlayerAmount.LocalCoop == true
                    && !output.PlayerAmount.OnlineCoop == true
                    && !output.PlayerAmount.OfflineCoop == true)
                {
                    output.PlayerAmount.Singleplayer = true;
                }
            } else {
                output.PlayerAmount.Singleplayer = true;
            }
            return output;
        }

        public SearchResultModel.GamePartialQuery.Item Convert(Project item)
        {
            return new SearchResultModel.GamePartialQuery.Item() {

            };
        }
    }
}
