using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class MenuItemService
    {
        private readonly Guid _userId;

        public MenuItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMenuItem(MenuItemCreate model)
        {
            var entity =
                new MenuItem()
                {
                    RecipeId = model.RecipeId,
                    Price = model.Price,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MenuItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MenuItemListItem> GetMenuItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MenuItems
                        .Select(
                            c =>
                                new MenuItemListItem
                                {
                                    Id = c.Id,
                                    Name = c.Recipe.Name,
                                    Price = c.Price
                                }
                                );
                return query.ToArray();
            }
        }

        public MenuItemDetail GetMenuItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(c => c.Id == id);
                return
                    new MenuItemDetail
                    {
                        Id = entity.Id,
                        Name = entity.Recipe.Name,
                        Price = entity.Price,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateMenuItem(MenuItemEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.Id == model.Id);

                entity.RecipeId = model.RecipeId;
                entity.Price = model.Price;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMenuItem(int menuItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.Id == menuItemId);

                ctx.MenuItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
