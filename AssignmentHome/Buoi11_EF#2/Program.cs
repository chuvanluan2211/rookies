using Buoi11_EF_2.Models;
using Buoi11_EF_2.Services;
using Buoi11_EF_2.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringDB")));
builder.Services.AddScoped<IProductRepository , ProductRepository>();
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
