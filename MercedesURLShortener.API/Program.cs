using FluentValidation.AspNetCore;
using MercedesURLShortener.Core.ControllerHelpers;
using MercedesURLShortener.Core.IControllerHelpers;
using MercedesURLShortener.Core.IRepositories;
using MercedesURLShortener.Core.IServices;
using MercedesURLShortener.Core.IUnitOfWorks;
using MercedesURLShortener.Repository;
using MercedesURLShortener.Repository.Repositories;
using MercedesURLShortener.Repository.Repostories;
using MercedesURLShortener.Repository.UnitOfWorks;
using MercedesURLShortener.Service.Mapping;
using MercedesURLShortener.Service.Services;
using MercedesURLShortener.Service.Validations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblyContaining<UrlDtoValidator>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IServices<>), typeof(Service<>));
builder.Services.AddScoped(typeof(IUrlService), typeof(UrlService));
builder.Services.AddScoped(typeof(IUrlRepository), typeof(UrlRepository));
builder.Services.AddScoped(typeof(IUrlControllerHelper), typeof(UrlControllerHelper));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


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