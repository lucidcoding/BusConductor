﻿using BusConductor.Domain.Entities;

namespace BusConductor.Domain.ParameterSets
{
    public class RegisterCustomerParameterSet
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public User CurrentUser { get; set; }

        public static RegisterCustomerParameterSet MapFrom(MakePendingBookingParameterSet makePendingBookingParameterSet)
        {
            var registerCustomerParameterSet = new RegisterCustomerParameterSet();
            //todo: pass in user
            //registerCustomerParameterSet.GuestRole = makePendingBookingParameterSet.GuestRole;
            registerCustomerParameterSet.Forename = makePendingBookingParameterSet.Forename;
            registerCustomerParameterSet.Surname = makePendingBookingParameterSet.Surname;
            registerCustomerParameterSet.AddressLine1 = makePendingBookingParameterSet.AddressLine1;
            registerCustomerParameterSet.AddressLine2 = makePendingBookingParameterSet.AddressLine2;
            registerCustomerParameterSet.AddressLine3 = makePendingBookingParameterSet.AddressLine3;
            registerCustomerParameterSet.Town = makePendingBookingParameterSet.Town;
            registerCustomerParameterSet.County = makePendingBookingParameterSet.County;
            registerCustomerParameterSet.PostCode = makePendingBookingParameterSet.PostCode;
            registerCustomerParameterSet.Email = makePendingBookingParameterSet.Email;
            registerCustomerParameterSet.TelephoneNumber = makePendingBookingParameterSet.TelephoneNumber;
            registerCustomerParameterSet.CurrentUser = makePendingBookingParameterSet.CurrentUser;
            return registerCustomerParameterSet;
        }
    }
}