using car_gallery_app.Models;
using car_gallery_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_gallery_app.Controllers {
    public class CartsController : Controller {
        private readonly CartService cartService;
        public CartsController(CartService cartService) {
            this.cartService = cartService;
        }

        // GET: CartsController
        public ActionResult Index() {
            return View(cartService.Get());
        }

        // GET: CartsController/Details/cartId
        public ActionResult Details(string id) {
            return View();
        }

        // GET: CartsController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: CartsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cart cart) {
            if(ModelState.IsValid) {
                cartService.Create(cart);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CartsController/Edit/cartId
        public ActionResult Edit(string id) {
            if(id == null) {
                return NotFound();
            }
            var cart = cartService.Get(id);
            if(cart == null) {
                return NotFound();
            }
            return View(cart);
        }

        // POST: CartsController/Edit/cartId
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Cart cart) {
            if(id != cart.Id) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                cartService.Update(id, cart);
                return RedirectToAction(nameof(Index));
            } else {
                return View(cart);
            }
            
        }

        // GET: CartsController/Delete/5
        public ActionResult Delete(string id) {
            if(id == null) {
                return NotFound();
            }
            var cart = cartService.Get(id);
            if(cart == null) {
                return NotFound();
            }
            return View(cart);
        }

        // POST: CartsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id) {
            try {
                var cart = cartService.Get(id);
                if(cart == null) {
                    return NotFound();
                }

                cartService.Remove(id);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}
