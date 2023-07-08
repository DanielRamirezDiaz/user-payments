using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Name)
        .HasMaxLength(50)
        .IsRequired();
      
      builder.Property(x => x.Lastname)
        .HasMaxLength(50)
        .IsRequired();
      
      builder.Property(x => x.Email)
        .HasMaxLength(150)
        .IsRequired();

      builder.HasData(new User
      {
        Id = 1,
        Email = "DanielRamirezDiaz@outlook.com",
        Lastname = "Ramírez",
        Name = "Daniel"
      });
    }
  }
}
