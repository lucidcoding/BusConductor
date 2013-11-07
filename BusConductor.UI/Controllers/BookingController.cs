using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusConductor.Application.Contracts;
using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.ActionFilters;
using BusConductor.UI.ViewModelMappers.Booking;
using BusConductor.UI.ViewModels.Booking;

namespace BusConductor.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBusRepository _busRepository;

        public BookingController(
            IBookingService bookingService,
            IBusRepository busRepository)
        {
            _bookingService = bookingService;
            _busRepository = busRepository;
        }

        //[NHibernateSession]
        public ActionResult Index()
        {
            var busses = _busRepository.GetAll();
            var viewModel = new IndexViewModel();
            viewModel.Busses = new List<IndexBusViewModel>();

            foreach(var bus in busses)
            {
                var busViewModel = new IndexBusViewModel();
                busViewModel.BusId = bus.Id.Value;
                busViewModel.Name = bus.Name;
                busViewModel.MainImageUrl = VirtualPathUtility.ToAbsolute("~/Images/bluebell_sm_121109.jpg");
                viewModel.Busses.Add(busViewModel);
            }

            return View(viewModel);
        }

        [Log]
        //[NHibernateSession]
        public ActionResult Make(Guid busId)
        {
            var viewModel = new MakeViewModel();
            viewModel.BusId = busId;
            viewModel.IsMainDriver = true;
            return View(viewModel);
        }

        [Log]
        [HttpPost]
        //[NHibernateSession]
        public ActionResult Review(MakeViewModel inViewModel)
        {
            //if (!ModelState.IsValid) return View("Make", inViewModel);
            var request = MakeViewModelMapper.Map(inViewModel);
            var validationMessages = _bookingService.ValidateMakePending(request);
            validationMessages.ForEach(validationMessage => ModelState.AddModelError(validationMessage.Field, validationMessage.Text));
            if(!ModelState.IsValid) return View("Make", inViewModel);
            var booking = _bookingService.SummarizePendingBooking(request);
            var outViewModel = ReviewViewModelMapper.Map(booking);
            return View(outViewModel);
        }

        [Log]
        [HttpPost]
        //[NHibernateSession]
        public ActionResult Confirm(ReviewViewModel viewModel)
        {
            var request = ReviewViewModelMapper.Map(viewModel);
            _bookingService.MakePending(request);
            //todo:email and confirmation message
            return View("Completed");
        }
    }
}
