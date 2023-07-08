using Arch.EntityFrameworkCore.UnitOfWork;
using Data.Context;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddDataLayerDependencies(this IServiceCollection services, string connectionString)
    {
      services
        .AddDbContext<UserPaymentsDbContext>(opt => opt.UseSqlServer(connectionString))
        .AddUnitOfWork<UserPaymentsDbContext>();

      services.AddScoped<IUserRepository, CustomUserRepository>();

      return services;
    }
  }
}
