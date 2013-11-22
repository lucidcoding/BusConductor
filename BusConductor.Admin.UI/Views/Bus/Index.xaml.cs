using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusConductor.Admin.UI.Core;
using BusConductor.Admin.UI.ViewModels.Bus;
using BusConductor.Admin.UI.Views.Bus;
using GalaSoft.MvvmLight.Messaging;
using StructureMap;

namespace BusConductor.Admin.UI.Views.Booking
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        private IndexViewModel _viewModel;

        //http://www.codeproject.com/Articles/165368/WPF-MVVM-Quick-Start-Tutorial
        public Index()
        {
            //todo: move from here
            //ObjectFactory.Container.Configure(x => x.AddRegistry<UiRegistry>());


            //_viewModel = new IndexViewModel()
            //                 {
                                 
            //                 };

            InitializeComponent();
            _viewModel = (IndexViewModel) base.DataContext;

            //base.DataContext = _viewModel;

            Messenger.Default.Register<Uri>(this, "Navigate",
                (uri) => NavigationService.Navigate(uri));
        }


    }
}
