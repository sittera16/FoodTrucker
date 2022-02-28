using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using FoodTrucker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodTrucker.WebMVC.Controllers
{
    [Authorize]
    public class TransactionMenuItemController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateTransactionMenuItemService();
            var model = service.GetTransactionMenuItems();
            return View(model);
        }

        // GET: 
        public ActionResult Create()
        {
            List<MenuItemListItem> MenuItems = CreateMenuItemService().GetMenuItems().ToList();
            var query = from m in MenuItems
                        select new SelectListItem()
                        {
                            Value = m.Id.ToString(),
                            Text = m.Name,
                        };
            ViewBag.MenuItemId = query.ToList();

            List<TransactionListItem> Transactions = CreateTransactionService().GetTransactions().ToList();
            var query2 = from r in Transactions
                         select new SelectListItem()
                         {
                             Value = r.Id.ToString(),
                             Text = r.TransactionDate.ToString(),
                         };
            ViewBag.TransactionId = query2.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionMenuItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionMenuItemService();

            if (service.CreateTransactionMenuItem(model))
            {
                TempData["SaveResult"] = "The transaction menu item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction menu item could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionMenuItemService();
            var model = svc.GetTransactionMenuItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTransactionMenuItemService();
            var detail = service.GetTransactionMenuItemById(id);

            List<MenuItemListItem> MenuItems = CreateMenuItemService().GetMenuItems().ToList();
            var query = from i in MenuItems
                        select new SelectListItem()
                        {
                            Value = i.Id.ToString(),
                            Text = i.Name,
                        };
            ViewBag.MenuItemId = query.ToList();

            List<TransactionListItem> Transactions = CreateTransactionService().GetTransactions().ToList();
            var query2 = from r in Transactions
                         select new SelectListItem()
                         {
                             Value = r.Id.ToString(),
                             Text = r.TransactionDate.ToString(),
                         };
            ViewBag.TransactionId = query2.ToList();

            var model =
                new TransactionMenuItemEdit
                {
                    Id = detail.Id,
                    MenuItemId = detail.MenuItemId,
                    TransactionId = detail.TransactionId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionMenuItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransactionMenuItemService();

            if (service.UpdateTransactionMenuItem(model))
            {
                TempData["SaveResult"] = "The transaction menu item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The transaction menu item could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionMenuItemService();
            var model = svc.GetTransactionMenuItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTransactionMenuItemService();

            service.DeleteTransactionMenuItem(id);

            TempData["SaveResult"] = "The transaction menu item was removed";

            return RedirectToAction("Index");
        }

        private TransactionMenuItemService CreateTransactionMenuItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionMenuItemService(userId);
            return service;
        }
        private MenuItemService CreateMenuItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MenuItemService(userId);
            return service;
        }
        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }

    }
}