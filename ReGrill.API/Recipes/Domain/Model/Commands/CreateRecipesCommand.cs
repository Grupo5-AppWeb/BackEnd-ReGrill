using ReGrill.API.Recipes.Domain.Model.Aggregates;

namespace ReGrill.API.Recipes.Domain.Model.Commands;

public record CreateRecipesCommand(string Name, string Category, string Description, List<Ingredient> Ingredients);