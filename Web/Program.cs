using App;
using Data;
using Microsoft.EntityFrameworkCore;
using Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ItemService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddSingleton<IItemRepository, ItemRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<Dictionary<Type, StoreDbContext>>();
builder.Services.AddSingleton<DbContextFactory>();

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