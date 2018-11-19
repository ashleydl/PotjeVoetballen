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

        public ActionResult Teams()
        {
            MvcCrudEntities1 mvcCrudEntity = new MvcCrudEntities1();
            var getNameList = mvcCrudEntity.PlayersTable.ToList();
            SelectList list = new SelectList(getNameList,"PlayerID", "PlayerName");
            ViewBag.PlayerNameList = list;
            return View();
        }
      
    }
}

       
