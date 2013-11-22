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
    public class IndexBusViewModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
