using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BusConductor.Application.Contracts;
using BusConductor.Application.ParameterSetMappers.Booking;
using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.Entities;
using BusConductor.Domain.ParameterSets;
using BusConductor.Domain.RepositoryContracts;
using Moq;
using Lucidity.Utilities.Contracts.Logging;

namespace BusConductor.Application.UnitTests.ServiceFactories
{
    public class BookingServiceFactory
    {
        public Mock<IBookingRepository> BookingRepository { get; set; }
        public Mock<IMakePendingParameterSetMapper> MakePendingParameterSetMapper { get; set; }
        public Mock<ILog> Log { get; set; }
        public Bus Bus { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public Voucher Voucher { get; set; }
        public Booking Booking { get; set; }
        public CustomerMakeBookingParameterSet ParameterSet { get; set; }

        public BookingServiceFactory()
        {
            MakePendingParameterSetMapper = new Mock<IMakePendingParameterSetMapper>();
            Log = new Mock<ILog>();
            BookingRepository = new Mock<IBookingRepository>();
            Bus = new Bus { Id = Guid.NewGuid(), Bookings = new List<Booking>(), PricingPeriods = new Collection<PricingPeriod>() };
            User = new User { Id = Guid.NewGuid() };
            Role = new Role { Id = Guid.NewGuid() };
            Voucher = new Voucher { Id = Guid.NewGuid(), Code = "ABC123" };

            Bus.PricingPeriods.Add(new PricingPeriod
                                       {
                                           Bus = Bus,
                                           StartMonth = 1,
                                           StartDay = 1,
                                           EndMonth = 12,
                                           EndDay = 31,
                                           FridayToFridayRate = 1,
                                           FridayToMondayRate = 1,
                                           MondayToFridayRate = 1
                                       });

            ParameterSet = new CustomerMakeBookingParameterSet();
            ParameterSet.PickUp = new DateTime(2090, 1, 2);
            ParameterSet.DropOff = new DateTime(2090, 1, 6);
            ParameterSet.Bus = Bus;
            //ParameterSet.GuestRole = Role;
            ParameterSet.Forename = "Barry";
            ParameterSet.Surname = "Blue";
            ParameterSet.AddressLine1 = "1 Orange Lane";
            ParameterSet.AddressLine2 = "Address Line 2";
            ParameterSet.AddressLine3 = "Address Line 3";
            ParameterSet.Town = "Greenville";
            ParameterSet.County = "Brownshire";
            ParameterSet.PostCode = "M1 1AA";
            ParameterSet.Email = "test@test.com";
            ParameterSet.TelephoneNumber = "0123456789";
            ParameterSet.IsMainDriver = true;
            ParameterSet.DrivingLicenceNumber = "ABC1234";
            ParameterSet.NumberOfAdults = 2;
            ParameterSet.NumberOfChildren = 2;
            ParameterSet.VoucherCode = Voucher.Code;
            ParameterSet.Voucher = Voucher;
            ParameterSet.RestrictionsAccepted = true;
            ParameterSet.TermsAndConditionsAccepted = true;
            ParameterSet.CurrentUser = User;
            ParameterSet.CreatedOn = new DateTime(2013, 10, 1);

            ParameterSet.OtherBookingsToday = new List<Booking>()
            {
                  new Booking{ BookingNumber = "201310010001_Black" },   
                  new Booking{ BookingNumber = "201310010002_Green" },                                 
            };

            MakePendingParameterSetMapper
                .Setup(x => x.Map(It.IsAny<MakePendingRequest>()))
                .Returns(ParameterSet);

            MakePendingParameterSetMapper
                .Setup(x => x.MapWithOtherBookingsToday(It.IsAny<MakePendingRequest>()))
                .Returns(ParameterSet);
        }

        public IBookingService GetService()
        {
            return new Application.Implementations.BookingService(
                BookingRepository.Object,
                MakePendingParameterSetMapper.Object,
                Log.Object);
        }
    }
}
