using ReGrill.API.Recipes.Domain.Model.Commands;

namespace ReGrill.API.Recipes.Domain.Model.Aggregates;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public float Cost { get; set; }
    public int RecipeId { get; set; }
    public Ingredient(){}
}