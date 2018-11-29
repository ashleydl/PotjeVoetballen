using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using voetbalcrud.Models;

namespace voetbalcrud.Controllers
{
    public class PlayerListController : Controller
    {
        // GET: PlayerList
        public ActionResult Index()
        {
            using (PVMEntities db = new PVMEntities())
            {
                return View(db.Player.ToList());
            }
            
        }

        // GET: PlayerList/Details/5
        public ActionResult Details(int id)
        {
            using (PVMEntities db = new PVMEntities())
            {
                return View(db.Player.Where(x => x.PlayerID == id).FirstOrDefault());  ;
            }
               
        }

        // GET: PlayerList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerList/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                // TODO: Add insert logic here
                using (PVMEntities db = new PVMEntities())
                {
                    db.Player.Add(player);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerList/Edit/5
        public ActionResult Edit(int id)
        {
            using (PVMEntities db = new PVMEntities())
            {
                return View(db.Player.Where(x => x.PlayerID == id).FirstOrDefault()); ;

            }
        }

        // POST: PlayerList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Player player)
        {
            try
            {
                // TODO: Add update logic here
                using (PVMEntities db = new PVMEntities())
                {
                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayerList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Player player)
        {
            try
            {
                using (PVMEntities db = new PVMEntities())
                {
                    player = db.Player.Where(x => x.PlayerID == id).FirstOrDefault();
                    db.Player.Remove(player);
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerList/Create
        public ActionResult SetPosition()
        {
            return View();
        }

        // POST: PlayerList/
        [HttpPost]
        public ActionResult SetPosition(int id, Player player)
        {
            try
            {
                // TODO: Add update logic here
                using (PVMEntities db = new PVMEntities())
                {
                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChanges();
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
