using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BusConductor.Domain.Common;
using BusConductor.Domain.Enumerations;

namespace BusConductor.Domain.Entities
{
    public class Bus : Entity<Guid>
    {
        private string _name;
        private string _description;
        private string _overview;
        private string _details;
        private DriveSide _driveSide;
        private int _berth;
        private int _year;
        private ICollection<PricingPeriod> _pricingPeriods; 
        private ICollection<Booking> _bookings;
 
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual ICollection<Booking> Bookings
        {
            get { return _bookings; }
            set { _bookings = value; }
        }

        public virtual string Overview
        {
            get { return _overview; }
            set { _overview = value; }
        }

        public virtual string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        public virtual DriveSide DriveSide
        {
            get { return _driveSide; }
            set { _driveSide = value; }
        }

        public virtual int Berth
        {
            get { return _berth; }
            set { _berth = value; }
        }

        public virtual int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public virtual ICollection<PricingPeriod> PricingPeriods
        {
            get { return _pricingPeriods; }
            set { _pricingPeriods = value; }
        }

        public virtual decimal GetRateFor(DateTime date)
        {
            return 0;
        }

        //    if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        //    {
        //        switch (date.Month)
        //        {
        //            case 12:
        //            case 1:
        //            case 2:
        //                return _winterWeekendRate;
        //            case 3:
        //            case 4:
        //            case 5:
        //                return _springWeekendRate;
        //            case 6:
        //            case 7:
        //            case 8:
        //                return _summerWeekendRate;
        //            default:
        //                return _autumnWeekendRate;
        //        }
        //    }

        //    switch(date.Month)
        //    {
        //        case 12:
        //        case 1:
        //        case 2:
        //            return _winterWeekdayRate;
        //        case 3:
        //        case 4:
        //        case 5:
        //            return _springWeekdayRate;
        //        case 6:
        //        case 7:
        //        case 8:
        //            return _summerWeekdayRate;
        //        default:
        //            return _autumnWeekdayRate;
        //    }
        //}

        public virtual PricingPeriod GetPricingPeriodFor(DateTime pickUp)
        {
            return PricingPeriods.Single(x => x.ContainsDate(pickUp));
        }

        public virtual decimal GetUndiscountedRateFor(DateTime pickUp, DateTime dropOff)
        {
            var pricingPeriod = GetPricingPeriodFor(pickUp);

            if(pickUp.DayOfWeek == DayOfWeek.Monday && dropOff == pickUp.AddDays(4))
            {
                return pricingPeriod.MondayToFridayRate;
            }
            
            if (pickUp.DayOfWeek == DayOfWeek.Friday && dropOff == pickUp.AddDays(3))
            {
                return pricingPeriod.FridayToMondayRate;
            }
            
            if (pickUp.DayOfWeek == DayOfWeek.Friday && dropOff == pickUp.AddDays(7))
            {
                return pricingPeriod.FridayToFridayRate;
            }

            if (pickUp.DayOfWeek == DayOfWeek.Monday && dropOff > pickUp.AddDays(4))
            {
                return pricingPeriod.MondayToFridayRate + GetUndiscountedRateFor(pickUp.AddDays(4), dropOff);
            }

            if (pickUp.DayOfWeek == DayOfWeek.Friday && dropOff > pickUp.AddDays(7))
            {
                return pricingPeriod.FridayToFridayRate + GetUndiscountedRateFor(pickUp.AddDays(7), dropOff);
            }

            throw new Exception("Unexpected booking period: " 
                + pickUp.ToString(CultureInfo.InvariantCulture) 
                + " - " 
                + dropOff.ToString(CultureInfo.InvariantCulture));
        }

        public virtual BusDayBookingStatus GetBookingStatusFor(DateTime date)
        {
            var returnValue = BusDayBookingStatus.Free;

            foreach (var booking in _bookings) 
            {
                if (date > booking.PickUp && date < booking.DropOff)
                {
                    return booking.Status == BookingStatus.Pending ? BusDayBookingStatus.PendingAllDay : BusDayBookingStatus.ConfirmedAllDay;
                }

                if(date == booking.PickUp)
                {
                    returnValue |= booking.Status == BookingStatus.Pending ? BusDayBookingStatus.PendingPm : BusDayBookingStatus.ConfirmedPm;
                }

                if (date == booking.DropOff)
                {
                    returnValue |= booking.Status == BookingStatus.Pending ? BusDayBookingStatus.PendingAm : BusDayBookingStatus.ConfirmedAm;
                }
            }

            return returnValue;
        }

        public virtual IList<Booking> GetConflictingBookings(DateTime pickUp, DateTime dropOff)
        {
            return Bookings.Where(booking =>
                (pickUp >= booking.PickUp && pickUp < booking.DropOff) 
                || (dropOff > booking.PickUp && dropOff <= booking.DropOff)
                || (pickUp <= booking.PickUp && dropOff >= booking.DropOff))
                .ToList();
        }

        public virtual decimal GetWinterMondayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 1, 1)).MondayToFridayRate;
        }

        public virtual decimal GetWinterFridayToMondayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 1, 1)).FridayToMondayRate;
        }

        public virtual decimal GetWinterFridayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 1, 1)).FridayToFridayRate;
        }

        public virtual decimal GetSpringMondayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 4, 1)).MondayToFridayRate;
        }

        public virtual decimal GetSpringFridayToMondayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 4, 1)).FridayToMondayRate;
        }

        public virtual decimal GetSpringFridayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 4, 1)).FridayToFridayRate;
        }

        public virtual decimal GetSummerMondayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 7, 1)).MondayToFridayRate;
        }

        public virtual decimal GetSummerFridayToMondayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 7, 1)).FridayToMondayRate;
        }

        public virtual decimal GetSummerFridayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 7, 1)).FridayToFridayRate;
        }

        public virtual decimal GetAutumnMondayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 10, 1)).MondayToFridayRate;
        }

        public virtual decimal GetAutumnFridayToMondayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 10, 1)).FridayToMondayRate;
        }

        public virtual decimal GetAutumnFridayToFridayRate()
        {
            return GetPricingPeriodFor(new DateTime(2001, 10, 1)).FridayToFridayRate;
        }
    }
}
