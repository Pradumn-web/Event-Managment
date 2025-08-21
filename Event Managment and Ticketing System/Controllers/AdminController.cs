using Event_Managment_and_Ticketing_System.filters;
using Event_Managment_and_Ticketing_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Event_Managment_and_Ticketing_System.Controllers
{
    public class AdminController : Controller
    {
        DALAdmin d = new DALAdmin();
        DALHome DH = new DALHome();
        // GET: Admin
        [NoCache]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult AdminPannel()
        {
            // 🔒 Prevent back button from loading cached page
            // In your controller action or base controller
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoStore();


            if (Session["Username"] != null)
            {
                ViewBag.Username = Session["Username"];
                ViewBag.category = d.GetCategory();
                ViewBag.Admin = DH.ShowEvent();
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Account");
            }

        }

        public ActionResult AddNewEvent()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("LoginPage", "Account");
            }
            else
            {
                ViewBag.a = d.GetCategory();
                return View();
            }

        }
        [HttpPost]
        public JsonResult AddNEvent(AddEvent a)
        {
            if (a.EventImage != null && a.EventImage.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(a.EventImage.InputStream))
                {
                    a.Event_Poster = binaryReader.ReadBytes(a.EventImage.ContentLength); //  image to byte[]
                }
            }
                
            if (ModelState.IsValid)
            {
                d.AddData(a); //  DAL method remains unchanged
                return Json(new { success = true, message = "Data Added successfully" });
            }

            return Json(new { success = false, message = "Some Field is Empty" });
        }

        public ActionResult EditEvent(int id)
        {
            ViewBag.w = d.GetCategory();
            ViewBag.k = DH.GetElementById(id);
            return View();
        }
        public JsonResult UpdateEvent(Showevent s)
        {
            if (s.EventImage !=null && s.EventImage.ContentLength > 0)
            {
                using( var binaryReader = new BinaryReader(s.EventImage.InputStream))
                {
                    s.Event_Poster = binaryReader.ReadBytes(s.EventImage.ContentLength);
                }
            }

            if (ModelState.IsValid)
            {
                d.Update(s); // 
                return Json(new { success = true, message = "Data updated successfully" });
            }
            
            return Json(new { success = false, message = "Data updation failed" });
        }
        public ActionResult DeleteEvent(int id)
        {
            d.Delete(id);
            return RedirectToAction("AdminPannel");
        }
    }
}