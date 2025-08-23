using Event_Managment_and_Ticketing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Managment_and_Ticketing_System.Controllers
{
    public class HomeController : Controller
    {
        DALHome DH=new DALHome();
        public ActionResult Index()
        {
            ViewBag.a=DH.ShowEvent();
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.b = DH.ShowEvent();
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.d = DH.GetElementById(id);
            return View();
        }
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult ListYourShow()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewUser(String Name, String Email, String Password)
        {
            DH.NewUser(Name, Email, Password);
            TempData["Message"] = "Signup successful! Login Please";

            return RedirectToAction("Index", "Home");
        }


        public ActionResult LoginUser(String Email, String Password)
        {
            var result = DH.LoginUser(Email, Password);
            if (result != null)
            {
                Session["Id"] = result.Id;
                Session["Name"] = result.Name;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Invalid Email or Password";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            // Clear all session data
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Orders()
        {

            return View();
        }
    }
}