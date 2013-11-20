using System;
using System.Collections.Generic;
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
using BusConductor.Admin.UI.ViewModels.Bus;

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
            _viewModel = new IndexViewModel()
                             {
                                 Busses = new List<IndexBusViewModel>()
                                              {
                                                  new IndexBusViewModel {Id = Guid.NewGuid(), Name = "Test 1"},
                                                  new IndexBusViewModel {Id = Guid.NewGuid(), Name = "Test 2"},
                                              }
                             };

            InitializeComponent();
            base.DataContext = _viewModel;
        }
    }
}
