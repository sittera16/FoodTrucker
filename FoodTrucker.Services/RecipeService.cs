using FoodTrucker.Data;
using FoodTrucker.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucker.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    Name = model.Name,
                    Instructions = model.Instructions,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Select(
                            c =>
                                new RecipeListItem
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Ingredients = c.RecipeIngredients.Select(r => r.Ingredient.Name ).ToList(),
                                }
                                );
                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(c => c.Id == id);
                return
                    new RecipeDetail
                    {
                        Id = entity.Id,
                        Name=entity.Name,
                        Instructions = entity.Instructions,
                        Ingredients = entity.RecipeIngredients.Select(r => r.Ingredient.Name).ToList(),
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Instructions = model.Instructions;

                return ctx.SaveChanges() >0;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.Id == recipeId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
