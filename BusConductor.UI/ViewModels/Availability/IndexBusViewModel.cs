using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusConductor.UI.ViewModels.Availability
{
    public class IndexBusViewModel
    {
        public string Name { get; set; }
        public IList<IndexBusDayViewModel> Days { get; set; } 
    }
}