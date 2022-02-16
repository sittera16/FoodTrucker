using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    BirthDate = model.BirthDate,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Select(
                            c =>
                                new CustomerListItem
                                {
                                    Id = c.Id,
                                    FullName = c.FullName,
                                }
                                );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(c => c.Id == id);
                return
                    new CustomerDetail
                    {
                        Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        EmailAddress = entity.EmailAddress,
                        BirthDate = entity.BirthDate
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.EmailAddress = model.EmailAddress;
                entity.BirthDate = model.BirthDate;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.Id == customerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
