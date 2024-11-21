using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ReGrill.API.Invoices.Domain.Model.Queries;
using ReGrill.API.Invoices.Domain.Services;
using ReGrill.API.Invoices.Interfaces.REST.Resources;
using ReGrill.API.Invoices.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace ReGrill.API.Invoices.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Invoice Endpoints")]
public class InvoicesController(IInvoiceCommandService invoiceCommandService, IInvoiceQueryService invoiceQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create Invoice", "Create new Invoice.", OperationId = "CreateInvoice")]
    [SwaggerResponse(201, "Invoice created successfully.", typeof(InvoiceResource))]
    [SwaggerResponse(400, "The Invoice was not created")]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceResource resource)
    {
        var createInvoiceCommand = CreateInvoiceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await invoiceCommandService.Handle(createInvoiceCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetInvoiceById), new { id = result.Id },
            InvoiceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get Invoice", "Get Invoice by id.", OperationId = "GetInvoice")]
    [SwaggerResponse(200, "Invoice found.", typeof(InvoiceResource))]
    [SwaggerResponse(404, "Invoice not found.")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var getInvoiceByIdQuery = new GetInvoicesByIdQuery(id);
        var result = await invoiceQueryService.Handle(getInvoiceByIdQuery);
        if (result is null) return NotFound();
        var resource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Invoices", "Get all Invoices.", OperationId = "GetAllInvoices")]
    [SwaggerResponse(200, "Invoices found.", typeof(IEnumerable<InvoiceResource>))]
    [SwaggerResponse(404, "Invoices not found.")]
    public async Task<IActionResult> GetAllInvoices()
    {
        var getAllInvoicesQuery = new GetAllInvoicesQuery();
        var invoices = await invoiceQueryService.Handle(getAllInvoicesQuery);
        var invoiceResources = invoices.Select(InvoiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(invoiceResources);
    }

}