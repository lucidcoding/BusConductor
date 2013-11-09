using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.UI.ViewModels.Availability;

namespace BusConductor.UI.ViewModelMappers.Availability
{
    public static class IndexViewModelMapper
    {
        public static IndexViewModel Map(IList<Bus> busses)
        {
            const int numberOfDays = 25;
            var today = DateTime.Now.Date;
            var viewModel = new IndexViewModel();
            viewModel.Days = new List<IndexDayViewModel>();
            viewModel.Busses = new List<IndexBusViewModel>();

            for (int dayIndex = 0; dayIndex < numberOfDays; dayIndex++)
            {
                var day = today.AddDays(dayIndex);
                var dayViewModel = new IndexDayViewModel();
                dayViewModel.DayName = day.ToString("ddd");
                dayViewModel.DayNumber = day.Day;
                viewModel.Days.Add(dayViewModel);
            }

            for (int busIndex = 0; busIndex < busses.Count; busIndex++)
            {
                var busViewModel = new IndexBusViewModel();
                busViewModel.BusId = busses[busIndex].Id.Value;
                busViewModel.Name = busses[busIndex].Name;
                busViewModel.Days = new List<IndexBusDayViewModel>();
                busViewModel.MainImageUrl = VirtualPathUtility.ToAbsolute("~/Images/bluebell_sm_121109.jpg");

                for (int dayIndex = 0; dayIndex < numberOfDays; dayIndex++)
                {
                    var busDayViewModel = new IndexBusDayViewModel();
                    var day = today.AddDays(dayIndex);

                    //todo: move these constants somewhere?
                    if(day.DayOfWeek == DayOfWeek.Friday || day.DayOfWeek == DayOfWeek.Monday)
                    {
                        busDayViewModel.AdditionalClass = "change-over-day";
                    }

                    if(busses[busIndex].GetBookingStatusFor(day) != BookingStatus.Free)
                    {
                        busDayViewModel.AdditionalClass = "booked";
                    }

                    busViewModel.Days.Add(busDayViewModel);
                }

                viewModel.Busses.Add(busViewModel);
            }

            return viewModel;
        }
    }
}