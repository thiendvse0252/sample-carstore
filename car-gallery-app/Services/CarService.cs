using car_gallery_app.Models;
using MongoDB.Driver;

namespace car_gallery_app.Services {
    public class CarService {
        private readonly IMongoCollection<Car> cars;

        public CarService(IConfiguration config) {
            MongoClient client = new MongoClient(config.GetConnectionString("CarGalleryDb"));
            IMongoDatabase database = client.GetDatabase("CarGalleryDb");
            cars = database.GetCollection<Car>("Cars");
        }

        public List<Car> Get() {
            return cars.Find(car => true).ToList();
        }

        public Car Get(string id) {
            return cars.Find(car => car.Id == id).FirstOrDefault();
        }

        public Car Create(Car car) {
            cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn) {
            cars.ReplaceOne(car => car.Id == id, carIn);
        }

        public void Remove(Car carIn) {
            cars.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id) {
            cars.DeleteOne(car => car.Id == id);
        }
    }
}
