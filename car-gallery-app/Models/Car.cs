using System.ComponentModel.DataAnnotations;
using car_gallery_app.CustomAttributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace car_gallery_app.Models {
    public class Car {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]   //allow passing parameter as type string instead of ObjectId. Mongo handles the conversion from string to ObjectId
        public string Id { get; set; }

        [BsonElement("Branch")]
        [Required]
        public string Branch { get; set; }

        [BsonElement("Model")]
        [Required]
        public string Model { get; set; }

        [BsonElement("Year")]
        [Required]
        [YearRange]
        public int Year { get; set; }

        [BsonElement("Price")]
        [Display(Name = "Price($)")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
    }
}
