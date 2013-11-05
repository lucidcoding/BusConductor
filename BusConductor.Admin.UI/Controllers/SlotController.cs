using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusConductor.Admin.UI.Controllers
{
    public class SlotController : Controller
    {
        //
        // GET: /BusSlot/

        public ActionResult Index(Guid busId)
        {
            return View();
        }

    }
}
