using ReGrill.API.Recipes.Domain.Model.Commands;
using ReGrill.API.Recipes.Interfaces.REST.Resources;

namespace ReGrill.API.Recipes.Interfaces.REST.Transform;

public static class DeleteRecipeCommandFromResourceAssembler

    {
        public static DeleteRecipeCommand ToCommandFromResource(DeleteRecipeResource resource)
        {
            return new DeleteRecipeCommand(resource.Id);
        }
    }
