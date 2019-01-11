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
        public ActionResult PlayerListIndex(string BtnNext, string sortOrder, string searchString)
        {
            using (PVMEntities1 db = new PVMEntities1())
            {

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            

                var players = from s in db.Player
                              select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    players = players.Where(s => s.PlayerName.Contains(searchString));


                    }
                switch (sortOrder)
                {
                    case "name_desc":
                        players = players.OrderByDescending(s => s.PlayerName);
                        break;
 
                }

                return View(players.ToList());


            }
        }
        
        //SetupPage 1
        [HttpGet]
        public ActionResult SetupTeam1()
        {
            return View();

        }

        [HttpPost]
        public ActionResult SetupTeam1([Bind(Include = "Teamname, Keep, Midfield, Attack, Defend")] Team team)
        {

            try
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    db.Team.Add(team);
                    db.SaveChanges();
                }
                return RedirectToAction("SetupTeam2");
            }
            catch (Exception ex)
            {
                var exception = ex;
                return View();
            }

        }




        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                // TODO: Add insert logic here
                using (PVMEntities1 db = new PVMEntities1())
                {
                    db.Player.Add(player);
                    db.SaveChanges();
                }
                return RedirectToAction("PlayerListIndex");
            }
            catch
            {
                return View();
            }
        }



        //SetupPage 2
        [HttpGet]
        public ActionResult SetupTeam2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetupTeam2([Bind(Include = "TeamName, Keep, Midfield, Attack, Defend")] Team team)
        {

            try
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    db.Team.Add(team);
                    db.SaveChanges();
                }
                return RedirectToAction("ResultPage");
            }
            catch (Exception ex)
            {
                var exception = ex;
                return View();
            }

        }


        public ActionResult ResultPage()
        {
            return View();
            // Select players making calculation.

            //ViewBag.Team1 = getTeam1(); // return IEnumerable<Player>;
            //ViewBag.Team2 = getTeam2(); // return IEnumerable<Player>;

   
     


        }

        // GET: PlayerList/Details/5
        public ActionResult Details(int id)
        {
            using (PVMEntities1 db = new PVMEntities1())
            {
                return View(db.Player.Where(x => x.ID == id).FirstOrDefault()); 
            }

        }

        // GET: PlayerList/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: PlayerList/Create
        //[HttpPost]
        //public ActionResult Create(Player player)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        using (PVMEntities1 db = new PVMEntities1())
        //        {
        //            db.Player.Add(player);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("PlayerListIndex");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // GET: PlayerList/Edit/5
        public ActionResult Edit(int id)
        {
            using (PVMEntities1 db = new PVMEntities1())
            {
                return View(db.Player.Where(x => x.ID == id).FirstOrDefault()); ;
            }
            //Player player = player.GetPlayer(id);
            //return View(player);
        }

        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "ID,PlayerName,Keep,Midfield,Attack,Defend")] Player player)
        {
            try
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChanges();
                }                    
                return RedirectToAction("PlayerListIndex");
            }
            catch (Exception)
            {
                return View();
            }

          
        }


        // POST: PlayerList/Edit/5
        public ActionResult EditPlayer(int id, string name, int keep, int midfield, int attack, int defend)
        {
            try
            {
                // TODO: Add update logic here
                using (PVMEntities1 db = new PVMEntities1())
                {
                    var player = db.Player.Where(x => x.ID == id).FirstOrDefault();
                    player.PlayerName = name;
                    player.Keep = keep;
                    player.Midfield = midfield;
                    player.Attack = attack;
                    player.Defend = defend;

                    db.Entry(player).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("PlayerListIndex");
            }
            catch (Exception)
            {
                return RedirectToAction("PlayerListIndex");

            }
        }

        //// GET: PlayerList/Delete/5
        public ActionResult Delete(int id)
        {
            Player player = new Player();

            using (PVMEntities1 db = new PVMEntities1())
            {
                player = db.Player.Where(x => x.ID == id).FirstOrDefault();                                
            }

            return View(player);
        }
                
        public ActionResult DeletePlayer(int id)
        {
            try
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    var player = db.Player.Where(x => x.ID == id).FirstOrDefault();
                    db.Player.Remove(player);
                    db.SaveChanges();
                }

                return RedirectToAction("PlayerListIndex");
            }
            catch (Exception)
            {
                return RedirectToAction("PlayerListIndex");
            }
            
        }





    }



    }
