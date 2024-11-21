using ReGrill.API.Recipes.Domain.Model.Aggregates;
using ReGrill.API.Recipes.Domain.Model.Queries;

namespace ReGrill.API.Recipes.Domain.Services;

public interface IRecipeQueryService
{
    Task<IEnumerable<Recipe>> Handle(GetAllRecipesQuery query);
    Task<Recipe?> Handle(GetRecipeByIdQuery query);
}