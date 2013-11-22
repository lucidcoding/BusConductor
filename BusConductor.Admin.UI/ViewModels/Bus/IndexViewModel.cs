using System;
using System.Collections.ObjectModel;
using BusConductor.Admin.UI.Common;
using BusConductor.Domain.RepositoryContracts;
using GalaSoft.MvvmLight;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class IndexViewModel : ViewModelBase
    {
        private IBusRepository _busRepository;
        private readonly INavigationService _navigationService;
        public ObservableCollection<IndexBusViewModel> Busses { get; set; }

        public string Blah { get; set; }

        public IndexViewModel(IBusRepository busRepository,INavigationService navigationService)
        {
            _busRepository = busRepository;
            _navigationService = navigationService;

            Busses = new ObservableCollection<IndexBusViewModel>()
                         {
                             new IndexBusViewModel(_navigationService) {Id = Guid.NewGuid(), Name = "Test 1"},
                             new IndexBusViewModel(_navigationService)  {Id = Guid.NewGuid(), Name = "Test 2"},
                         };
        }

    }
}
