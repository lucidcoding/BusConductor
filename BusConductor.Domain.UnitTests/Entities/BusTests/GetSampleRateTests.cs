using System.Collections.Generic;
using BusConductor.Domain.Entities;
using NUnit.Framework;

namespace BusConductor.Domain.UnitTests.Entities.BusTests
{
    [TestFixture]
    public class GetSampleRateTests
    {
        private Bus _bus;

        [SetUp]
        public void SetUp()
        {
            _bus = new Bus();
            _bus.PricingPeriods = new List<PricingPeriod>();
            _bus.PricingPeriods.Add(new PricingPeriod());
            _bus.PricingPeriods[0].StartMonth = 1;
            _bus.PricingPeriods[0].StartDay = 1;
            _bus.PricingPeriods[0].EndMonth = 4;
            _bus.PricingPeriods[0].EndDay = 30;
            _bus.PricingPeriods[0].FridayToFridayRate = 800;
            _bus.PricingPeriods[0].FridayToMondayRate = 450;
            _bus.PricingPeriods[0].MondayToFridayRate = 500;
            _bus.PricingPeriods[0].Bus = _bus;
            _bus.PricingPeriods.Add(new PricingPeriod());
            _bus.PricingPeriods[1].StartMonth = 5;
            _bus.PricingPeriods[1].StartDay = 1;
            _bus.PricingPeriods[1].EndMonth = 8;
            _bus.PricingPeriods[1].EndDay = 31;
            _bus.PricingPeriods[1].FridayToFridayRate = 1000;
            _bus.PricingPeriods[1].FridayToMondayRate = 550;
            _bus.PricingPeriods[1].MondayToFridayRate = 600;
            _bus.PricingPeriods[1].Bus = _bus;
            _bus.PricingPeriods.Add(new PricingPeriod());
            _bus.PricingPeriods[2].StartMonth = 9;
            _bus.PricingPeriods[2].StartDay = 1;
            _bus.PricingPeriods[2].EndMonth = 12;
            _bus.PricingPeriods[2].EndDay = 31;
            _bus.PricingPeriods[2].FridayToFridayRate = 700;
            _bus.PricingPeriods[2].FridayToMondayRate = 400;
            _bus.PricingPeriods[2].MondayToFridayRate = 450;
            _bus.PricingPeriods[2].Bus = _bus;
        }

        [Test]
        public void ReturnsCorrectWinterMondayToFriday()
        {
            var rate = _bus.GetWinterMondayToFridayRate();
            Assert.That(rate, Is.EqualTo(500));
        }

        [Test]
        public void ReturnsCorrectWinterFridayToMonday()
        {
            var rate = _bus.GetWinterFridayToMondayRate();
            Assert.That(rate, Is.EqualTo(450));
        }

        [Test]
        public void ReturnsCorrectWinterFridayToFriday()
        {
            var rate = _bus.GetWinterFridayToFridayRate();
            Assert.That(rate, Is.EqualTo(800));
        }

        [Test]
        public void ReturnsCorrectSpringMondayToFriday()
        {
            var rate = _bus.GetSpringMondayToFridayRate();
            Assert.That(rate, Is.EqualTo(500));
        }

        [Test]
        public void ReturnsCorrectSpringFridayToMonday()
        {
            var rate = _bus.GetSpringFridayToMondayRate();
            Assert.That(rate, Is.EqualTo(450));
        }

        [Test]
        public void ReturnsCorrectSpringFridayToFriday()
        {
            var rate = _bus.GetSpringFridayToFridayRate();
            Assert.That(rate, Is.EqualTo(800));
        }

        [Test]
        public void ReturnsCorrectSummerMondayToFriday()
        {
            var rate = _bus.GetSummerMondayToFridayRate();
            Assert.That(rate, Is.EqualTo(600));
        }

        [Test]
        public void ReturnsCorrectSummerFridayToMonday()
        {
            var rate = _bus.GetSummerFridayToMondayRate();
            Assert.That(rate, Is.EqualTo(550));
        }

        [Test]
        public void ReturnsCorrectSummerFridayToFriday()
        {
            var rate = _bus.GetSummerFridayToFridayRate();
            Assert.That(rate, Is.EqualTo(1000));
        }

        [Test]
        public void ReturnsCorrectAutumnMondayToFriday()
        {
            var rate = _bus.GetAutumnMondayToFridayRate();
            Assert.That(rate, Is.EqualTo(450));
        }

        [Test]
        public void ReturnsCorrectAutumnFridayToMonday()
        {
            var rate = _bus.GetAutumnFridayToMondayRate();
            Assert.That(rate, Is.EqualTo(400));
        }

        [Test]
        public void ReturnsCorrectAutumnFridayToFriday()
        {
            var rate = _bus.GetAutumnFridayToFridayRate();
            Assert.That(rate, Is.EqualTo(700));
        }
    }
}
