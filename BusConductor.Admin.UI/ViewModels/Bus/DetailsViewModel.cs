using System;
using GalaSoft.MvvmLight;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class DetailsViewModel : ViewModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
