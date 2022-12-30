using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace car_gallery_app.Models {
    public class Cart {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("carId")]
        [Display(Name = "Car ID")]
        public string CarId { get; set; }

        [BsonElement("userId")]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [BsonElement("total")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [BsonElement("quantity")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
