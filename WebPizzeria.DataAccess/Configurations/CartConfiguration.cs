using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
{
    public void Configure(EntityTypeBuilder<CartEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.User)
            .WithMany(u => u.Carts)
            .HasForeignKey(c => c.UserId);

        builder.HasMany(c => c.Pizzas)
            .WithMany(p => p.Carts);

        builder.HasOne(c => c.Order)
            .WithOne(o => o.Cart)
            .HasForeignKey<CartEntity>(c => c.OrderId);

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);
    }
}
