using entities.Factory;
using entity_framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace wpf_ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((host_context, services) => 
                {
                    string db_connection_string = host_context.Configuration.GetConnectionString("Default");
                    services.AddSingleton<IToyStoreContextCreator>(new ToyStoreDbContextCreator(db_connection_string));
                }).Build();

            var contextCreator = _host.Services.GetRequiredService<IToyStoreContextCreator>();
            using (var context = contextCreator.CreateContext())
            {
                context.Database.Migrate();
            }

            

        }
    }
}
