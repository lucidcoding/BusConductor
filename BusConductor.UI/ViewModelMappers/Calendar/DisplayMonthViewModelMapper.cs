using System;
using System.Globalization;
using System.Linq;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.UI.ViewModels.Calendar;
using Lucidity.Utilities;

namespace BusConductor.UI.ViewModelMappers.Calendar
{
    public static class DisplayMonthViewModelMapper
    {
        public static DisplayMonthViewModel Map(Bus bus)
        {
            var now = DateTime.Now;
            return Map(now.Year, now.Month, bus);
        }

        //todo: nice load of unit testing for this.
        public static DisplayMonthViewModel Map(int year, int month, Bus bus)
        {
            var viewModel = new DisplayMonthViewModel();
            viewModel.Year = year;
            viewModel.Month = month;
            viewModel.BusId = bus.Id.Value;
            var firstDayOfMonth = new DateTime(year, month, 1);
            var firstDayOfFirstWeekOfMonth = DateHelper.GetFirstDayOfFirstPartWeekOfMonth(year, month);
            viewModel.MonthName = firstDayOfMonth.ToString("MMMM", CultureInfo.InvariantCulture);
            //var firstDayOfFirstWeekOfMonth = firstDayOfMonth.AddDays(DayOfWeek.Monday - firstDayOfMonth.DayOfWeek);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var numberOfWeeks = ((lastDayOfMonth - firstDayOfFirstWeekOfMonth).Days / 7) + 1;
            viewModel.YearOfPreviousMonth = firstDayOfMonth.AddMonths(-1).Year;
            viewModel.MonthOfPreviousMonth = firstDayOfMonth.AddMonths(-1).Month;
            viewModel.YearOfNextMonth = firstDayOfMonth.AddMonths(1).Year;
            viewModel.MonthOfNextMonth = firstDayOfMonth.AddMonths(1).Month;
            viewModel.Weeks = new DisplayMonthWeekViewModel[numberOfWeeks];

            for (var week = 0; week < numberOfWeeks; week++)
            {
                viewModel.Weeks[week] = new DisplayMonthWeekViewModel();
                viewModel.Weeks[week].Days = new DisplayMonthDayViewModel[7];

                for (var day = 0; day < 7; day++)
                {
                    var date = firstDayOfFirstWeekOfMonth.AddDays((week*7) + day);
                    viewModel.Weeks[week].Days[day] = new DisplayMonthDayViewModel();
                    viewModel.Weeks[week].Days[day].Date = date;
                    viewModel.Weeks[week].Days[day].Rate = bus.GetRateFor(date);

                    switch(bus.GetBookingStatusFor(date))
                    {
                        case BookingStatus.Confirmed :
                            viewModel.Weeks[week].Days[day].AdditionalClass = "confirmed";
                            break;
                        case BookingStatus.Pending:
                            viewModel.Weeks[week].Days[day].AdditionalClass = "pending";
                            break;
                    }
                }
            }

            return viewModel;
        }
    }
}