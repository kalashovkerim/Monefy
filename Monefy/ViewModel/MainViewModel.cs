using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using Monefy.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using Monefy.Mesagges;

namespace Monefy.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private RelayCommand expenseBtn;
        private RelayCommand incomeBtn;
        

        private INavigationService _navigationService;
        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

        public MainViewModel(IMessenger messenger, INavigationService navigationService)
        {
            _navigationService = navigationService;

            messenger.Register<NavigationMessage>(this, message =>
            {
                var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
        public RelayCommand ExpenseBtn
        {
            get => new RelayCommand(() =>
            {
                _navigationService.NavigateTo<IncomesViewModel>();
            });
        }
        
        public RelayCommand IncomeBtn
        {
            get => new RelayCommand(() =>
            {
                _navigationService.NavigateTo<IncomesViewModel>();
            });
        }

    }
}
