using ReGrill.API.Recipes.Domain.Model.Aggregates;
using ReGrill.API.Recipes.Domain.Model.Commands;
using ReGrill.API.Recipes.Interfaces.REST.Resources;

namespace ReGrill.API.Recipes.Interfaces.REST.Transform;

public static class CreateRecipeCommandFromResourceAssembler
{
    public static CreateRecipesCommand ToCommandFromResource(CreateRecipeResource resource)
    {
        var ingredients = resource.Ingredients.Select(i => new Ingredient
        {
            Name = i.Name,
            Quantity = i.Quantity,
            Cost = i.Cost
        }).ToList();
        return new CreateRecipesCommand(resource.Name, resource.Category, resource.Description,
            ingredients);
    }
}