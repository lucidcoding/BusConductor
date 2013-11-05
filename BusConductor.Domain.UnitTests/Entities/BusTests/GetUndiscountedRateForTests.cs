using System;
using System.Collections.Generic;
using BusConductor.Domain.Entities;
using NUnit.Framework;

namespace BusConductor.Domain.UnitTests.Entities.BusTests
{
    [TestFixture]
    public class GetUndiscountedRateForTests
    {
        //todo: many more of these.
        [Test]
        [TestCase(2000, 1, 3, 2000, 1, 7, 500)]
        [TestCase(2000, 1, 7, 2000, 1, 10, 450)]
        [TestCase(2000, 1, 7, 2000, 1, 14, 800)]
        [TestCase(2000, 5, 5, 2000, 5, 8, 550)]
        [TestCase(2000, 5, 5, 2000, 5, 12, 1000)]
        [TestCase(2000, 5, 1, 2000, 5, 5, 600)]
        [TestCase(2000, 5, 5, 2000, 5, 8, 550)]
        [TestCase(2000, 8, 14, 2000, 8, 21, 1150)]
        [TestCase(2000, 8, 14, 2000, 8, 25, 1600)]
        [TestCase(2002, 4, 29, 2002, 5, 3, 500)]
        [TestCase(2002, 4, 26, 2002, 5, 3, 800)]
        [TestCase(2002, 4, 26, 2002, 5, 6, 1350)]
        public void ReturnsCorrectRate(
            int pickUpYear, 
            int pickUpMonth, 
            int pickUpDay, 
            int dropOffYear,
            int dropOffMonth, 
            int dropOffDay, 
            decimal expectedRate)
        {
            var bus = new Bus();
            bus.PricingPeriods = new List<PricingPeriod>();
            bus.PricingPeriods.Add(new PricingPeriod());
            bus.PricingPeriods[0].StartMonth = 1;
            bus.PricingPeriods[0].StartDay = 1;
            bus.PricingPeriods[0].EndMonth = 4;
            bus.PricingPeriods[0].EndDay = 30;
            bus.PricingPeriods[0].FridayToFridayRate = 800;
            bus.PricingPeriods[0].FridayToMondayRate = 450;
            bus.PricingPeriods[0].MondayToFridayRate = 500;
            bus.PricingPeriods[0].Bus = bus;
            bus.PricingPeriods.Add(new PricingPeriod());
            bus.PricingPeriods[1].StartMonth = 5;
            bus.PricingPeriods[1].StartDay = 1;
            bus.PricingPeriods[1].EndMonth = 8;
            bus.PricingPeriods[1].EndDay = 31;
            bus.PricingPeriods[1].FridayToFridayRate = 1000;
            bus.PricingPeriods[1].FridayToMondayRate = 550;
            bus.PricingPeriods[1].MondayToFridayRate = 600;
            bus.PricingPeriods[1].Bus = bus;
            bus.PricingPeriods.Add(new PricingPeriod());
            bus.PricingPeriods[2].StartMonth = 9;
            bus.PricingPeriods[2].StartDay = 1;
            bus.PricingPeriods[2].EndMonth = 12;
            bus.PricingPeriods[2].EndDay = 31;
            bus.PricingPeriods[2].FridayToFridayRate = 700;
            bus.PricingPeriods[2].FridayToMondayRate = 400;
            bus.PricingPeriods[2].MondayToFridayRate = 450;
            bus.PricingPeriods[2].Bus = bus;
            var actualRate = bus.GetUndiscountedRateFor(new DateTime(pickUpYear, pickUpMonth, pickUpDay), new DateTime(dropOffYear, dropOffMonth, dropOffDay));
            Assert.That(actualRate, Is.EqualTo(expectedRate));
        }
    }
}
