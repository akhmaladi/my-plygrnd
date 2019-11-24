using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My.Plygrnd.Library.DAL;

namespace My_Plygrnd_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessDAL businessDAL;

        public HomeController(IBusinessDAL _businessDAL)
        {
            businessDAL = _businessDAL;
        }

        public ActionResult Index()
        {
            var result = businessDAL.GetBusinessInfo();

            return View(result);
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

        public ActionResult Outlet(long businessId)
        {
            var result = businessDAL.GetBusinessOutlet(businessId);
            return View(result);
        }
    }
}