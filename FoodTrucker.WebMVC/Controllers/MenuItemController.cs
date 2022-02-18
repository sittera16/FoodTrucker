using FoodTrucker.Models.Customer;
using FoodTrucker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrucker.WebMVC.Controllers
{
    [Authorize]
    public class MenuItemController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateMenuItemService();
            var model = service.GetMenuItems();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMenuItemService();

            if (service.CreateMenuItem(model))
            {
                TempData["SaveResult"] = "The menu-item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Menu-item could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMenuItemService();
            var model = svc.GetMenuItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMenuItemService();
            var detail = service.GetMenuItemById(id);
            var model =
                new MenuItemEdit
                {
                    RecipeId = detail.RecipeId,
                    Price = detail.Price,
                    Description = detail.Description,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MenuItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMenuItemService();

            if (service.UpdateMenuItem(model))
            {
                TempData["SaveResult"] = "The menu-item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The menu-item could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateMenuItemService();
            var model = svc.GetMenuItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMenuItemService();

            service.DeleteMenuItem(id);

            TempData["SaveResult"] = "The menu-item was removed";

            return RedirectToAction("Index");
        }

        private MenuItemService CreateMenuItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MenuItemService(userId);
            return service;
        }
    }
}