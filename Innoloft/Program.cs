using Infrastructure;
using Application;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interface;
using Infrastructure.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration, builder.Environment);
builder.Services.AddDbContext<InnoloftContext>(
    option =>
    {
        option.UseNpgsql(builder.Configuration.GetConnectionString("Database"));

    });
builder.Services.AddScoped<ICurrentUser, CurrentUserService>();

builder.Services.AddAuthentication("Identity.Application")
    .AddCookie("Identity.Application", option =>
    {
        option.SlidingExpiration = true;
        option.Cookie.Name = "Innoloft_Cookie";
        option.ExpireTimeSpan = TimeSpan.FromDays(7);
    });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<InnoloftContext>();
        db.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
