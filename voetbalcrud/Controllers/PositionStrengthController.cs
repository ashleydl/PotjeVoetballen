using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using voetbalcrud.Models;

namespace voetbalcrud.Controllers
{
    public class PositionStrengthController : Controller
    {
        // GET: PositionStrength
        public ActionResult Index()
        {
            PositionStrength positionStrength = new PositionStrength();
            List<PositionDescription> positionDescriptions = positionStrength.PositionDescription.ToList();
            return View(positionDescriptions);
        }
    }
}