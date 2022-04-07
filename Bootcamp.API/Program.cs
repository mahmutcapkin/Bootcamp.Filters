using Bootcamp.API.Filters;
using Bootcamp.API.Repositories;
using Bootcamp.API.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(option => option.Filters.Add(new ValidateFilter())).AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(option =>
{

    option.SuppressModelStateInvalidFilter = true;
});


builder.Services.AddScoped<NotFoundMovieFilter>();
builder.Services.AddScoped<CacheResourceFilter>();
builder.Services.AddScoped<CustomAuthorizationFilter>(container =>
{
    
    return new CustomAuthorizationFilter("127.0.0.1;::1");
    //return new CustomAuthorizationFilter("129.0.0.1");

});
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
