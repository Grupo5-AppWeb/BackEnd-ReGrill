using ReGrill.API.Shared.Domain.Repositories;
using ReGrill.API.Recipes.Domain.Model.Aggregates;

namespace ReGrill.API.Recipes.Domain.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{}