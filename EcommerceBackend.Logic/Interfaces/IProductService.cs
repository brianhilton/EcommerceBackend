using EcommerceBackend.Common.Dto;
using EcommerceBackend.Data.Models;
using EcommerceBackend.Data.Repository;

namespace EcommerceBackend.Logic.Interfaces;

public interface IProductService
{
    Task<ProductDto?> CreateProduct(Product product);
    Task<List<ProductDto>> GetProducts();
    Task<ProductDto?> GetProduct(int id);
}