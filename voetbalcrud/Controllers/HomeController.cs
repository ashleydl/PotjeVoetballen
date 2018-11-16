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

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            MvcCrudEntities1 entities = new MvcCrudEntities1();
            var Players = (from PlayersTable in entities.PlayersTable
                             where PlayersTable.PlayerName.StartsWith(prefix)
                             select new
                             {
                                 label = PlayersTable.PlayerName,
                                 val = PlayersTable.PlayerID
                             }).ToList();

            return Json(Players);
        }

        [HttpPost]
        public ActionResult Index(string PlayerName, string PlayerId)
        {
            ViewBag.Message = "CustomerName: " + PlayerName + " CustomerId: " + PlayerId;
            return View();
        }
    }
}

       
