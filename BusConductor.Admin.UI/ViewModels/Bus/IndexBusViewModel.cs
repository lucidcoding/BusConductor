using System;
using System.Windows.Input;
using System.Windows.Navigation;
using BusConductor.Admin.UI.Common;
using BusConductor.Admin.UI.Views.Bus;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class IndexBusViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICommand TestCommand { get; private set; }

        public IndexBusViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            TestCommand = new RelayCommand(ExecuteTestCommand);
        }

        public void ExecuteTestCommand()
        {
            //var uri = new Uri("../../Views/Bus/Details.xaml", UriKind.Relative);
            //Messenger.Default.Send<Uri>(uri, "Navigate");
            Messenger.Default.Send<string>("hjgjhgj", "Navigate");
            //_navigationService.NavigateTo(new Details("tr"));
            //_navigationService.NavigateTo(new Uri("../../Views/Bus/Details.xaml", UriKind.Relative));
        }

    }
}
