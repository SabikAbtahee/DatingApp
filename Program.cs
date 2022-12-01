using DatingApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options=>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(builder=>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://datingapp.com:4210"));
app.MapControllers();

app.Run();
