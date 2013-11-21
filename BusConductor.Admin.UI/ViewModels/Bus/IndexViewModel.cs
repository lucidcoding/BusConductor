using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class IndexViewModel 
    {
        public ObservableCollection<IndexBusViewModel> Busses { get; set; }
    }
}
