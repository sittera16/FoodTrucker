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
    public class ScheduleController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateScheduleService();
            var model = service.GetSchedules();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScheduleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateScheduleService();

            if (service.CreateSchedule(model))
            {
                TempData["SaveResult"] = "The schedule was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Schedule could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateScheduleService();
            var model = svc.GetScheduleById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateScheduleService();
            var detail = service.GetScheduleById(id);
            var model =
                new ScheduleEdit
                {
                    Id = detail.Id,
                    Date = detail.Date,
                    LocationId = detail.LocationId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScheduleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateScheduleService();

            if (service.UpdateSchedule(model))
            {
                TempData["SaveResult"] = "The schedule was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The schedule could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateScheduleService();
            var model = svc.GetScheduleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateScheduleService();

            service.DeleteSchedule(id);

            TempData["SaveResult"] = "The schedule was removed";

            return RedirectToAction("Index");
        }

        private ScheduleService CreateScheduleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScheduleService(userId);
            return service;
        }
    }
}