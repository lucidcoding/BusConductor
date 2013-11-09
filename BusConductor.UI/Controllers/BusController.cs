using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.ActionFilters;
using BusConductor.UI.ViewModelMappers.Calendar;
using BusConductor.UI.ViewModels.Bus;
using Lucidity.Utilities;

namespace BusConductor.UI.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusRepository _busRepository;

        public BusController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        [EntityFrameworkReadContext]
        public ActionResult Index()
        {
            var busses = _busRepository.GetAll();

            var viewModel = new IndexViewModel();
            viewModel.Busses = new List<IndexBusViewModel>();

            foreach (var bus in busses)
            {
                var busViewModel = PropertyMapper.MapMatchingProperties<Bus, IndexBusViewModel>(bus);
                //Make the mapper map nullable to non nullables
                busViewModel.Id = bus.Id.Value;
                busViewModel.MainImageUrl = VirtualPathUtility.ToAbsolute("~/Images/bluebell_sm_121109.jpg");
                viewModel.Busses.Add(busViewModel);
            }

            return View(viewModel);
        }

        [EntityFrameworkReadContext]
        public ActionResult Details(Guid id)
        {
            //todo: get with only the required bookings.
            var bus = _busRepository.GetById(id);
            var now = DateTime.Now;
            var viewModel = PropertyMapper.MapMatchingProperties<Bus, DetailsViewModel>(bus);
            viewModel.Id = bus.Id.Value;
            viewModel.Calendar = DisplayMonthViewModelModelMapper.Map(now.Year, now.Month, bus);
            return View(viewModel);
        }
    }
}
