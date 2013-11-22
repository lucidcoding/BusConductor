using System;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace BusConductor.Admin.UI.Views.Bus
{
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();

            //var detail = new Details("hkh");
            //NavigationService.Navigate(detail);

            //Messenger.Default.Register<Uri>(this, "Navigate", (uri) => NavigationService.Navigate(uri, "test"));

            Messenger.Default.Register<string>(this, "Navigate", (x) =>
                                                                     {
                                                                         var detail = new Details(x);
                                                                         NavigationService.Navigate(detail);
                                                                     });

        }
    }
}
