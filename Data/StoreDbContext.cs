using Microsoft.EntityFrameworkCore;
using Store.Data;

namespace Data;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<ItemData> Items { get; set; }
    public DbSet<OrderData> Orders { get; set; }
    public DbSet<OrderItemData> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        BuildItems(modelBuilder);
        BuildOrders(modelBuilder);
        BuildItemsData(modelBuilder);
    }

    private void BuildItemsData(ModelBuilder modelBuilder)
    {
        var configuration = modelBuilder.Entity<OrderItemData>();

        configuration.Property(data => data.Price).HasColumnType("money");
    }

    private void BuildOrders(ModelBuilder modelBuilder)
    {
        var configuration = modelBuilder.Entity<OrderData>();
        
        configuration.Property(data => data.TotalPrice).HasColumnType("money");
    }

    private static void BuildItems(ModelBuilder modelBuilder)
    {
        var configuration = modelBuilder.Entity<ItemData>();
        configuration.Property(data => data.Title).IsRequired();
        configuration.Property(data => data.Price).HasColumnType("money");

        configuration.HasData(
            new ItemData
            {
                Id = 1,
                Title = "Крем от прыщей на жопе",
                Description = "Лучший крем в мире от прыщиков на прекрасной заднице",
                Price = 1271,
                Stock = 10000,
                AdultOnly = false
            },
            new ItemData
            {
                Id = 2,
                Title = "Куртка Драйв Райан Гослин тренд",
                Description = "Лучший выглядеть на районе, не умереть в конце",
                Price = 11000,
                Stock = 11,
                AdultOnly = false
            },
            new ItemData
            {
                Id = 3,
                Title = "Носок Папича, вонючий немного",
                Description = "Забрали когда штурмовали его хату",
                Price = 100000000,
                Stock = 1,
                AdultOnly = false
            }
        );
    }
}