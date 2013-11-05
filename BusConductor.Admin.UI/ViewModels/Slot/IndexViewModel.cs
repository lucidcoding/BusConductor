using System;
using System.Collections.Generic;

namespace BusConductor.Admin.UI.ViewModels.Slot
{
    public class IndexViewModel
    {
        public Guid BusId { get; set; }
        public string BusName { get; set; }
        public IList<IndexRecordViewModel> Slots { get; set; }
    }
}