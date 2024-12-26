using Domain.Entities;
using Infrastruckture.Interfaces;
using Infrastruckture.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateProduct(Product product)
    {
        return await productService.CreateProduct(product);
    }
    [HttpGet]
    public async Task<Response<List<Product>>> GetProducts()
    {
        return await productService.GetProducts();
    }
    [HttpGet("/by-Id")]
    public async Task<Response<Product>> GetById(int id)
    {
        return await productService.GetById(id);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateProduct(Product product)
    {
        return await productService.UpdateProduct(product);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteProduct(int id)
    {
        return await productService.DeleteProduct(id);
    }
}