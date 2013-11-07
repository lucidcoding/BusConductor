using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.ActionFilters;
using BusConductor.UI.ViewModels.Rates;

namespace BusConductor.UI.Controllers
{
    public class RatesController : Controller
    {
        private readonly IBusRepository _busRepository;

        public RatesController(IBusRepository busRepository)
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
                busViewModel.BusId = bus.Id.Value;
                busViewModel.Name = bus.Name;
                busViewModel.MainImageUrl = VirtualPathUtility.ToAbsolute("~/Images/bluebell_sm_121109.jpg");
                busViewModel.WinterMondayToFriday = bus.GetWinterMondayToFridayRate();
                busViewModel.WinterFridayToMonday = bus.GetWinterFridayToMondayRate();
                busViewModel.WinterFridayToFriday = bus.GetWinterFridayToFridayRate();
                busViewModel.SpringMondayToFriday = bus.GetSpringMondayToFridayRate();
                busViewModel.SpringFridayToMonday = bus.GetSpringFridayToMondayRate();
                busViewModel.SpringFridayToFriday = bus.GetSpringFridayToFridayRate();
                busViewModel.SummerMondayToFriday = bus.GetSummerMondayToFridayRate();
                busViewModel.SummerFridayToMonday = bus.GetSummerFridayToMondayRate();
                busViewModel.SummerFridayToFriday = bus.GetSummerFridayToFridayRate();
                busViewModel.AutumnMondayToFriday = bus.GetAutumnMondayToFridayRate();
                busViewModel.AutumnFridayToMonday = bus.GetAutumnFridayToMondayRate();
                busViewModel.AutumnFridayToFriday = bus.GetAutumnFridayToFridayRate();
                viewModel.Busses.Add(busViewModel);
            }

            return View(viewModel);
        }

    }
}
