using Infrastruckture.DataContexts;
using Infrastruckture.Interfaces;
using Infrastruckture.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options=>options.SwaggerEndpoint("/openapi/v1.json",""));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

