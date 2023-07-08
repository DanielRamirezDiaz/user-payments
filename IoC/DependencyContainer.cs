using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Data.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
  public static class DependencyContainer
  {
    public static void RegisterServices(IServiceCollection services, string connectionString)
    {
      //BusinessLayer Services
      services.AddScoped<IUserService, UserService>();

      services.AddDataLayerDependencies(connectionString);
    }
  }
}
