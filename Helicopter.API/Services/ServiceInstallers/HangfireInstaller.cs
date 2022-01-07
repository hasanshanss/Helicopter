//using Hangfire;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Helicopter.API.Services.Abstractions;

//namespace Helicopter.API.Services.ServiceInstallers
//{
//    public class HangfireInstaller : IServiceInstaller
//    {
//        public void InstallServices(IServiceCollection services, IConfiguration configuration)
//        {
//            services.AddHangfire(x => x.UseDefaultTypeSerializer()
//                                       .UseSqlServerStorage(configuration.GetConnectionString("Default")));
//            services.AddHangfireServer();
//        }
//    }
//}
