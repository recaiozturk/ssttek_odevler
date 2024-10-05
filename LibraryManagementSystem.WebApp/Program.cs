using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using LibraryManagementSystem.WebApp.Books.Repository;
using LibraryManagementSystem.WebApp.Books.Services;
using LibraryManagementSystem.WebApp.Books.Validators;
using LibraryManagementSystem.WebApp.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.WebApp.Authors.Repository;
using LibraryManagementSystem.WebApp.Authors.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlSever");
    x.UseSqlServer(connectionString);
});

builder.Services.AddControllersWithViews(options =>
{
    options.ModelMetadataDetailsProviders.Clear(); // DataAnnotations validasyonlarini devre disi birakir
});

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    /*options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;*/ //Ýliskili entitylerde loopu onler
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookViewModelValidator>();

builder.Services.AddScoped<IBookInMemoryRepository, BookInMemoryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
