using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    HireDate = model.HireDate,
                    IsCurrentlyEmployeed = model.IsCurrentlyEmployeed,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Select(
                            c =>
                                new EmployeeListItem
                                {
                                    Id = c.Id,
                                    LastName = c.LastName,
                                    FirstName = c.FirstName,
                                }
                                );
                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(c => c.Id == id);
                return
                    new EmployeeDetail
                    {
                        Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        HireDate = entity.HireDate,
                        IsCurrentlyEmployeed = entity.IsCurrentlyEmployeed
                    };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.HireDate = model.HireDate;
                entity.IsCurrentlyEmployeed = model.IsCurrentlyEmployeed;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.Id == employeeId);

                ctx.Employees.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
