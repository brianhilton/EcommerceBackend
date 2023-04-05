using EcommerceBackend.Data.Models;
using EcommerceBackend.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger _log;
    
    public ProductsController(IProductService productService, ILoggerFactory loggerFactory)
    {
        _productService = productService;
        _log = loggerFactory.CreateLogger<ProductsController>();
    }

    [HttpPost]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostProduct(Product product)
    {
        var response = await _productService.CreateProduct(product);

        return response == null ? BadRequest("bad request") : Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Product>), 200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetProducts()
    {
        var response = await _productService.GetProducts();

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetProduct(int id)
    {
        var response = await _productService.GetProduct(id);

        return response == null ? NotFound("not found") : Ok(response);
    }
}