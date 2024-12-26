using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastruckture.DataContexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}