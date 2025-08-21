using Event_Managment_and_Ticketing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Managment_and_Ticketing_System.Controllers
{
    public class AccountController : Controller
    {
        DALAccounts d= new DALAccounts();
        // GET: Account
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginPage(Accounts a)
        {
            

            bool isvalid =d.CheckLogin(a);
            if (isvalid == true)
            {
                Session["Userid"] = a.Userid;
                Session["Username"] = a.Username;
                return Json(new { success = true, message = "Login successful" });
            }
            else
            {
                return Json(new { success = false, message = "Invalid username or password" });
            }
        }

        public ActionResult Logout()
        {
            // Clear all session data
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            // Set strong cache control headers
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoStore();
            Response.Cache.AppendCacheExtension("private");
            Response.Cache.AppendCacheExtension("no-cache=Set-Cookie");

            // Add meta tags for additional browser compatibility
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.AppendHeader("Pragma", "no-cache");
            Response.AppendHeader("Expires", "0");

            return RedirectToAction("LoginPage", "Account");
        }
    }
}
