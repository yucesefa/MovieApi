using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRS.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRS.Handlers.UserRegisterHandlers;
using MovieApi.Application.Features.Mediator.Handlers.TagHandlers;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovieContext>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();

builder.Services.AddScoped<CreateUserRegisterCommandHandler>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>(); // Identity ile kullanýcý yönetimi için gerekli servisleri ekler

// hata verdi çünkü onion mimaride handlerin olduðu katmanýn assembly referansýna ihtiyaç duyar bu satýr bu yüzden çalýþmaz
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // IRequestHandler'leri implemente eden handlerlarý otomatik olarak bulur ve register eder.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly)); 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieApi.WebApi", Version = "v1" });
});
var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieApi.WebApi v1"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

