using Microsoft.EntityFrameworkCore;
using WebPizzeria.Core.Entities;
using WebPizzeria.DataAccess.Configurations;

namespace WebPizzeria.DataAccess;

public class PizzaDbContext : DbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<UserEntity>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<CartEntity>(new CartConfiguration());
        modelBuilder.ApplyConfiguration<OrderEntity>(new OrderConfiguration());
        modelBuilder.ApplyConfiguration<PizzaEntity>(new PizzaConfiguration());
        modelBuilder.ApplyConfiguration<IngredientEntity>(new IngredientConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<PizzaEntity> Pizzas { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
}