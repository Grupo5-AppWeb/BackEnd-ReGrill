using Microsoft.EntityFrameworkCore;
using ReGrill.API.Recipes.Domain.Model.Aggregates;
using ReGrill.API.Recipes.Domain.Model.Queries;
using ReGrill.API.Recipes.Domain.Repositories;
using ReGrill.API.Recipes.Domain.Services;

namespace ReGrill.API.Recipes.Application.Internal.QueryServices;

public class RecipeQueryService(IRecipeRepository recipeRepository): IRecipeQueryService
{
    public async Task<IEnumerable<Recipe>> Handle(GetAllRecipesQuery query)
    {
        return await recipeRepository
            .GetAll()
            .Include(r => r.Ingredients)
            .ToListAsync();
    }
    
    public async Task<Recipe?> Handle(GetRecipeByIdQuery query)
    {
        return await recipeRepository.FindByIdAsync((int)query.RecipeId);
    }
}