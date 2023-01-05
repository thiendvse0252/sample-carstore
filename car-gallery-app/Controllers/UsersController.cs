using car_gallery_app.Models;
using car_gallery_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace car_gallery_app.Controllers {
    public class UsersController : Controller {
        private readonly UserService userService;

        public UsersController(UserService userService) {
            this.userService = userService;
        }
        // GET: UsersController
        public ActionResult Index() {
            return View(userService.Get());
        }

        // GET: UsersController/Details/uid
        public ActionResult Details(string id) {
            if(id == null) {
                return NotFound();
            }

            var user = userService.Get(id);
            if(user == null) {
                return NotFound();
            }
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user) {
            if (ModelState.IsValid) {
                userService.Create(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: UsersController/Edit/uid
        public ActionResult Edit(string id) {
            if(id == null) {
                return NotFound();
            }

            var user = userService.Get(id);
            if(user == null) {
                return NotFound();
            }
            return View(user);
        }

        // POST: UsersController/Edit/uid
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, User user) {
            if(id != user.Id) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                userService.Update(id, user);
                return RedirectToAction(nameof(Index));
            } else {
                return View(user);
            }
        }

        // GET: UsersController/Delete/uid
        public ActionResult Delete(string id) {
            if(id == null) {
                return NotFound();
            }
            var user = userService.Get(id);
            if(user == null) {
                return NotFound();
            }
            return View(user);
        }

        // POST: UsersController/Delete/uid
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id) {
            try {
                var user = userService.Get(id);
                if(user == null) {
                    return NotFound();
                }
                userService.Remove(user.Id);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}
