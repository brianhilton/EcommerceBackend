using EcommerceBackend.Common.Dto;
using EcommerceBackend.Data.Models;
using EcommerceBackend.Data.Repository;
using EcommerceBackend.Logic.Interfaces;
using Microsoft.Extensions.Logging;

namespace EcommerceBackend.Logic.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _repository;
    private readonly ILogger _log;
    
    public ProductService(IGenericRepository<Product> repository, ILoggerFactory loggerFactory)
    {
        _repository = repository;
        _log = loggerFactory.CreateLogger<ProductService>();
    }

    public async Task<ProductDto?> CreateProduct(Product product)
    {
        _repository.Insert(product);
        _repository.SaveChanges();
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Size = product.Size,
            OriginalPrice = product.OriginalPrice,
            Price = product.Price,
            Designer = product.Designer,
            ImageUrl = product.ImageUrl
        };
    }

    public async Task<List<ProductDto>> GetProducts()
    {
        var response = _repository.GetAll().ToList();
        return response.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Size = p.Size,
            OriginalPrice = p.OriginalPrice,
            Price = p.Price,
            Designer = p.Designer,
            ImageUrl = p.ImageUrl
        }).ToList();
    }

    public async Task<ProductDto?> GetProduct(int id)
    {
        var response = _repository.Single(id);
        return response == null ? null : new ProductDto
        {
            Id = response.Id,
            Name = response.Name,
            Description = response.Description,
            Size = response.Size,
            OriginalPrice = response.OriginalPrice,
            Price = response.Price,
            Designer = response.Designer,
            ImageUrl = response.ImageUrl
        };
    }
}