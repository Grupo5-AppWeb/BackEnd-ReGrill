using ReGrill.API.Recipes.Domain.Model.Aggregates;
using ReGrill.API.Recipes.Interfaces.REST.Resources;

namespace ReGrill.API.Recipes.Interfaces.REST.Transform;

public static class RecipeResourceFromEntityAssembler
{
    public static RecipeResource ToResourceFromEntity(Recipe recipe)
    {
        var ingredients = recipe.Ingredients.Select(i => new IngredientsResource
        (i.Name, i.Quantity, i.Cost)).ToList();
        return new RecipeResource(recipe.Id, recipe.Name, recipe.Category, recipe.Description,
            ingredients);
    }
}