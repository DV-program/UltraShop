using Ultra.Api.Services;
using Microsoft.EntityFrameworkCore;
using Ultra.Api.Data;
using Ultra.Api.Repositories;
using Ultra.Api.Middleware;
using Mapster;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>(); // Scoped - один объект на один http запрос, singltone - один раз при запуске, transient - каждый раз новый при каждом запросе.  
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);
builder.Services.AddMapster();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
