using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using voetbalcrud.Models;

namespace voetbalcrud.Controllers
{
    public class SetUpController : Controller
    {
            // GET: Setup
            public ActionResult Index()
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    return View(db.Setup.ToList());
                }

            }

        // GET: Setup/Details/5
        public ActionResult Details(int id)
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    return View(db.Setup.Where(x => x.ID == id).FirstOrDefault()); ;
                }

            }

        // GET: Setup/Create
        public ActionResult Create()
            {
                return View();
            }

        // POST: Setup/Create
        [HttpPost]
            public ActionResult Create(Setup setup)
            {
                try
                {
                    // TODO: Add insert logic here
                    using (PVMEntities1 db = new PVMEntities1())
                    {
                        db.Setup.Add(setup);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

        // GET: Setup/Edit/5
        public ActionResult Edit(int id)
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    return View(db.Setup.Where(x => x.ID == id).FirstOrDefault()); ;

                }
            }

        // POST: Setup/Edit/5
        [HttpPost]
            public ActionResult Edit(int id, Setup setup)
            {
                try
                {
                    // TODO: Add update logic here
                    using (PVMEntities1 db = new PVMEntities1())
                    {
                    db.Entry(setup).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

        // GET: Setup/Delete/5
        public ActionResult Delete(int id)
            {
                return View();
            }

        // POST: Setup/Delete/5
        [HttpPost]
            public ActionResult Delete(int id, Setup setup)
            {
                try
                {
                    using (PVMEntities1 db = new PVMEntities1())
                    {
                        setup = db.Setup.Where(x => x.ID == id).FirstOrDefault();
                        db.Setup.Remove(setup);
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
