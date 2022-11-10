

using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Data.Entities;
using TestWebAPI.Repositories.Implements;
using TestWebAPI.Repositories.Interfaces;
using TestWebAPI.Services.Implements;
using TestWebAPI.Services.Interfaces;

//using TestWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookBorrowingRequestRepository, BookBorrowingRequestRepository>();
builder.Services.AddTransient<IBookBorrowingRequestService, BookBorrowingRequestService>();
builder.Services.AddTransient<IBookBorrowingRequestDetailRepository, BookBorrowingRequestDetailRepository>();
builder.Services.AddTransient<IBookBorrowingRequestDetailService, BookBorrowingRequestDetailService>();

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
