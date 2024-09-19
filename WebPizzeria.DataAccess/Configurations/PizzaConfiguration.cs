using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Configurations;

public class PizzaConfiguration : IEntityTypeConfiguration<PizzaEntity>
{
    public void Configure(EntityTypeBuilder<PizzaEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Carts)
            .WithMany(c => c.Pizzas);

        builder.HasMany(p => p.Ingredients)
            .WithMany(i => i.Pizzas);
    }
}


