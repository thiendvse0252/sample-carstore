using car_gallery_app.Models;
using car_gallery_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_gallery_app.Controllers {
    public class CarsController : Controller {
        private readonly CarService carService;

        public CarsController(CarService carService) {
            this.carService = carService;
        }

        // GET: CarsController
        public ActionResult Index() {
            return View(carService.Get());
        }

        // GET: CarsController/Details/id
        public ActionResult Details(string id) {
            if (id == null) {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null) {
                return NotFound();
            }
            return View(car);
        }

        // GET: CarsController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car) {
                if (ModelState.IsValid) {
                    carService.Create(car);
                    return RedirectToAction(nameof(Index));
                }
                return View(car);
        }

        // GET: CarsController/Edit/id
        public ActionResult Edit(string id) {
            if (id == null) {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null) {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car) {
            if (id != car.Id) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                carService.Update(id, car);
                return RedirectToAction(nameof(Index));
            } else {
                return View(car);
            }
        }

        // GET: CarsController/Delete/id
        public ActionResult Delete(string id) {
            if(id == null) {
                return NotFound();
            }

            var car = carService.Get(id);
            if(car == null) {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id) {
            try {
                var car = carService.Get(id);
                if(car == null) {
                    return NotFound();
                }

                carService.Remove(car.Id);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}
