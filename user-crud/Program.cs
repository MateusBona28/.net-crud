using User.Data;
using Microsoft.EntityFrameworkCore;
using User.Repositories.Interfaces;
using User.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<UserDbContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

#region [Cors]

builder.Services.AddCors();

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors => {
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
