using Microsoft.Extensions.DependencyInjection;
using System;

namespace UserPayments.Extensions
{
  public static class CustomServiceCollectionExtensions
  {
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      return services;
    }
  }
}
