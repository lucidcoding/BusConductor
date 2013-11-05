using System;
using System.Collections.Generic;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using NUnit.Framework;

namespace BusConductor.Domain.UnitTests.Entities.BusTests
{
    [TestFixture]
    public class GetBookingStatusForTests
    {
        [Test]
        [TestCase(1, BookingStatus.Free)]
        [TestCase(2, BookingStatus.Pending)]
        [TestCase(3, BookingStatus.Pending)]
        [TestCase(6, BookingStatus.Pending)]
        [TestCase(7, BookingStatus.Free)]
        [TestCase(8, BookingStatus.Free)]
        [TestCase(10, BookingStatus.Confirmed)]
        [TestCase(11, BookingStatus.Confirmed)]
        [TestCase(17, BookingStatus.Free)]
        public void ReturnsCorrectBookingStatus(int day, BookingStatus expectedBookingStatus)
        {
            var bus = new Bus();
            bus.Bookings = new List<Booking>();

            bus.Bookings.Add(new Booking
                                 {
                                     Bus = bus,
                                     PickUp = new DateTime(2000, 10, 2),
                                     DropOff = new DateTime(2000, 10, 7),
                                     Status = BookingStatus.Pending,
                                 });


            bus.Bookings.Add(new Booking
                                 {
                                     Bus = bus,
                                     PickUp = new DateTime(2000, 10, 10),
                                     DropOff = new DateTime(2000, 10, 17),
                                     Status = BookingStatus.Confirmed,
                                 });

            var actualBookingStatus = bus.GetBookingStatusFor(new DateTime(2000, 10, day));
            Assert.That(actualBookingStatus, Is.EqualTo(expectedBookingStatus));
        }
    }
}
