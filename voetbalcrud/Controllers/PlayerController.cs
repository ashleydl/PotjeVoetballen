using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using voetbalcrud.Models;

namespace voetbalcrud.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player/Index
        public ActionResult Index()
        {
            using (MvcCrudEntities1 db = new MvcCrudEntities1())
            {
                return View(db.Players.ToList());
            }
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            using (MvcCrudEntities1 db = new MvcCrudEntities1())
            {
                return View(db.Players.Where(x => x.ID == id).FirstOrDefault()); ;
            }
        }


        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(Player player, Position position)
        {

            try
            {
                // TODO: Add insert logic here
                using (MvcCrudEntities1 db = new MvcCrudEntities1())
                {
                    db.Players.Add(player);
                    db.Positions.Add(position);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            using (MvcCrudEntities1 db = new MvcCrudEntities1())
            {
                return View(db.Players.Where(x => x.ID == id).FirstOrDefault()); ;
            }
        }

        // POST: Player/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Player player)
        {
            try
            {
                // TODO: Add update logic here
                using (MvcCrudEntities1 db = new MvcCrudEntities1())

                {

                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {

            {
                return View();
            }
        }

        // POST: Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Player player)
        {
            try
            {
                // TODO: Add delete logic here
                using (MvcCrudEntities1 db = new MvcCrudEntities1())
                {
                    player = db.Players.Where(x => x.ID == id).FirstOrDefault();
                    if (player != null)
                    {
                        db.Players.Remove(player);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
