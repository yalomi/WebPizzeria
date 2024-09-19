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
        modelBuilder.ApplyConfiguration<PizzaEntity>(new PizzaConfiguration());
        modelBuilder.ApplyConfiguration<IngredientEntity>(new IngredientConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<PizzaEntity> Pizzas { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
}
