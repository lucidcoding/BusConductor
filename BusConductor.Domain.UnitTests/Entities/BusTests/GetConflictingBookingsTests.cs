using System;
using System.Collections.Generic;
using System.Linq;
using BusConductor.Domain.Entities;
using NUnit.Framework;

namespace BusConductor.Domain.UnitTests.Entities.BusTests
{
    [TestFixture]
    public class GetConflictingBookingsTests
    {
        private Bus _bus;

        [SetUp]
        public void SetUp()
        {
            _bus = new Bus();
            _bus.Bookings = new List<Booking>();
            _bus.Bookings.Add(new Booking());
            _bus.Bookings[0].PickUp = new DateTime(2013, 10, 14);
            _bus.Bookings[0].DropOff = new DateTime(2013, 10, 21);
            _bus.Bookings[0].Bus = _bus;
            _bus.Bookings.Add(new Booking());
            _bus.Bookings[1].PickUp = new DateTime(2013, 10, 25);
            _bus.Bookings[1].DropOff = new DateTime(2013, 10, 28);
            _bus.Bookings[1].Bus = _bus;
        }

        [Test]
        public void ReturnsNoConflictingBookingsIfCompletelyClear()
        {
            var conflictingBookings = _bus.GetConflictingBookings(new DateTime(2013, 9, 30), new DateTime(2013, 10, 4));
            Assert.That(!conflictingBookings.Any());
        }

        [Test]
        [TestCase(13, 15, Description = "Overlaps start")]
        [TestCase(12, 16, Description = "Overlaps start")]
        [TestCase(20, 22, Description = "Overlaps end")]
        [TestCase(19, 23, Description = "Overlaps end")]
        [TestCase(15, 20, Description = "Fully contained")]
        [TestCase(14, 16, Description = "Contained with matching pick up date but shorter")]
        [TestCase(14, 22, Description = "Contained with matching pick up date but longer")]
        [TestCase(16, 21, Description = "Contained with matching drop off date but shorter")]
        [TestCase(13, 21, Description = "Contained with matching drop off date but longer")]
        [TestCase(14, 21, Description = "Matching dates as existing booking")]
        public void ReturnsConflictingBookingIfOverlapsABooking(int pickUpDay, int dropOffDay)
        {
            var conflictingBookings = _bus.GetConflictingBookings(new DateTime(2013, 10, pickUpDay), new DateTime(2013, 10, dropOffDay));
            Assert.That(conflictingBookings.Count, Is.EqualTo(1));
            Assert.That(conflictingBookings[0], Is.EqualTo(_bus.Bookings[0]));
        }

        [Test]
        [TestCase(20, 26)]
        [TestCase(14, 26)]
        [TestCase(16, 28)]
        public void ReturnsConflictingBookingsIfOverlapsTwoBookings(int pickUpDay, int dropOffDay)
        {
            var conflictingBookings = _bus.GetConflictingBookings(new DateTime(2013, 10, pickUpDay), new DateTime(2013, 10, dropOffDay));
            Assert.That(conflictingBookings.Count, Is.EqualTo(2));
            Assert.That(conflictingBookings.Contains(_bus.Bookings[0]));
            Assert.That(conflictingBookings.Contains(_bus.Bookings[1]));
        }

        [Test]
        public void ReturnsNoConflictsIfPickUpIsDropOffOfAnotherBookingAndDropOffIsPickUpOfAnotherBooking()
        {
            var conflictingBookings = _bus.GetConflictingBookings(new DateTime(2013, 10, 21), new DateTime(2013, 10, 25));
            Assert.That(!conflictingBookings.Any());
        }

        [Test]
        public void ReturnsConflictingBookingIfNewBookingEncompassesExisting()
        {
            var conflictingBookings = _bus.GetConflictingBookings(new DateTime(2013, 10, 13), new DateTime(2013, 10, 22));
            Assert.That(conflictingBookings.Count, Is.EqualTo(1));
            Assert.That(conflictingBookings[0], Is.EqualTo(_bus.Bookings[0]));
        }

        [Test]
        public void ReturnsConflictingBookingIfNewBookingExactlyMatchesExisting()
        {
            var conflictingBookings = _bus.GetConflictingBookings(new DateTime(2013, 10, 14), new DateTime(2013, 10, 21));
            Assert.That(conflictingBookings.Count, Is.EqualTo(1));
            Assert.That(conflictingBookings[0], Is.EqualTo(_bus.Bookings[0]));
        }
    }
}
