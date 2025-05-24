using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Core.Interfaces;
using UESAN.Ecommerce.CORE.Core.Services;
using UESAN.Ecommerce.CORE.Infrastructure.Data;
using UESAN.Ecommerce.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var _connectionString = _configuration
                        .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(_connectionString));
//TODO: Add interfaces
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddTransient<IFavoriteService, FavoriteService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
