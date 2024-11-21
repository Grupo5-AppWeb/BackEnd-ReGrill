using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ReGrill.API.Recipes.Domain.Model.Queries;
using ReGrill.API.Recipes.Domain.Services;
using ReGrill.API.Recipes.Interfaces.REST.Resources;
using ReGrill.API.Recipes.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace ReGrill.API.Recipes.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Recipe Endpoints")]
public class RecipeController(IRecipeCommandService recipeCommandService, IRecipeQueryService recipeQueryService): ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create Recipe", "Create new recipe.", OperationId = "CreateRecipe")]
    [SwaggerResponse(201, "Recipe created successfully.", typeof(RecipeResource))]
    [SwaggerResponse(400, "The recipe was not created")]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeResource resource)
    {
        var createRecipeCommand = CreateRecipeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await recipeCommandService.Handle(createRecipeCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetRecipeById), new { id = result.Id }, RecipeResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation("Get Recipe", "Get recipe by id.", OperationId = "GetRecipeById")]
    [SwaggerResponse(200, "Order found.", typeof(RecipeResource))]
    [SwaggerResponse(404, "Order not found.")]
    public async Task<IActionResult> GetRecipeById(int id)
    {
        var getRecipeByIdQuery = new GetRecipeByIdQuery(id);
        var result = await recipeQueryService.Handle(getRecipeByIdQuery);
        if (result is null) return NotFound();
        var resource = RecipeResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpDelete("{recipeId:int}")]
    [SwaggerOperation(
        Summary = "Delete Recipe",
        Description = "Delete an recipe",
        OperationId = "DeleteRecipe")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The recipe was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The recipe was not found")]
    public async Task<IActionResult> DeleteRecipe(int recipeId)
    {
        var resource = new DeleteRecipeResource(recipeId);
        var deleteRecipeCommand = DeleteRecipeCommandFromResourceAssembler.ToCommandFromResource(resource);
        await recipeCommandService.Handle(deleteRecipeCommand);
        return NoContent();
    }

    
    [HttpGet]
    [SwaggerOperation("Get All Recipes", "Get all recipes.", OperationId = "GetAllRecipes")]
    [SwaggerResponse(200, "Orders found.", typeof(IEnumerable<RecipeResource>))]
    [SwaggerResponse(404, "Orders not found.")]
    public async Task<IActionResult> GetAllRecipes()
    {
        var getAllRecipesQuery = new GetAllRecipesQuery();
        var recipes = await recipeQueryService.Handle(getAllRecipesQuery);
        var recipesResource = recipes.Select(RecipeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(recipesResource);
    }

    /*[HttpDelete("{orderId:int}")]
    [SwaggerOperation(
        Summary = "Delete Order",
        Description = "Delete an order",
        OperationId = "DeleteOrder")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The Order was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Order was not found")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        var resource = new DeleteOrderResource(orderId);
        var deleteOrderCommand = DeleteOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        await orderCommandService.Handle(deleteOrderCommand);
        return NoContent();
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update the order",
        Description = "Update an specified order",
        OperationId = "UpdateOrder")]
    [SwaggerResponse(StatusCodes.Status200OK, Description = "The Order was updated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Bad request")]
    [SwaggerResponse(StatusCodes.Status404NotFound, Description = "Order was not found")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderResource resource)
    {
        if (id <= 0)
            return BadRequest("Invalid resource data");
        var updateOrderCommand = UpdateOrderCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await orderCommandService.Handle(updateOrderCommand);
        if (result == null)
            return NotFound("The order was not found");
        var updatedResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(updatedResource);
    }*/
}