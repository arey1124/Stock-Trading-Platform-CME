using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StockTradingPlatform.Models;

namespace StockTradingPlatform.Controllers
{
    
    public class AdminController : Controller
    {
        /// <summary>
        /// check out my push
        /// </summary>
        private StpDBEntities db = new StpDBEntities();

        private UserManager manager = new UserManager();
        // GET: Admin
       
            //index is dashboard
            public ActionResult Index()
        {
          if (Session["user"] == null || Session["userName"] == null)
             return Redirect("~/Login.aspx");
            //check
            List<DataPoint> BardataPoints = new List<DataPoint>();
            foreach (var admins in manager.StpDBEntities.tblStocks.GroupBy(x => x.addedBy).Select(group => new {
                Metric = group.Key,
                Count = group.Count()
            }))
            {
                System.Diagnostics.Debug.WriteLine("{0} {1}", admins.Metric, admins.Count);
                var admin = manager.StpDBEntities.tblUsers.Find(admins.Metric);
                BardataPoints.Add(new DataPoint(admin.fname + " " + admin.lname, admins.Count));
            }


            List<DataPoint> PiedataPoints = new List<DataPoint>();
            foreach (var admins in manager.StpDBEntities.tblTradeRequests.GroupBy(x => x.requestStatus).Select(group => new {
                Metric = group.Key,
                Count = group.Count()
            }))
            {
                System.Diagnostics.Debug.WriteLine("{0} {1}", admins.Metric, admins.Count);
                string type = string.Empty;
                switch (admins.Metric)
                {
                    case "D":
                        type = "Filled";
                        break;
                    case "O":
                        type = "Open";
                        break;
                    case "P":
                        type = "Partially Filled";
                        break;
                    case "C":
                        type = "Cancelled";
                        break;

                }
                PiedataPoints.Add(new DataPoint(type, admins.Count));
            }



            ViewBag.BarDataPoints = JsonConvert.SerializeObject(BardataPoints);
            ViewBag.PieDataPoints = JsonConvert.SerializeObject(PiedataPoints);
            //
            var user = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(user.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname= u.lname;
            ViewBag.usercount = string.Format("{0:n0}", manager.StpDBEntities.tblUsers.Where(x => x.status == "A" && x.role == "U").Count());
            ViewBag.stockcount = string.Format("{0:n0}", manager.StpDBEntities.tblStocks.Where(x => x.status == "A").Count());
            ViewBag.traderequestcount = string.Format("{0:n0}", manager.StpDBEntities.tblTradeRequests.Count());
            ViewBag.transactionscount = string.Format("{0:n0}", manager.StpDBEntities.tblTransactions.Count());

            return View();
        }

        public ContentResult JSON1()
        {
            List<DataPoint> BardataPoints = new List<DataPoint>();
            foreach (var admins in manager.StpDBEntities.tblStocks.GroupBy(x => x.addedBy).Select(group => new {
                Metric = group.Key,
                Count = group.Count()
            }))
            {
                System.Diagnostics.Debug.WriteLine("{0} {1}", admins.Metric, admins.Count);
                var admin = manager.StpDBEntities.tblUsers.Find(admins.Metric);
                BardataPoints.Add(new DataPoint(admin.fname + " " + admin.lname, admins.Count));
            }

            return Content(JsonConvert.SerializeObject(BardataPoints, _jsonSetting), "application/json");
        }

        public ContentResult JSON()
        {
            List<DataPoint> PiedataPoints = new List<DataPoint>();
            foreach (var admins in manager.StpDBEntities.tblTradeRequests.GroupBy(x => x.requestStatus).Select(group => new {
                Metric = group.Key,
                Count = group.Count()
            }))
            {
                System.Diagnostics.Debug.WriteLine("{0} {1}", admins.Metric, admins.Count);
                string type = string.Empty;
                switch (admins.Metric)
                {
                    case "D":
                        type = "Filled";
                        break;
                    case "O":
                        type = "Open";
                        break;
                    case "P":
                        type = "Partially Filled";
                        break;
                    case "C":
                        type = "Cancelled";
                        break;
                }
                PiedataPoints.Add(new DataPoint(type, admins.Count));
            }

            return Content(JsonConvert.SerializeObject(PiedataPoints, _jsonSetting), "application/json");
        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };


        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["userName"] = null;
            return Redirect("~/Login.aspx");
        }

        //above code is chayank's







        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// prajjwal's code starts
        /// </summary>
        /// <returns></returns>
        public ActionResult AllUsersTradeRequests()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var user = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(user.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            var tblTradeRequests = db.tblTradeRequests.Include(t => t.tblStock).Include(t => t.tblUser);
            return View(tblTradeRequests.ToList());
        }
        
     
        // GET: tblUsers
        public ActionResult ViewUsers() //AdminController => ViewUsers()
        {
            

            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var user = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(user.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            return View(db.tblUsers.ToList());
        }

        [HttpPost]
        public ActionResult ViewUsers(string searchbox) //AdminController => ViewUsers()
        {
            string text = searchbox;
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
           
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            text = text.ToLower();
            List<tblUser> users = new List<tblUser>();
            foreach (tblUser user in db.tblUsers)
            {
                if (user.fname.ToLower().Contains(text) || user.lname.ToLower().Contains(text) || user.email.ToLower().Contains(text) || user.address.ToLower().Contains(text))
                {
                    if (text == "admin" && user.role == "A")
                        users.Add(user);
                    else if (text == "trader" && user.role == "U")
                        users.Add(user);
                    else if (text == "active" && user.status == "A")
                        users.Add(user);
                    else if (text == "suspended" && user.status == "S")
                        users.Add(user);
                    else if (user.fname.ToLower().Contains(text) || user.lname.ToLower().Contains(text) || user.email.ToLower().Contains(text) || user.address.ToLower().Contains(text))
                        users.Add(user);
                }
            }
            return View(users);
        }


        // GET: tblUsers/Edit/5
        public ActionResult EditUser(int? id) //AdminController => EditUser()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: tblUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "uid,fname,lname,email,mobile,dob,address,role,status")] tblUser tblUsers)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            if (ModelState.IsValid)
            {
                db.Entry(tblUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewUsers");
            }
            return View(tblUsers);
        }

        // GET: tblTransactions
        public ActionResult AllTransactions()     
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends


            TransactionsManager model = new TransactionsManager();
            return View(model);
        }




        /// <summary>
        /// prajjwals code ends
        /// </summary>
        /// <returns></returns>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////chayank's code starts
        //below everything related to stock chyaank's code below
        public ActionResult Profile()
        {
           if (Session["user"] == null || Session["userName"] == null)
               return Redirect("~/Login.aspx");
            var user = Session["user"] as tblUser;
            string education = "Computer Science";
            
            if (user.fname == "Prajjwal") education = "Computer Science from LPU,Punjab";
            if (user.fname == "Arihant") education = "Computer science from Manipal University,Jaipur";
            if(user.fname=="Chayank") education = "Information Science from SJCE,Mysore";
            tblUser u = manager.StpDBEntities.tblUsers.Find(user.uid);

            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            ViewBag.mob = u.mobile;
            ViewBag.userName = Session["userName"].ToString();
            ViewBag.education = education;

            
            ViewBag.uid = user.uid;
            return View();
        }

        public ActionResult EditAdminUser(int id)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            tblUser tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdminUser([Bind(Include = "uid,fname,lname,email,mobile,dob,address,role,status")] tblUser tblUsers)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

            if (ModelState.IsValid)
            {
                db.Entry(tblUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile");
            }
            return View(tblUsers);
        }


        public ActionResult ListOfStocks()
        {//to pass two models in one onject
           if (Session["user"] == null || Session["userName"] == null)
               return Redirect("~/Login.aspx");

            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends
            StockManager model = new StockManager();
            
            return View(model);
        }


        // get : addStock
        public ActionResult AddStock()
        {
           if (Session["user"] == null || Session["userName"] == null)
               return Redirect("~/Login.aspx");
            //code for showing who signed in -
            
            var us = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(us.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends
            ViewBag.name = "ADD STOCK";
            StockManager model = new StockManager();

            return View(model);
        }

        //post for addstock
        [HttpPost]
        public ActionResult AddStock(string submit)
        {
             if (Session["user"] == null || Session["userName"] == null)
                 return Redirect("~/Login.aspx");
            
            //code for showing who signed in -
            
            var user = Session["user"] as tblUser;
            tblUser u1 = manager.StpDBEntities.tblUsers.Find(user.uid);
            ViewBag.fname = u1.fname;
             ViewBag.lname = u1.lname;
            //code ends
            
            int uid = user.uid;
            int id = Convert.ToInt32(submit);

            //get particular stock market data
            manager.tblMarketdata = manager.StpDBEntities.tblMarketdatas.Find(id);

            //inserted data to stock table
            manager.tblStock.stockId = 1;
                //(int)manager.StpDBEntities.getLastStockId().FirstOrDefault() + 1;
            manager.tblStock.stockName = manager.tblMarketdata.stockName;
            manager.tblStock.quantity = manager.tblMarketdata.qty;
            //calling a function to randomly give holdings to existing customers
            //give all users equal share of qty of stock and add to holdings table
            //reduce their respective wallet balance
            int qty = manager.tblMarketdata.qty.Value;
            System.Diagnostics.Debug.WriteLine("this is qty " +qty);
            var user_list = manager.StpDBEntities.tblUsers.Where(t=>t.role=="U" && t.status=="A").ToList();
            int user_count=user_list.Count();
            int share_per_user = qty / user_count;

            //checking if there are left overs after dividing
            int total_qty = share_per_user * user_count;
            int extra = 0;
            if (total_qty < qty) extra = qty - total_qty;
            //use extra 

            tblUser first_user=null;
            foreach(tblUser u in manager.StpDBEntities.tblUsers.Where(t => t.role == "U" && t.status == "A"))
            {
                if(first_user==null)
                { first_user = u; }
                int user_id = u.uid;
                tblHoldings holding = new tblHoldings();
                holding.uid = user_id;
                holding.stockId = manager.tblStock.stockId;
                holding.Qty = share_per_user;

                manager.StpDBEntities.tblHoldings.Add(holding);
           
            }

            if(extra != 0)
            {
                int user_id = first_user.uid;
                tblHoldings holding = new tblHoldings();
                holding.uid = user_id;
                holding.stockId = manager.tblStock.stockId;
                holding.Qty = share_per_user;

                manager.StpDBEntities.tblHoldings.Add(holding);
                
            }



            manager.tblStock.quantity_remaining = 0;
            manager.tblStock.addedBy = uid;
            manager.tblStock.status = "A";

            //insert into collection
            manager.StpDBEntities.tblStocks.Add(manager.tblStock);

           

            //inserted data to stock price table
            manager.tblStocksPrice.stockId = manager.tblStock.stockId;
            manager.tblStocksPrice.timeOfDay = DateTime.Now;
            manager.tblStocksPrice.currentPrice = manager.tblMarketdata.currentPrice;
            manager.tblStocksPrice.lowPrice = manager.tblMarketdata.currentPrice;
            manager.tblStocksPrice.highPrice = manager.tblMarketdata.currentPrice;

            //insert into collection
            manager.StpDBEntities.tblStocksPrices.Add(manager.tblStocksPrice);

            //change status to added in tbl market data
            manager.tblMarketdata.status = "A";

            //saving changes to databases
            manager.StpDBEntities.SaveChanges();

            return RedirectToAction("listofstocks");


        }


        // get : addStock
        public ActionResult EditStock(int id)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            var user = Session["user"] as tblUser;
            tblUser u = manager.StpDBEntities.tblUsers.Find(user.uid);
            ViewBag.fname = u.fname;
            ViewBag.lname = u.lname;
            //code ends

           
            manager.tblStock= manager.StpDBEntities.tblStocks.Single(x => x.stockId == id );
            int index = (int)manager.StpDBEntities.getIdexFromStockPriceTable(id).FirstOrDefault();
            manager.tblStocksPrice = manager.StpDBEntities.tblStocksPrices.Single(x => x.id==index);

            System.Diagnostics.Debug.WriteLine("this is a bug " + manager.tblStocksPrice.stockId +"  : price " + manager.tblStocksPrice.currentPrice);
            ViewBag.name = "EDIT";
            
            return View(manager);
        }

        //post for addstock
        [HttpPost]
        public ActionResult EditStock(StockManager ob)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");

            //code for showing who signed in -
            var user = Session["user"] as tblUser;
            ViewBag.fname = user.fname;
            ViewBag.lname = user.lname;
            //code ends

            System.Diagnostics.Debug.WriteLine("this is a bug " + ob.tblStocksPrice.stockId + "  : price " + ob.tblStocksPrice.currentPrice+"qty addded or subtracted "+ob.qty);

            //to check if qty added or subtracted is corrected
           




            // if a has a value, assign it to aNum, if not assign 0 to aNum

            int aNum = ob.qty.HasValue ? ob.qty.Value : 0;
            int bNum = (int)ob.tblStock.quantity;
            int cNum = (int)ob.tblStock.quantity_remaining;
            if (aNum < 0)
            {
                aNum = -aNum;
                System.Diagnostics.Debug.WriteLine("this is a bug " + ob.tblStocksPrice.stockId + "  : price " + ob.tblStocksPrice.currentPrice + "qty addded or subtracted " + ob.qty);

                if (aNum > cNum)
                {
                    System.Diagnostics.Debug.WriteLine("please enter valid quantity to be subtracted as it is more than quantity remaining");

                    ViewBag.error = "please enter valid quantity to be subtracted as it is more than quantity remaining";
                    ViewBag.name = "EDIT";
                    return View(ob);
                }
                else
                {
                    
                    bNum =bNum- aNum;
                    cNum = cNum-aNum;
                    ob.tblStock.quantity = bNum;
                    ob.tblStock.quantity_remaining = cNum;


                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("addition: "+bNum+" + "+aNum+" ="+(aNum+bNum));
                System.Diagnostics.Debug.WriteLine("addition: " + cNum + " + " + aNum + " =" + (aNum + cNum));

                bNum = bNum+aNum;
                cNum = cNum+aNum;
                ob.tblStock.quantity = bNum;
                ob.tblStock.quantity_remaining = cNum;
            }

            ob.StpDBEntities.Entry(ob.tblStock).State = EntityState.Modified;


            ob.tblStocksPrice.lowPrice = ob.tblStocksPrice.currentPrice;
            ob.tblStocksPrice.highPrice = ob.tblStocksPrice.currentPrice;
            ob.tblStocksPrice.timeOfDay = DateTime.Now;


            ob.StpDBEntities.Entry(ob.tblStocksPrice).State = EntityState.Modified;
            ob.StpDBEntities.SaveChanges();
           /* if (ModelState.IsValid)
            {
                
                ob.StpDBEntities.SaveChanges();
                return RedirectToAction("listofstocks");
            }
            ob.StpDBEntities.SaveChanges();*/


            return RedirectToAction("listofstocks");



        }

        /// <summary>
        /// chayanks code end
        /// </summary>
        /// 
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}