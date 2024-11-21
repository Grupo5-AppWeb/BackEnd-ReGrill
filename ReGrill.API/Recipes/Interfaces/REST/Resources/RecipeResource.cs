namespace ReGrill.API.Recipes.Interfaces.REST.Resources;

public record RecipeResource (long Id, string Name, string Category, string Description, 
    List<IngredientsResource> Ingredients, string Image) ;