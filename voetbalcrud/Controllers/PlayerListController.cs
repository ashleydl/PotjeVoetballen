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
                return View(db.Players.ToList());
            }

        }

        // GET: PlayerList/Details/5
        public ActionResult Details(int id)
        {
            using (PVMEntities db = new PVMEntities())
            {
                return View(db.Players.Where(x => x.PlayerID == id).FirstOrDefault()); ;
            }

        }

        // GET: PlayerList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
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
                    player = db.Players.Where(x => x.PlayerID == id).FirstOrDefault();
                    db.Players.Remove(player);
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
        public ActionResult SetPosition(PlayerPosition playerPosition)
        {
            try
            {
                // TODO: Add update logic here
                using (PVMEntities db = new PVMEntities())
                {
                    db.Entry(playerPosition).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Teams");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerList/Create
        public ActionResult AskTeamName()
        {
            return View();
        }

        // POST: PlayerList/
        [HttpPost]
        

        public ActionResult AskTeamName(Team model)
        {
            try
            {
                PVMEntities db = new PVMEntities();
                Team emp = new Team();
                emp.TeamName = model.TeamName;
                db.Team.Add(emp);
                db.SaveChanges();

                int latestEmpId = emp.TeamID;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
    }
}