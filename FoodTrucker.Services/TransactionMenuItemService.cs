using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class TransactionMenuItemService
    {
        private readonly Guid _userId;

        public TransactionMenuItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransactionMenuItem(TransactionMenuItemCreate model)
        {
            var entity =
                new TransactionMenuItem()
                {
                    MenuItemId = model.MenuItemId,
                    TransactionId = model.TransactionId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TransactionMenuItems.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<TransactionMenuItemListItem> GetTransactionMenuItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TransactionMenuItems
                        .Select(
                            c =>
                                new TransactionMenuItemListItem
                                {
                                    Id = c.Id,
                                    MenuItemId = c.MenuItemId,
                                    TransactionId= c.TransactionId
                                }
                                );
                return query.ToArray();
            }
        }

        public TransactionMenuItemDetail GetTransactionMenuItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TransactionMenuItems
                        .Single(c => c.Id == id);
                return
                    new TransactionMenuItemDetail
                    {
                        Id = entity.Id,
                        MenuItemId = entity.MenuItemId,
                        TransactionId = entity.TransactionId
                    };
            }
        }

        public bool UpdateTransactionMenuItem(TransactionMenuItemEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TransactionMenuItems
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.MenuItemId = model.MenuItemId;
                entity.TransactionId = model.TransactionId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransactionMenuItem(int transactionMenuItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TransactionMenuItems
                        .Single(e => e.Id == transactionMenuItemId);

                ctx.TransactionMenuItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
