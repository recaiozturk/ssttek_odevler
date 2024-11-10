using LibraryManagementSystem.Membership.Api.Extensions;
using LibraryManagementSystem.Repository.Extensions;
using LibraryManagementSystem.Service.Roles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Clear(); // DataAnnotations validasyonlarini devre disi birakir
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEfCoreExt(builder.Configuration);
builder.Services.AddScoped<IRoleService, RoleService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerExt();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
