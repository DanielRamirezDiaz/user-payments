using Data.Configuration;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
  public class UserPaymentsDbContext : DbContext
  {
    public UserPaymentsDbContext(DbContextOptions<UserPaymentsDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserBusiness> UserBusinesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new PaymentConfiguration());
      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new UserBusinessConfiguration());

      base.OnModelCreating(modelBuilder);
    }
  }
}
