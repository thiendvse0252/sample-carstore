using car_gallery_app.Models;
using MongoDB.Driver;

namespace car_gallery_app.Services {
    public class CartService {
        private readonly IMongoCollection<Cart> carts;

        public CartService(IConfiguration config) {
            MongoClient client = new(config.GetConnectionString("CarGalleryDb"));
            IMongoDatabase database = client.GetDatabase("CarGalleryDb");
            carts = database.GetCollection<Cart>("Carts");
        }

        public List<Cart> Get() {
            return carts.Find(cart => true).ToList();
        }

        public Cart Get(string id) {
            return carts.Find(cart => cart.Id == id).FirstOrDefault();
        }

        public Cart Create(Cart cart) {
            carts.InsertOne(cart);
            return cart;
        }

        public void Update(string id, Cart cartIn) {
            carts.ReplaceOne(cart => cart.Id == id, cartIn);
        }

        public void Remove(Cart cartIn) {
            carts.DeleteOne(cart => cart.Id == cartIn.Id);
        }

        public void Remove(string id) {
            carts.DeleteOne(cart => cart.Id == id);
        }
    }
}
