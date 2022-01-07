using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Helicopter.API.Services.Abstractions;
using Helicopter.DAL;

namespace Helicopter.API.Services.ServiceInstallers
{
    public class DbInstaller: IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly("Helicopter.DAL"));
            });
        }
    }
}
