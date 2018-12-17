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
        
        [HttpGet]
        public ActionResult SetupTeam1(/*string BtnNext, string BtnPrev, Setup setup*/)
        {
            return View();

            //if (btnnext != null)
            //{
            //    try
            //    {
            //        pvmentities1 db = new pvmentities1();
            //        setup set = new setup
            //        {
            //            amountattack = setup.amountattack,
            //            amountdefend = setup.amountdefend,
            //            amountkeep = setup.amountkeep,
            //            amountmidfield = setup.amountmidfield
            //        };

            //        db.setup.add(set);
            //        db.savechanges();

            //        int latestsetid = set.id;

            //    }
            //    catch
            //    {
            //        return redirecttoaction("setuppage");
            //    }

            //    if (btnnext != null)
            //    {
            //        return redirecttoaction("teamname");
            //    }
            //    return view();
            //}

            //if (btnprev != null)
            //{
            //    return redirecttoaction("index");
            //}
            //return view();
        }

        [HttpPost]
        public ActionResult SetupTeam1([Bind(Include = "AmountKeep, AmountMidfield, AmountAttack, AmountDefend")] Setup setup)
        {
            
                try
                {
                    using (PVMEntities1 db = new PVMEntities1())
                    {
                        db.Entry(setup).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("SetupTeam2");
                }
                catch (Exception)
                {
                    return View();
                }
            
        }


        [HttpGet]
        public ActionResult SetupTeam2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetupTeam2([Bind(Include = "AmountKeep, AmountMidfield, AmountAttack, AmountDefend")] Setup setup)
        {
            try
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    db.Entry(setup).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("TeamName");
            }
            catch (Exception)
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult TeamName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeamName([Bind(Include = "Teamname, Teamname")] Team team)
        {
            try
            {
                using (PVMEntities1 db = new PVMEntities1())
                {
                    db.Entry(team).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("ResultPage");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult ResultPage()
        {
            // Select players making calculation.

            //ViewBag.Team1 = getTeam1(); // return IEnumerable<Player>;
            //ViewBag.Team2 = getTeam2(); // return IEnumerable<Player>;

            /*
         * Het aantal spelers moeten geteld worden om te kunnen delen. 
         * if players cannot be devide by 2, set 1 player random as extra.

         * 
         * Berekening 1.
         * Als er 2 spelers zijn met getal 5 worden de 2 spelers bij keep gezet. 
         * Als er boven de 2 spelers zijn met getal 5 worden er daarvan random 2 gekozen.
         * Als er 1 speler is die het getal 4 heeft voor {positie} wordt de speler bij keep gezet. Als er 0 spelers het getal 4 hebben wordt er gekeken over 1 speler het getal 3 heeft.
         * Als er 1 speler is die het getal 3 heeft voor {positie} wordt de speler bij keep gezet. Als er 0 spelers het getal 3 hebben wordt er gekeken over 1 speler het getal 2 heeft.
         * Als er 1 speler is die het getal 2 heeft voor {positie} wordt de speler bij keep gezet. Als er 0 spelers het getal 2 hebben wordt er gekeken over 1 speler het getal 3 heeft.
         * 
         * Calculation 1.
         * Search for the players who have the number 5 for keep. If more than 2 persons have keep, choose 2 persons randomly for the teams. If only 1 person have 5
         * for keep, search for players who have the number 4 and choose randomly if there are more. If there's no person with 4, search for 3, and choose randomly if there are more,
         * Same for 2 and 1. 
         * 
         * if(keep = 5)
         * {
         *  db.Team.Add(player)
         *  db.SaveChanges();
         * }
         * 
         * In de database staat aangegeven hoeveel spelers per team per positie zijn ingedeeld. Na keep (keep heeft standaard 1) wordt er gekeken of er nog een positie is die 1 speler gebruikt. Als er meer posities zijn
         * die 1 speler gebruiken wordt er daarvan een random positie gekozen om als eerst mee te zoeken naar een speler. 
         * De naam van de positie wordt gebruikt om door de spelers heen te zoeken naar het getal 5. Hier wordt berekening 1 gebruikt.
         * 
         * Berekening 2.
         * Als er geen posities meer zijn die (1) speler nodig hebben, wordt er gekeken naar een positie die (2) spelers nodig hebben, als er meerdere posities (2) spelers nodig hebben wordt er daarvan een random positie gekozen
         * om als eerst mee te zoeken naar een speler. 
         * Hier wordt berekening 1 weer bij gebruikt, maar dan met een andere positienaam.
         * 
         * Berekening 2 wordt uitgevoerd tot 16 spelers. 
         * 
         * 
         * 
        */

            return View();
        }
        
        // GET: PlayerList/Details/5
        public ActionResult Details(int id)
        {
            using (PVMEntities1 db = new PVMEntities1())
            {
                return View(db.Player.Where(x => x.ID == id).FirstOrDefault()); ;
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

            //using (PVMEntities1 db = new PVMEntities1())
            //{
            //    return View(db.Player.Where(x => x.ID == id).FirstOrDefault()); ;
            //}

            //Player player = player.GetPlayer(id);
            //return View(player);
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

        // POST: PlayerList/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        using (PVMEntities1 db = new PVMEntities1())
        //        {                    
        //            Player player = db.Player.Where(x => x. ID == id).FirstOrDefault();
        //            db.Player.Remove(player);
        //            db.SaveChanges();
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}




    }



    }
