using ReGrill.API.Recipes.Domain.Model.Commands;

namespace ReGrill.API.Recipes.Domain.Model.Aggregates;

public class Recipe
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public string Description { get; private set; }
    public List<Ingredient> Ingredients { get; private set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
    }
    public Recipe(CreateRecipesCommand command)
    {
        Name = command.Name;
        Category = command.Category;
        Description = command.Description;
        Ingredients = command.Ingredients;
    }
}