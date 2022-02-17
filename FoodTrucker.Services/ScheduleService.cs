using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class ScheduleService
    {
        private readonly Guid _userId;

        public ScheduleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSchedule(ScheduleCreate model)
        {
            var entity =
                new Schedule()
                {
                    Date = model.Date,
                    LocationId = model.LocationId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schedules.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ScheduleListItem> GetSchedules()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Schedules
                        .Select(
                            c =>
                                new ScheduleListItem
                                {
                                    Id = c.Id,
                                    Date = c.Date,
                                }
                                );
                return query.ToArray();
            }
        }

        public ScheduleDetail GetScheduleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schedules
                        .Single(c => c.Id == id);
                return
                    new ScheduleDetail
                    {
                        Id = entity.Id,
                        Date = entity.Date,
                        LocationId = entity.LocationId
                    };
            }
        }

        public bool UpdateSchedule(ScheduleEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schedules
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Date = model.Date;
                entity.LocationId = model.LocationId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSchedule(int scheduleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Schedules
                        .Single(e => e.Id == scheduleId);

                ctx.Schedules.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
