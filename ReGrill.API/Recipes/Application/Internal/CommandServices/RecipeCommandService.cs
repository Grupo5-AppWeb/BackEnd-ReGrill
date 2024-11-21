using ReGrill.API.Recipes.Domain.Model.Aggregates;
using ReGrill.API.Recipes.Domain.Model.Commands;
using ReGrill.API.Recipes.Domain.Repositories;
using ReGrill.API.Recipes.Domain.Services;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Recipes.Application.Internal.CommandServices;

public class RecipeCommandService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork) : IRecipeCommandService
{
    public async Task<Recipe?> Handle(CreateRecipesCommand command)
    {
        
        var recipe = new Recipe(command);
        try
        {
            await recipeRepository.AddAsync(recipe);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return recipe;
    }

    /*public async Task Handle(DeleteOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.Id);
        if (order == null)
        {
            throw new ArgumentException("Order not found");
        }

        try
        {
            orderRepository.Remove(order);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error deleting order", e);
        }
    }

    public async Task<Order?> Handle(UpdateOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.Id);
        if (order == null)
            throw new ArgumentException("Order not found");
        try
        {
            orderRepository.Update(order);
            await unitOfWork.CompleteAsync();
            return order;
        }
        catch (Exception e)
        {
            throw new Exception("Error updating order", e);
        }
    }*/
}