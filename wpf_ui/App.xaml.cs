using BuisnessLogic;
using entities;
using entity_framework;
using entity_framework.DataServices;
using entity_framework.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using wpf_ui.Mediators;
using wpf_ui.Utils;
using wpf_ui.ViewModels;

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
                    services.AddSingleton<IToyStoreContextCreator>(new SQLServerToyStoreDbContextCreator(db_connection_string));

                    // data providers & mutator
                    services.AddSingleton<IDataProviderService<entities.DTO.Toy>, DataProviderService<entities.DTO.Toy>>();
                    services.AddSingleton<IDataProviderService<entities.DTO.User>, DataProviderService<entities.DTO.User>>();
                    services.AddSingleton<IDataProviderService<entities.DTO.Profile>, DataProviderService<entities.DTO.Profile>>();
                    services.AddSingleton<IDataProviderService<entities.DTO.ProfileToy>, DataProviderService<entities.DTO.ProfileToy>>();
                    services.AddSingleton<IDataMutatorService<entities.DTO.User>, DataMutatorService<entities.DTO.User>>();
                    services.AddSingleton<IDataMutatorService<entities.DTO.Toy>, DataMutatorService<entities.DTO.Toy>>();
                    services.AddSingleton<IDataMutatorService<entities.DTO.Profile>, DataMutatorService<entities.DTO.Profile>>();
                    services.AddSingleton<IDataMutatorService<entities.DTO.ProfileToy>, DataMutatorService<entities.DTO.ProfileToy>>();

                    //
                    services.AddSingleton<TheStore>();
                    services.AddSingleton<TheAuthentication>();
                    services.AddSingleton<TheCart>();
                    services.AddSingleton<AuthorizationMediator>();
                    services.AddSingleton<NavigationMediator>();
                    services.AddSingleton<ToysListMediator>();
                    services.AddSingleton<CartMediator>();

                    services.AddTransient<CreateToyViewModel>();
                    services.AddSingleton<Func<CreateToyViewModel>>(s => () => s.GetRequiredService<CreateToyViewModel>());
                    services.AddSingleton<NavigationService<CreateToyViewModel>>();

                    services.AddTransient(s => ToyListViewModel.CreateWithLoadedListAndCart(s.GetRequiredService<CartMediator>(), 
                                                                                     s.GetRequiredService<ToysListMediator>(), 
                                                                                     s.GetRequiredService<NavigationService<CreateToyViewModel>>(),
                                                                                     s.GetRequiredService<NavigationService<ToyCartViewModel>>()
                                                                                     ));
                    services.AddSingleton<Func<ToyListViewModel>>(s => () => s.GetRequiredService<ToyListViewModel>());
                    services.AddSingleton<NavigationService<ToyListViewModel>>();

                    services.AddTransient<AuthorizationViewModel>();
                    services.AddSingleton<Func<AuthorizationViewModel>>(s => () => s.GetRequiredService<AuthorizationViewModel>());
                    services.AddSingleton<NavigationService<AuthorizationViewModel>>();

                    services.AddTransient(s => ToyCartViewModel.CreateWithLoadedList(s.GetRequiredService<CartMediator>(), 
                                                                                                       s.GetRequiredService<NavigationService<ToyListViewModel>>()
                                                                                                       ));
                    services.AddSingleton<Func<ToyCartViewModel>>(s => () => s.GetRequiredService<ToyCartViewModel>());
                    services.AddSingleton<NavigationService<ToyCartViewModel>>();

                    services.AddSingleton<MainViewModel>();

                }).Build();
        }

       

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            var contextCreator = _host.Services.GetRequiredService<IToyStoreContextCreator>();
            using (var context = contextCreator.CreateContext())
            {
                context.Database.Migrate();
            }

            var navService = _host.Services.GetRequiredService<NavigationService<AuthorizationViewModel>>();
            navService.Navigate();

            var mainWin = new MainWindow
            {
                DataContext = _host.Services.GetRequiredService<MainViewModel>()
            };

            mainWin.ShowDialog();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }


    }
}
