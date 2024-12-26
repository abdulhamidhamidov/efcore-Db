using System.Net;
using Domain.Entities;
using Infrastruckture.DataContexts;
using Infrastruckture.Interfaces;
using Infrastruckture.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastruckture.Services;

public class ProductService(DataContext context): IProductService
{
    public async Task<Response<string>> CreateProduct(Product product)
    {
         await context.Products.AddAsync(product);
         var res = await context.SaveChangesAsync();
         if (res == 0)
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Service Error");
         return new Response<string>("Product create succcessfully");
    }
    public async Task<Response<List<Product>>> GetProducts()
    {
        var res = await context.Products.ToListAsync();
        if (res.Count == 0)
            return new Response<List<Product>>(HttpStatusCode.NotFound,"Products not found");
        return new Response<List<Product>>(res);
    }

    public async Task<Response<Product>> GetById(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        if (product == null) return new Response<Product>(HttpStatusCode.NotFound,"Product not found");
        return new Response<Product>(product);
    }
    public async Task<Response<string>> UpdateProduct(Product product)
    {
        var product1 = await context.Products.FirstOrDefaultAsync(x=>x.Id==product.Id);
        if(product1==null)return new Response<string>(HttpStatusCode.NotFound,"Product not found");
        product1.Category = product.Category;
        product1.Name = product.Name;
        product1.Price = product.Price;
        var res = await context.SaveChangesAsync();
        if (res == 0)
            return new Response<string>(HttpStatusCode.InternalServerError,"Product not updated");
        return new Response<string>("Updated");

    }

    public async Task<Response<string>> DeleteProduct(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) return new Response<string>(HttpStatusCode.NotFound,"Product not found");
        context.Remove(product);
        var res = await context.SaveChangesAsync();
        if (res == 0)
            return new Response<string>(HttpStatusCode.InternalServerError,"Product not delete");
        return new Response<string>("Deleted12 edc");
    }
}