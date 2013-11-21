using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    //http://www.codeproject.com/Articles/323187/MVVMLight-Using-Two-Views
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
