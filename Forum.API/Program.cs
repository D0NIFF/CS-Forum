using Forum.Application.Interfaces.Repositories;
using Forum.Application.Interfaces.Services;
using Forum.Application.Services;
using Forum.Infrastructure;
using Forum.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forum.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IUsersService, UsersService>();

        builder.Services.AddScoped<IPostCategoriesRepository, PostCategoriesRepository>();
        builder.Services.AddScoped<IPostCategoriesService, PostCategoriesService>();

        builder.Services.AddDbContext<ForumDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    }
}
