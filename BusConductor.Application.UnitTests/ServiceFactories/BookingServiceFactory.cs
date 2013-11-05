using System;
using System.Collections.Generic;
using BusConductor.Application.Contracts;
using BusConductor.Application.ParameterSetMappers.Booking;
using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.Entities;
using BusConductor.Domain.ParameterSets;
using BusConductor.Domain.RepositoryContracts;
using Moq;

namespace BusConductor.Application.UnitTests.ServiceFactories
{
    public class BookingServiceFactory
    {
        public Mock<IBookingRepository> BookingRepository { get; set; }
        public Mock<IMakePendingParameterSetMapper> MakePendingParameterSetMapper { get; set; }
        public Bus Bus { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public Voucher Voucher { get; set; }
        public Booking Booking { get; set; }
        public MakePendingBookingParameterSet ParameterSet { get; set; }

        public BookingServiceFactory()
        {
            MakePendingParameterSetMapper = new Mock<IMakePendingParameterSetMapper>();
            BookingRepository = new Mock<IBookingRepository>();
            Bus = new Bus { Id = Guid.NewGuid(), Bookings = new List<Booking>() };
            User = new User { Id = Guid.NewGuid() };
            Role = new Role { Id = Guid.NewGuid() };
            Voucher = new Voucher { Id = Guid.NewGuid(), Code = "ABC123" };

            ParameterSet = new MakePendingBookingParameterSet();
            ParameterSet.PickUp = new DateTime(2090, 10, 1);
            ParameterSet.DropOff = new DateTime(2090, 10, 8);
            ParameterSet.Bus = Bus;
            ParameterSet.GuestRole = Role;
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
            ParameterSet.NumberOfAdults = 2;
            ParameterSet.NumberOfChildren = 2;
            ParameterSet.VoucherCode = Voucher.Code;
            ParameterSet.Voucher = Voucher;
            ParameterSet.CurrentUser = User;

            MakePendingParameterSetMapper
                .Setup(x => x.Map(It.IsAny<MakePendingRequest>()))
                .Returns(ParameterSet);
        }

        public IBookingService GetService()
        {
            return new Application.Implementations.BookingService(
                BookingRepository.Object,
                MakePendingParameterSetMapper.Object);
        }

    }
}
