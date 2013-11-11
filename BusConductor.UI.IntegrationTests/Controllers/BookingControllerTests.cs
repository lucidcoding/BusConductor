using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using BusConductor.Data.Common;
using BusConductor.Data.Core;
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
        }
    }
}
