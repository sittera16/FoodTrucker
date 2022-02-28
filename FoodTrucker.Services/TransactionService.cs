using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    TransactionDate = DateTime.Now,
                    CustomerId = model.CustomerId,
                    TransactionMenuItemId = model.TransactionMenuItemId,
                    TotalPrice = model.TotalPrice,
                    LocationId = model.LocationId,
                    EmployeeId = model.EmployeeId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Select(
                            c =>
                                new TransactionListItem
                                {
                                    Id = c.Id,
                                    TransactionDate = c.TransactionDate,
                                    TotalPrice = c.TotalPrice,
                                }
                                );
                return query.ToArray();
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(c => c.Id == id);
                return
                    new TransactionDetail
                    {
                        Id = entity.Id,
                        TransactionDate = entity.TransactionDate,
                        CustomerId = entity.CustomerId,
                        MenuItems = entity.TransactionMenuItems.Select(t => t.MenuItem.Recipe.Name).ToList(),
                        TotalPrice = entity.TotalPrice,
                        LocationId = entity.LocationId,
                        EmployeeId = entity.EmployeeId,
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.TransactionDate = model.TransactionDate;
                entity.CustomerId = model.CustomerId;
                entity.TotalPrice = model.TotalPrice;
                entity.LocationId = model.LocationId;
                entity.EmployeeId = model.EmployeeId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.Id == transactionId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
