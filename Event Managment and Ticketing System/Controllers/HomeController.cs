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
        public ActionResult UserProfile()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
    }
}