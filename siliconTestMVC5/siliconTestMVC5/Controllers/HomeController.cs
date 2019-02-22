using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace siliconTestMVC5.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin, User, Guest")]
        public ActionResult Index()
        {
            ViewBag.GuestUser = User.IsInRole("Guest");
            //Request.IsAuthenticated;
            return View();
        }

        public ActionResult Start()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.GuestUser = User.IsInRole("Guest");
                return View("Index");
            }
            return Redirect("/Account/Login");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
    }
}