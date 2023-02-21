using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;

namespace Eproject_MVC.Controllers
{
    public class RegisterController : Controller
    {
        private Data db = new Data();
        // GET: Register
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {

            User ac = db.Users.Where(a => a.Username.Equals(Username) && a.Password.Equals(Password)).FirstOrDefault();
            ViewBag.Message = null;

            if (ac != null)
            {
                return RedirectToAction("homepage", "Home");
            }
            return View();
        }
    }

}