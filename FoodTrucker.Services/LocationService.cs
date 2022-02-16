using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    Address = model.Address,
                    Neighborhood = model.Neighborhood,
                    LocationType = model.LocationType,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Select(
                            c =>
                                new LocationListItem
                                {
                                    Id = c.Id,
                                    Address = c.Address
                                }
                                );
                return query.ToArray();
            }
        }

        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(c => c.Id == id);
                return
                    new LocationDetail
                    {
                        Id = entity.Id,
                        Address = entity.Address,
                        Neighborhood = entity.Neighborhood,
                        LocationType = entity.LocationType
                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.Id == model.Id);

                entity.Address = model.Address;
                entity.Neighborhood = model.Neighborhood;
                entity.LocationType = model.LocationType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.Id == locationId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
