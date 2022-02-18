using FoodTrucker.Data;
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
    public class RecipeIngredientController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateRecipeIngredientService();
            var model = service.GetRecipeIngredients();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeIngredientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRecipeIngredientService();

            if (service.CreateRecipeIngredient(model))
            {
                TempData["SaveResult"] = "The recipe-ingredient was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Recipe-Ingredient could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipeIngredientService();
            var model = svc.GetRecipeIngredientById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeIngredientService();
            var detail = service.GetRecipeIngredientById(id);
            var model =
                new RecipeIngredientEdit
                {
                    Id = detail.Id,
                    IngredientId = detail.IngredientId,
                    RecipeId = detail.RecipeId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeIngredientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipeIngredientService();

            if (service.UpdateRecipeIngredient(model))
            {
                TempData["SaveResult"] = "The recipe-ingredient was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The recipe-ingredient could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeIngredientService();
            var model = svc.GetRecipeIngredientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRecipeIngredientService();

            service.DeleteRecipeIngredient(id);

            TempData["SaveResult"] = "The recipe-ingredient was removed";

            return RedirectToAction("Index");
        }

        private RecipeIngredientService CreateRecipeIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeIngredientService(userId);
            return service;
        }
    }
}