using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusConductor.UI.ViewModels.Availability;

namespace BusConductor.UI.Controllers
{
    public class AvailabilityController : Controller
    {
        public ActionResult Index()
        {
            const int numberOfBusses = 6;
            const int numberOfDays = 25;
            var today = DateTime.Now.Date;
            var viewModel = new IndexViewModel();
            viewModel.Days = new List<IndexDayViewModel>();
            viewModel.Busses = new List<IndexBusViewModel>();

            for (int dayIndex = 0; dayIndex< numberOfDays; dayIndex ++)
            {
                var day = today.AddDays(dayIndex);
                var dayViewModel = new IndexDayViewModel();
                dayViewModel.DayName = day.ToString("ddd");
                dayViewModel.DayNumber = day.Day;
                viewModel.Days.Add(dayViewModel);
            }

            for (int busIndex = 0; busIndex < numberOfBusses; busIndex ++)
            {
                var busViewModel = new IndexBusViewModel();
                busViewModel.Name = "Bus " + busIndex.ToString(CultureInfo.InvariantCulture);
                busViewModel.Days = new List<IndexBusDayViewModel>();

                for (int dayIndex = 0; dayIndex < numberOfDays; dayIndex++)
                {
                    var busDayViewModel = new IndexBusDayViewModel();
                    busViewModel.Days.Add(busDayViewModel);
                }

                viewModel.Busses.Add(busViewModel);
            }
                
            return View(viewModel);
        }
    }
}
