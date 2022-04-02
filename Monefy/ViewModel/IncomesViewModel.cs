using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Mesagges;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monefy.ViewModel
{
    public class IncomesViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private RelayCommand backBtn;

        private INavigationService _navigationService;
        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

        public IncomesViewModel(IMessenger messenger, INavigationService navigationService)
        {
            _navigationService = navigationService;

            messenger.Register<NavigationMessage>(this, message =>
            {
                var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
       
        public RelayCommand BackBtn
        {
            get => new RelayCommand(() =>
            {
                _navigationService.NavigateTo<MainViewModel>();
            });
        }
    }
}
