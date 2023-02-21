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
    public class LoginUserController : Controller
    {
        private Data db = new Data();
        // GET: Login
        public ActionResult LoginUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string Username, string Password)
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