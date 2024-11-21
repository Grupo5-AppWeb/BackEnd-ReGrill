namespace ReGrill.API.Recipes.Interfaces.REST.Resources;

public record CreateRecipeResource (string Name, string Category, string Description, 
    List<IngredientsResource> Ingredients, string Image);