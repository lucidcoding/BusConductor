﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusConductor.Application.Requests.Booking;
using BusConductor.UI.ViewModels.Booking;

namespace BusConductor.UI.ViewModelMappers.Booking
{
    public static class MakeViewModelMapper
    {
        public static MakeViewModel Map(Guid busId)
        {
            var viewModel = new MakeViewModel();
            viewModel.BusId = busId;
            viewModel.IsMainDriver = true;
            Initialize(viewModel);
            return viewModel;
        }

        //todo: think of a more meaningful name for this.
        public static void Initialize(MakeViewModel viewModel)
        {
            if(viewModel.IsMainDriver)
            {
                viewModel.AlternateDriverAdditionalClasses = "hide";
            }

            viewModel.NumberOfAdultsOptions = new SelectList(new List<SelectListItem>
                                                                 {
                                                                     new SelectListItem
                                                                         {Selected = true, Text = "0", Value = "0"},
                                                                     new SelectListItem
                                                                         {Text = "1", Value = "1"},
                                                                     new SelectListItem
                                                                         { Text = "2", Value = "2"},
                                                                     new SelectListItem
                                                                         {Text = "3", Value = "3"},
                                                                     new SelectListItem
                                                                         {Text = "4", Value = "4"},
                                                                     new SelectListItem
                                                                         {Text = "5", Value = "5"},
                                                                     new SelectListItem
                                                                         { Text = "6", Value = "6"},
                                                                 }, "Value", "Text");

            viewModel.NumberOfChildrenOptions = new SelectList(new List<SelectListItem>
                                                                 {
                                                                     new SelectListItem
                                                                         {Selected = true, Text = "0", Value = "0"},
                                                                     new SelectListItem
                                                                         {Text = "1", Value = "1"},
                                                                     new SelectListItem
                                                                         {Text = "2", Value = "2"},
                                                                     new SelectListItem
                                                                         {Text = "3", Value = "3"},
                                                                     new SelectListItem
                                                                         {Text = "4", Value = "4"},
                                                                     new SelectListItem
                                                                         {Text = "5", Value = "5"},
                                                                     new SelectListItem
                                                                         {Text = "6", Value = "6"},
                                                                 }, "Value", "Text");
            
        }

        public static MakePendingRequest Map(MakeViewModel viewModel)
        {
            var request = new MakePendingRequest();
            request.BusId = viewModel.BusId;
            request.PickUp = viewModel.PickUp.HasValue ? viewModel.PickUp.Value : (DateTime?)null;
            request.DropOff = viewModel.DropOff.HasValue ? viewModel.DropOff.Value : (DateTime?)null;
            request.Forename = viewModel.Forename;
            request.Surname = viewModel.Surname;
            request.AddressLine1 = viewModel.AddressLine1;
            request.AddressLine2 = viewModel.AddressLine2;
            request.AddressLine3 = viewModel.AddressLine3;
            request.Town = viewModel.Town;
            request.County = viewModel.County;
            request.PostCode = viewModel.PostCode;
            request.Email = viewModel.Email;
            request.TelephoneNumber = viewModel.TelephoneNumber;
            request.IsMainDriver = viewModel.IsMainDriver;
            request.DrivingLicenceNumber = viewModel.DrivingLicenceNumber;
            request.DriverForename = viewModel.DriverForename;
            request.DriverSurname = viewModel.DriverSurname;
            request.NumberOfAdults = viewModel.NumberOfAdults;
            request.NumberOfChildren = viewModel.NumberOfChildren;
            request.VoucherCode = viewModel.VoucherCode;
            return request;
        }
    }
}