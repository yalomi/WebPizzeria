using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<IngredientEntity>
{
    public void Configure(EntityTypeBuilder<IngredientEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(i => i.Pizza)
            .WithMany(p => p.Ingredients)
            .HasForeignKey(i => i.PizzaId);
    }
}


