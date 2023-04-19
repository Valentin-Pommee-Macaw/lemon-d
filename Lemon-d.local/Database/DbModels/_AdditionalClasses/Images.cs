using System.ComponentModel.DataAnnotations;

namespace Lemon_d.local.Database.DbModels._AdditionalClasses
{

    public class Image
    {
        [Key]
        public Guid ID { get; set; }
        public string URL { get; set; }
        public string ImageID { get; set; }
        public ImageType Type { get; set; }
    }

    public enum ImageType
    {
        Cover = 0,
        Thumbnail = 1,
    }
}
