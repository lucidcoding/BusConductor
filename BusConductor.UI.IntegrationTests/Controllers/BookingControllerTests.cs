using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BusConductor.Data.Common;
using BusConductor.Data.Core;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.Core;
using BusConductor.UI.IntegrationTests.Common;
using BusConductor.UI.IntegrationTests.Core;
using BusConductor.UI.IntegrationTests.Helpers;
using BusConductor.UI.ViewModels.Booking;
using NUnit.Framework;
using BusConductor.UI.Controllers;
using StructureMap;

namespace BusConductor.UI.IntegrationTests.Controllers
{
    [TestFixture]
    public class BookingControllerTests 
    {
        private BookingController _bookingController;

        [SetUp]
        public void SetUp()
        {
            ObjectFactory.Container.Configure(x => x.AddRegistry<TestRegistry>());
            _bookingController = ObjectFactory.GetInstance<BookingController>();
            ScriptRunner.RunScript();

        }

        [TearDown]
        public void TearDown()
        {
            var contextProvider = ObjectFactory.GetInstance<IContextProvider>() as GenericContextProvider;
            contextProvider.SaveChangesAndClearContext();
        }

        [Test]
        public void Works()
        {
            //try
            //{
            //    //var context = new Context();
            //    //TestContext.CurrentContext.Test.Properties.Add("Context", context);

                //todo: cntext somewhere?
                var viewModel = new ReviewViewModel();
                viewModel.BusId = new Guid("6a9857a6-d0b0-4e1a-84cb-ee9ade159560");
                viewModel.PickUp = new DateTime(2090, 1, 2);
                viewModel.DropOff = new DateTime(2090, 1, 6);
                viewModel.Forename = "Percy";
                viewModel.Surname = "Purple";
                viewModel.AddressLine1 = "5 Green Lane";
                viewModel.Town = "Blackville";
                viewModel.County = "Blueshire";
                viewModel.PostCode = "M1 1AA";
                viewModel.Email = "percy@purple.com";
                viewModel.TelephoneNumber = "percy@purple.com";
                viewModel.IsMainDriver = false;
                viewModel.DrivingLicenceNumber = "ABC1234";
                viewModel.DriverForename = "Betty";
                viewModel.DriverSurname = "Beige";
                viewModel.NumberOfAdults = 2;
                viewModel.NumberOfChildren = 1;
                viewModel.VoucherCode = null; //todo: test this?
                _bookingController.Confirm(viewModel);
            //}
            //finally
            //{
            //    var contextProvider = ObjectFactory.GetInstance<IContextProvider>() as GenericContextProvider;
            //    contextProvider.SaveChangesAndClearContext();
            //}

            //todo:need booking id.
            //todo: refactor this somewhere.
            var contextProvider = ObjectFactory.GetInstance<IContextProvider>() as GenericContextProvider;
            contextProvider.SaveChangesAndClearContext();

            //todo: find a better way to do this.
            var bookingRepository = ObjectFactory.GetInstance<IBookingRepository>();

            var booking =
                bookingRepository.GetAll().Single(x => x.Id.Value != new Guid("eaa01eab-f3bd-4e24-8368-d3501a227a8b"));

            Assert.That(booking.PickUp, Is.EqualTo(viewModel.PickUp));
            Assert.That(booking.DropOff, Is.EqualTo(viewModel.DropOff));
            Assert.That(booking.Bus.Id.Value, Is.EqualTo(viewModel.BusId));
            Assert.That(booking.CreatedBy.Forename, Is.EqualTo(viewModel.Forename));
            Assert.That(booking.CreatedBy.Surname, Is.EqualTo(viewModel.Surname));
            Assert.That(booking.CreatedBy.AddressLine1, Is.EqualTo(viewModel.AddressLine1));
            Assert.That(booking.CreatedBy.Town, Is.EqualTo(viewModel.Town));
            Assert.That(booking.CreatedBy.County, Is.EqualTo(viewModel.County));
            Assert.That(booking.CreatedBy.PostCode, Is.EqualTo(viewModel.PostCode));
            Assert.That(booking.CreatedBy.TelephoneNumber, Is.EqualTo(viewModel.TelephoneNumber));
            Assert.That(booking.IsMainDriver, Is.EqualTo(viewModel.IsMainDriver));
            Assert.That(booking.DriverForename, Is.EqualTo(viewModel.DriverForename));
            Assert.That(booking.DriverSurname, Is.EqualTo(viewModel.DriverSurname));
            Assert.That(booking.NumberOfAdults, Is.EqualTo(viewModel.NumberOfAdults));
            Assert.That(booking.NumberOfChildren, Is.EqualTo(viewModel.NumberOfChildren));
            Assert.That(booking.TotalCost, Is.EqualTo(600));
        }
    }
}
