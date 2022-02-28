using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class RecipeIngredientService
    {
        private readonly Guid _userId;

        public RecipeIngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipeIngredient(RecipeIngredientCreate model)
        {
            var entity =
                new RecipeIngredient()
                {
                    IngredientId = model.IngredientId,
                    RecipeId = model.RecipeId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RecipeIngredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeIngredientListItem> GetRecipeIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RecipeIngredients
                        .Select(
                            c =>
                                new RecipeIngredientListItem
                                {
                                    Id = c.Id,
                                    IngredientName = c.Ingredient.Name,
                                    RecipeName = c.Recipe.Name,
                                }
                                );
                return query.ToArray();
            }
        }

        public RecipeIngredientDetail GetRecipeIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RecipeIngredients
                        .Single(c => c.Id == id);
                return
                    new RecipeIngredientDetail
                    {
                        Id = entity.Id,
                        IngredientName = entity.Ingredient.Name,
                        RecipeName = entity.Recipe.Name
                    };
            }
        }

        public bool UpdateRecipeIngredient(RecipeIngredientEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RecipeIngredients
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.IngredientId = model.IngredientId;
                entity.RecipeId = model.RecipeId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipeIngredient(int recipeIngredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RecipeIngredients
                        .Single(e => e.Id == recipeIngredientId);

                ctx.RecipeIngredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
