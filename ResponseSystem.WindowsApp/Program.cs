using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResponseSystem.Business;

namespace ResponseSystem.WindowsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
            
             .ConfigureServices((context, services) =>
             {
                 ConfigureServices(context.Configuration, services);
             })
             .ConfigureLogging(logging =>
             {
                 // Add other loggers...
             })
             .Build();

            var services = host.Services;
            var mainForm = services.GetRequiredService<ParseResponse>();
            Application.Run(mainForm);
        }
        private static void ConfigureServices(IConfiguration configuration,
    IServiceCollection services)
        {

            services.AddSingleton<IUtility, Utility>();
            services.AddSingleton<IResponseDetails, ResponseDetails>();
            services.AddSingleton<ParseResponse>();
        }
    }
}