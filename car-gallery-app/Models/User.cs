using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace car_gallery_app.Models {
    public class User {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Password")]
        [Required]
        public string Password { get; set; }

        [BsonElement("Fullname")]
        [Required]
        public string FullName { get; set; }

        [BsonElement("State")]
        public Boolean State { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }

    }
}
