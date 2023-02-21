using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eproject_MVC.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        private Data db = new Data();
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {

            Admin ac = db.Admins.Where(a => a.Username.Equals(Username) && a.Password.Equals(Password)).FirstOrDefault();
            ViewBag.Message = null;

            if (ac != null)
            {
                return RedirectToAction("index", "Admins");
            }
            return View();
        }
    }
}