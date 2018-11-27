using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using voetbalcrud.Models;


namespace voetbalcrud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Spelers()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult IndexPosition()
        {

            return View("IndexPosition");
        }

        public ActionResult Teams()
        {

            PotjeVoetballenDBEntities mvcCrudEntity = new PotjeVoetballenDBEntities();
            var getNameList = mvcCrudEntity.Players.ToList();
            SelectList list = new SelectList(getNameList,"ID", "PlayerName");
            ViewBag.PlayerNameList = list;
            return View();

        }
      
    }
}

       
