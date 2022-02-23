using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;

        public IngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    Name = model.Name,
                    QuantityInStock = model.QuantityInStock,
                    IngredientType = model.IngredientType,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Select(
                            c =>
                                new IngredientListItem
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    QuantityInStock = c.QuantityInStock,
                                }
                                );
                return query.ToArray();
            }
        }

        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(c => c.Id == id);
                return
                    new IngredientDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        QuantityInStock = entity.QuantityInStock,
                        IngredientType = entity.IngredientType
                    };
            }
        }

        public bool UpdateIngredient(IngredientEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.QuantityInStock = model.QuantityInStock;
                entity.IngredientType = model.IngredientType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.Id == ingredientId);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
