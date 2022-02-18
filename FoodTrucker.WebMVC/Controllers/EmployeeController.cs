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
    public class EmployeeController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateEmployeeService();
            var model = service.GetEmployees();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "The employee was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Employee could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);
            var model =
                new EmployeeEdit
                {
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    HireDate = detail.HireDate,
                    IsCurrentlyEmployeed = detail.IsCurrentlyEmployeed,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEmployeeService();

            if (service.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "The employee was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The employee could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployeeService();

            service.DeleteEmployee(id);

            TempData["SaveResult"] = "The employee was removed";

            return RedirectToAction("Index");
        }

        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }
    }
}