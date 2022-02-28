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
    public class TransactionController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateTransactionService();
            var model = service.GetTransactions();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            List<CustomerListItem> Customers = CreateCustomerService().GetCustomers().ToList();
            var query = from i in Customers
                        select new SelectListItem()
                        {
                            Value = i.Id.ToString(),
                            Text = i.LastName + ", " + i.FirstName,
                        };
            ViewBag.CustomerId = query.ToList();

            List<LocationListItem> Locations = CreateLocationService().GetLocations().ToList();
            var query2 = from r in Locations
                         select new SelectListItem()
                         {
                             Value = r.Id.ToString(),
                             Text = r.Address,
                         };
            ViewBag.LocationId = query2.ToList();

            List<EmployeeListItem> Employees = CreateEmployeeService().GetEmployees().ToList();
            var query3 = from i in Employees
                         select new SelectListItem()
                         {
                             Value = i.Id.ToString(),
                             Text = i.LastName + ", " + i.FirstName,
                         };
            ViewBag.EmployeeId = query3.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "The transaction was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionById(id);

            List<CustomerListItem> Customers = CreateCustomerService().GetCustomers().ToList();
            var query = from r in Customers
                        select new SelectListItem()
                        {
                            Value = r.Id.ToString(),
                            Text = r.LastName + ", " + r.FirstName,
                        };
            ViewBag.CustomerId = query.ToList();

            List<LocationListItem> Locations = CreateLocationService().GetLocations().ToList();
            var query2 = from r in Locations
                         select new SelectListItem()
                         {
                             Value = r.Id.ToString(),
                             Text = r.Address,
                         };
            ViewBag.LocationId = query2.ToList();

            List<EmployeeListItem> Employees = CreateEmployeeService().GetEmployees().ToList();
            var query3 = from r in Employees
                         select new SelectListItem()
                         {
                             Value = r.Id.ToString(),
                             Text = r.LastName + ", " + r.FirstName,
                         };
            ViewBag.EmployeeId = query3.ToList();

            var model =
                new TransactionEdit
                {
                    Id = detail.Id,
                    TransactionDate = detail.TransactionDate,
                    CustomerId = detail.CustomerId,
                    TotalPrice = detail.TotalPrice,
                    LocationId = detail.LocationId,
                    EmployeeId = detail.EmployeeId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransactionService();

            if (service.UpdateTransaction(model))
            {
                TempData["SaveResult"] = "The transaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The transaction could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(id);

            TempData["SaveResult"] = "The transaction was removed";

            return RedirectToAction("Index");
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;

        }
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }
    }
}