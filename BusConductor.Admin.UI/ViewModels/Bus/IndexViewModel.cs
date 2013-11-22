using System;
using System.Collections.ObjectModel;
using BusConductor.Domain.RepositoryContracts;
using GalaSoft.MvvmLight;
using StructureMap.Attributes;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class IndexViewModel : ViewModelBase
    {
        //http://jpreecedev.com/2013/08/09/using-structuremap-setter-injection-to-inject-repositories-into-your-view-model/

        public ObservableCollection<IndexBusViewModel> Busses { get; set; }

        //[SetterProperty]
        //public IBusRepository BusRepository { get; set; }

        private IBusRepository _busRepository;

        public string Blah { get; set; }

        public IndexViewModel(IBusRepository busRepository)
        {
            _busRepository = busRepository;

            Busses = new ObservableCollection<IndexBusViewModel>()
                         {
                             new IndexBusViewModel {Id = Guid.NewGuid(), Name = "Test 1"},
                             new IndexBusViewModel {Id = Guid.NewGuid(), Name = "Test 2"},
                         };
        }

    }
}
