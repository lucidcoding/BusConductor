using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusConductor.UI.ViewModels.Rates
{
    public class IndexBusViewModel
    {
        public Guid BusId { get; set; }
        public string Name { get; set; }
        public string MainImageUrl { get; set; }
        public decimal WinterFridayToFriday { get; set; }
        public decimal WinterMondayToFriday { get; set; }
        public decimal WinterFridayToMonday { get; set; }
        public decimal SpringFridayToFriday { get; set; }
        public decimal SpringMondayToFriday { get; set; }
        public decimal SpringFridayToMonday { get; set; }
        public decimal SummerFridayToFriday { get; set; }
        public decimal SummerMondayToFriday { get; set; }
        public decimal SummerFridayToMonday { get; set; }
        public decimal AutumnFridayToFriday { get; set; }
        public decimal AutumnMondayToFriday { get; set; }
        public decimal AutumnFridayToMonday { get; set; }
    }
}