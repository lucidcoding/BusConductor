using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusConductor.Admin.UI.ViewModels.Bus
{
    public class IndexViewModel
    {
        public IList<IndexBusViewModel> Busses { get; set; } 
    }
}