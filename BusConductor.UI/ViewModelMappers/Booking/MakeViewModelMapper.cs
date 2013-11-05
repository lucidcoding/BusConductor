using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusConductor.Application.Requests.Booking;
using BusConductor.UI.ViewModels.Booking;

namespace BusConductor.UI.ViewModelMappers.Booking
{
    public static class MakeViewModelMapper
    {
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
            request.NumberOfAdults = viewModel.NumberOfAdults;
            request.NumberOfChildren = viewModel.NumberOfChildren;
            request.VoucherCode = viewModel.VoucherCode;
            return request;
        }
    }
}