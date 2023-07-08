
using IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UserPayments.Extensions;
using UserPayments.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddControllersWithViews(x =>
  {
    x.Filters.Add<ExceptionFilter>();
    x.Filters.Add<ResultFilter>();
  })
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
  });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Host.ConfigureAppConfiguration((context, configuration) =>
{
  var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

  configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
});

DependencyContainer.RegisterServices(builder.Services, builder.Configuration.GetConnectionString("UserPaymentsDbConnection"));
CustomServiceCollectionExtensions.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Local"))
{
  app.UseDeveloperExceptionPage();
}
else
{
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpointBuilder =>
{
  app.MapControllers();
});

if (app.Environment.IsEnvironment("Local"))
{
  app.UseWhen(c => !c.Request.Path.StartsWithSegments(new PathString("/api")), app =>
  {
    app.UseSpa(spa =>
    {
      spa.UseProxyToSpaDevelopmentServer("https://localhost:3000");
    });
  });
}
else
{
  app.MapFallbackToFile("index.html");
}

app.Run();
