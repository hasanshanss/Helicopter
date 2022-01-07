using Helicopter.API.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Helicopter.API.Services.ServiceInstallers
{
    public class ApiVersioningInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = ApiVersion.Default;
            });
        }
    }
}
