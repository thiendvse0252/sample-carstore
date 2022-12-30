using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace car_gallery_app.Models {
    public class User {
        [BsonId]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [BsonElement("password")]
        [Required]
        public string Password { get; set; }

        [BsonElement("fullname")]
        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }

        [BsonElement("state")]
        public Boolean State { get; set; }

    }
}
