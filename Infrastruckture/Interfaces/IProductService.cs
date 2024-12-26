using Domain.Entities;
using Infrastruckture.Responses;

namespace Infrastruckture.Interfaces;

public interface IProductService
{
    public Task<Response<string>> CreateProduct(Product product);
    public Task<Response<List<Product>>> GetProducts();
    public Task<Response<Product>> GetById(int id);
    public Task<Response<string>> UpdateProduct(Product product);
    public Task<Response<string>> DeleteProduct(int id);

}