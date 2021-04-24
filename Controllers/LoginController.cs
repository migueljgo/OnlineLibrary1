using OnlineLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineLibrary1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Home()
        {
            return View();
        }       
        
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (OnlineLibrary1Entities db = new OnlineLibrary1Entities())
            {

                //mijo = 123 123  admin or user  --> 
                // 123 1234
                var login = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
               
                if (login != null)
                {
                    Session["Role"] = login.Role;
                    Session["UserID"] = login.UserID;
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    ModelState.AddModelError("Username", "Wrong Credentials");
                    return View("Index" , user);
                }

            }
               
        }
    }
}