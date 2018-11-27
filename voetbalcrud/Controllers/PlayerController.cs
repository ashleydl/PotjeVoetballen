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
            using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())
            {
                return View(db.Players.ToList());
            }
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())
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
        public ActionResult Create(Player player, Position position, List<PlayerPositionStrength> strength)
        {

            try
            {
                // TODO: Add insert logic here
                using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())
                {
                    foreach (var item in strength)
                    {
                        player.PlayerPositionStrengths.Add(item);
                    }
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
            using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())
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
                using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())

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
                using (PotjeVoetballenDBEntities db = new PotjeVoetballenDBEntities())
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
