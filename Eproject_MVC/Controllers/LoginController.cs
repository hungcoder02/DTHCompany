using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Eproject_MVC.Controllers
{
    public class LoginController : Controller
    {
        private Data db = new Data();
        // GET: Login
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(string Username, string Password)
        {

            Admin ac = db.Admins.Where(a => a.Username.Equals(Username) && a.Password.Equals(Password)).FirstOrDefault();
            ViewBag.Message = null;

            if (ac != null)
            {
                return RedirectToAction("index", "Admins");
            }
            return View();
        }




        public ActionResult LoginUser(string Username, string Password)
        {

            User ac = db.Users.Where(a => a.Username.Equals(Username) && a.Password.Equals(Password)).FirstOrDefault();
            ViewBag.Message = null;

            if (ac != null)
            {
                FormsAuthentication.SetAuthCookie(ac.Email, false);
                return RedirectToAction("homepage", "Home");
            }
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.PackageId = new SelectList(db.PackageDetails, "PackageId", "Packagename");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CustomerId,Username,Password,Fullname,Cardnumber,Email,Adress,Contactnumber,Ssd,PackageId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("LoginUser");
            }

            ViewBag.PackageId = new SelectList(db.PackageDetails, "PackageId", "Packagename", user.PackageId);
            return View(user);
        }

        public ActionResult LogOut()
        {
            
            return RedirectToAction("loginUser", "Login");
        }
    }
}