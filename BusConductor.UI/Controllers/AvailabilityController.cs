using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.ActionFilters;
using BusConductor.UI.ViewModelMappers.Availability;
using BusConductor.UI.ViewModels.Availability;

namespace BusConductor.UI.Controllers
{
    public class AvailabilityController : Controller
    {
        private readonly IBusRepository _busRepository;

        public AvailabilityController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        [EntityFrameworkReadContext]
        public ActionResult Index()
        {
            var busses = _busRepository.GetAll();
            var viewModel = IndexViewModelMapper.Map(busses);
            return View(viewModel);
        }
    }
}
