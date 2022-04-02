using SimpleInjector;
using GalaSoft.MvvmLight;
using Monefy.View;
using Monefy.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Monefy.Services.Classes;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Services.Interfaces;

namespace Monefy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            StartMain<MainViewModel>();

            base.OnStartup(e);
        }

        public void Register()
        {
            Container = new Container();

            Container.RegisterSingleton<INavigationService,NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<IncomesViewModel>();

            Container.Verify();
        }


        public void StartMain<T>() where T : ViewModelBase
        {
            Window window = new MainView();
            var viewModel = Container.GetInstance<T>();

            window.DataContext = viewModel;

            window.ShowDialog();
        }

    }
}
