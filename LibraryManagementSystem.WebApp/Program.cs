using FluentValidation.AspNetCore;
using FluentValidation;
using LibraryManagementSystem.WebApp.Repository;
using LibraryManagementSystem.WebApp.Services;
using LibraryManagementSystem.WebApp.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Clear(); // DataAnnotations validasyonlarýný devre dýþý býrakýr
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookViewModelValidator>();


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
