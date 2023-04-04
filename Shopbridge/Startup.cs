using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopbridge.Data;
using Shopbridge.Data.Repository;
using Shopbridge.Data.Repository.Interface;
using Shopbridge.Domain.GlobalErrorHandling;

namespace Shopbridge
{
    public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("InventoryDB")));
      services.AddTransient<IInventoryRepository, InventoryRepository>();
      services.AddAutoMapper(typeof(Startup));
      var serviceProvider = services.BuildServiceProvider();
      var logger = serviceProvider.GetService<ILogger<InventoryRepository>>();
      services.AddSingleton(typeof(ILogger), logger);
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //app.ConfigureExceptionHandler(logger);

      app.ConfigureCustomExceptionMiddleware();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
