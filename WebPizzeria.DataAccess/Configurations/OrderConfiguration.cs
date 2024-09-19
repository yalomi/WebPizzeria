using Microsoft.EntityFrameworkCore;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.Cart)
            .WithOne(c => c.Order)
            .HasForeignKey<OrderEntity>(o => o.CartId);

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
    }
}
