using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BusConductor.Admin.UI.ViewModels.Bus;
using GalaSoft.MvvmLight.Messaging;

namespace BusConductor.Admin.UI.Views.Bus
{
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();

            //Messenger.Default.Register<string>(this, "Navigate", (x) =>
            //                                                         {
            //                                                             var detail = new Details(x);
            //                                                             NavigationService.Navigate(detail);
            //                                                         });

            this.DataContext = new IndexViewModel
                                   {
                                       Busses = new ObservableCollection<IndexBusViewModel>()
                                                    {
                                                        new IndexBusViewModel() {Id = Guid.NewGuid(), Name = "Test 1"},
                                                        new IndexBusViewModel() {Id = Guid.NewGuid(), Name = "Test 2"},
                                                    }
                                   };
        }

        public void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var busId = (Guid) button.CommandParameter;
            var detail = new Details(busId);
            NavigationService.Navigate(detail);
        }


    }
}
