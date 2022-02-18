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
    public class IngredientController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateIngredientService();
            var model = service.GetIngredients();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "The ingredient was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ingredient could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model =
                new IngredientEdit
                {
                    Name = detail.Name,
                    QuantityInStock = detail.QuantityInStock,
                    IngredientType = detail.IngredientType,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientService();

            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "The ingredient was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The ingredient could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateIngredientService();

            service.DeleteIngredient(id);

            TempData["SaveResult"] = "The ingredient was removed";

            return RedirectToAction("Index");
        }

        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }
    }
}