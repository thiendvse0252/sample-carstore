using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace car_gallery_app.Models {
    public class Cart {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CarId")]
        [Display(Name = "Car ID")]
        public string CarId { get; set; }

        [BsonElement("UserId")]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [BsonElement("Total")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [BsonElement("Quantity")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
