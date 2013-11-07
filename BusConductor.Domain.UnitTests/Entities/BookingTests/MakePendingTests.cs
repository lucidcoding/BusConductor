using System;
using System.Collections.Generic;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.Domain.ParameterSets;
using NUnit.Framework;

namespace BusConductor.Domain.UnitTests.Entities.BookingTests
{
    [TestFixture]
    public class MakePendingTests
    {
        private MakePendingBookingParameterSet _parameterSet;

        [SetUp]
        public void SetUp()
        {
            var applicationUser = new User { Id = Guid.NewGuid() };
            var guestRole = new Role { Id = Guid.NewGuid() };
            var voucher = new Voucher { Id = Guid.NewGuid(), Code = "ABC123", Discount = 10 };
            _parameterSet = new MakePendingBookingParameterSet();
            _parameterSet.PickUp = new DateTime(2090, 6, 9);
            _parameterSet.DropOff = new DateTime(2090, 6, 16);
            _parameterSet.Bus = new Bus();
            _parameterSet.Bus.Id = Guid.NewGuid();
            _parameterSet.Bus.Bookings = new List<Booking>();
            _parameterSet.Bus.PricingPeriods = new List<PricingPeriod>();
            var pricingPeriod = new PricingPeriod();
            pricingPeriod.StartMonth = 1;
            pricingPeriod.StartDay = 1;
            pricingPeriod.EndMonth = 12;
            pricingPeriod.EndDay = 31;
            pricingPeriod.FridayToFridayRate = 600;
            _parameterSet.Bus.PricingPeriods.Add(pricingPeriod);
            _parameterSet.GuestRole = guestRole;
            _parameterSet.Forename = "Barry";
            _parameterSet.Surname = "Blue";
            _parameterSet.AddressLine1 = "99 Black Street";
            _parameterSet.AddressLine2 = "Purple District";
            _parameterSet.AddressLine3 = "Gray Area";
            _parameterSet.Town = "Greenville";
            _parameterSet.County = "Redshire";
            _parameterSet.PostCode = "M11AA";
            _parameterSet.Email = "barry.blue@isp.com";
            _parameterSet.TelephoneNumber = "0123456789";
            _parameterSet.IsMainDriver = true;
            _parameterSet.NumberOfAdults = 2;
            _parameterSet.NumberOfChildren = 0;
            _parameterSet.CurrentUser = applicationUser;
            _parameterSet.VoucherCode = voucher.Code;
            _parameterSet.Voucher = voucher;
        }

        [Test]
        public void CanMakePendingBooking()
        {
            var booking = Booking.MakePending(_parameterSet);
            Assert.That(booking.PickUp, Is.EqualTo(_parameterSet.PickUp));
            Assert.That(booking.DropOff, Is.EqualTo(_parameterSet.DropOff));
            Assert.That(booking.NumberOfAdults, Is.EqualTo(_parameterSet.NumberOfAdults));
            Assert.That(booking.NumberOfChildren, Is.EqualTo(_parameterSet.NumberOfChildren));
            Assert.That(booking.Voucher, Is.EqualTo(_parameterSet.Voucher));
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Pending));
            Assert.That(booking.Bus, Is.EqualTo(_parameterSet.Bus));
            Assert.That(booking.TotalCost, Is.EqualTo(540m));
            Assert.That(booking.CreatedBy, Is.Not.Null);
            Assert.That(booking.CreatedBy.Username, Is.Not.Empty);
            Assert.That(booking.CreatedBy.Username, Is.Not.Null);
            Assert.That(booking.CreatedBy.Forename, Is.EqualTo(_parameterSet.Forename));
            Assert.That(booking.CreatedBy.Surname, Is.EqualTo(_parameterSet.Surname));
            Assert.That(booking.CreatedBy.AddressLine1, Is.EqualTo(_parameterSet.AddressLine1));
            Assert.That(booking.CreatedBy.AddressLine2, Is.EqualTo(_parameterSet.AddressLine2));
            Assert.That(booking.CreatedBy.AddressLine3, Is.EqualTo(_parameterSet.AddressLine3));
            Assert.That(booking.CreatedBy.Town, Is.EqualTo(_parameterSet.Town));
            Assert.That(booking.CreatedBy.County, Is.EqualTo(_parameterSet.County));
            Assert.That(booking.CreatedBy.PostCode, Is.EqualTo(_parameterSet.PostCode));
            Assert.That(booking.CreatedBy.Email, Is.EqualTo(_parameterSet.Email));
            Assert.That(booking.CreatedBy.TelephoneNumber, Is.EqualTo(_parameterSet.TelephoneNumber));
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void InvalidBookingThrowsException()
        {
            _parameterSet.Forename = null;
            Booking.MakePending(_parameterSet);
        }
    }
}
