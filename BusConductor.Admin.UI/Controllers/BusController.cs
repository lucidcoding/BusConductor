using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusConductor.Admin.UI.ActionFilters;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.Admin.UI.ViewModels.Bus;

namespace BusConductor.Admin.UI.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusRepository _busRepository;

        public BusController(IBusRepository busRepository)
        {
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
                busViewModel.Id = bus.Id.Value;
                busViewModel.Name = bus.Name;
                busViewModel.Description = bus.Description;
                viewModel.Busses.Add(busViewModel);
            }

            return View(viewModel);
        }

    }
}
