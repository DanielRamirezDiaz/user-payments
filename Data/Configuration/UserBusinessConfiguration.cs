using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
  public class UserBusinessConfiguration : IEntityTypeConfiguration<UserBusiness>
  {
    public void Configure(EntityTypeBuilder<UserBusiness> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Name)
        .HasMaxLength(50)
        .IsRequired();

      builder.Property(x => x.Description)
        .HasMaxLength(250);

      builder.HasOne(x => x.User)
        .WithMany(x => x.UserBusinesses)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired();

      builder.HasData(new UserBusiness
      {
        Id = 1,
        Name = "Spotify",
        Description = "Online Music Streaming Service",
        UserId = 1
      });
      builder.HasData(new UserBusiness
      {
        Id = 2,
        Name = "Amazon Prime",
        Description = "Small Ecommerce Site Subscription",
        UserId = 1
      });
      builder.HasData(new UserBusiness
      {
        Id = 3,
        Name = "CFE",
        Description = "Power Company",
        UserId = 1
      });
    }
  }
}
