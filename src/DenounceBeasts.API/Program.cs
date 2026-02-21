using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDataContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionx")));
    //o.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnectionx")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddAutoMapper(cfg =>
{
    // Registrar el perfil manualmente (opcional):
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly /* escanear automát. perfiles en el assembly */);

//var automapperLicence = builder.Configuration.GetSection("KeysConfigurations:AutomapperLicenceKey").Value;
//var automapperLicence2 = builder.Configuration.GetSection("AutomapperLicenceKey").Value;
//
//builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = automapperLicence, typeof(MappingProfile));



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
