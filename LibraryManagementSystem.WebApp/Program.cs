using LibraryManagementSystem.Repository.Extensions;
using LibraryManagementSystem.Service.Extensions;
using LibraryManagementSystem.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelMetadataDetailsProviders.Clear(); // DataAnnotations validasyonlarini devre disi birakir
}).AddJsonOptions(options =>{options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;}); // Ýliskili entitylerde loopu onler

builder.Services.AddMemoryCache();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);//default hata mesajlari
builder.Services.AddMyFilterExt(builder.Configuration);
builder.Services.AddEfCoreExt(builder.Configuration).AddMappingExt(builder.Configuration).AddFluentExt(builder.Configuration);
builder.Services.AddRepoExt(builder.Configuration).AddServicesExt(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCustomMiddlewares();

app.UseAuthorization();
app.UseMyRoutes();

app.Run();
