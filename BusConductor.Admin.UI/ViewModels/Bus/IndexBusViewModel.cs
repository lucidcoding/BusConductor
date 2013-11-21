using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class IndexBusViewModel : ViewModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICommand TestCommand { get; private set; }

        public IndexBusViewModel()
        {
            TestCommand = new RelayCommand<IndexBusViewModel>(ExecuteTestCommand);
        }

        public void ExecuteTestCommand(IndexBusViewModel indexBusViewModel)
        {
            var uri = new Uri("../../Views/Bus/Details.xaml", UriKind.Relative);
            Messenger.Default.Send(uri, "Navigate");
        }
    }
}
