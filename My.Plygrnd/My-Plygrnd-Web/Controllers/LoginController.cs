using System.Web.Mvc;
using My.Plygrnd.Web.Models;
using My.Plygrnd.Library.DAL;

namespace My.Plygrnd.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginDAL loginDAL;

        public LoginController(ILoginDAL _loginDAL)
        {
            loginDAL = _loginDAL;
        }

        // GET: Login
        public ActionResult Index()
        {
            ViewData["error"] = TempData["error"];
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            var result = loginDAL.Login(login.Username, login.Password);

            if (result == "1")
            {
                TempData["error"] = "Invalid Username/Password";
                return RedirectToAction("Index", "Login");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        // Get
        public ActionResult AfterLogin()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
