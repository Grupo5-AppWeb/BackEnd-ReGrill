using ReGrill.API.Recipes.Domain.Model.Aggregates;
using ReGrill.API.Recipes.Domain.Model.Commands;

namespace ReGrill.API.Recipes.Domain.Services;

public interface IRecipeCommandService
{
    Task<Recipe?> Handle(CreateRecipesCommand command);

    //Task Handle(DeleteRecipeCommand command);

    //Task<Recipe?> Handle(UpdateRecipeCommand command);
}