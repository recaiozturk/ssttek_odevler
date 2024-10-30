using Sample.Api.Models.Repositories;
using Sample.Api.Models.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddKeyedScoped<GameService>("GameService");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
