using Microsoft.EntityFrameworkCore;
using UserList.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InfrastructureDbContext>(options =>
    options.UseSqlServer("Server=LBFTT-23\\SQLEXPRESS;Database=UserDB;Trusted_Connection=True;TrustServerCertificate=True;",
        b => b.MigrationsAssembly("UserList.Infrastructure")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(option => option.LowercaseUrls = true);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
