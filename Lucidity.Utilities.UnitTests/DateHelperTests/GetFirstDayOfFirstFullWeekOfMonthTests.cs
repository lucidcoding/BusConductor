using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Lucidity.Utilities.UnitTests.DateHelperTests
{
    [TestFixture]
    public class GetFirstDayOfFirstFullWeekOfMonthTests
    {
        [Test]
        [TestCase(2000, 1, 2000, 1, 3)]
        [TestCase(2000, 5, 2000, 5, 1)]
        [TestCase(2000, 6, 2000, 6, 5)]
        [TestCase(2005, 1, 2005, 1, 3)]
        [TestCase(2005, 6, 2005, 6, 6)]
        [TestCase(2005, 8, 2005, 8, 1)]
        [TestCase(2010, 1, 2010, 1, 4)]
        [TestCase(2010, 6, 2010, 6, 7)]
        public void ReturnsCorrectDate(
            int year, 
            int month, 
            int expectedResultYear, 
            int expectedResultMonth, 
            int expectedResultDay)
        {
            var expectedResult = new DateTime(expectedResultYear, expectedResultMonth, expectedResultDay);
            var actualResult = DateHelper.GetFirstDayOfFirstFullWeekOfMonth(year, month);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
