using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
  public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
  {
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Ammount)
        .HasPrecision(2)
        .IsRequired();

      builder.Property(x => x.Date)
        .HasDefaultValueSql("GETDATE()")
        .IsRequired();

      builder.HasOne(x => x.UserBusiness)
        .WithMany(x => x.Payments)
        .HasForeignKey(x => x.UserBusinessId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired();
    }
  }
}
