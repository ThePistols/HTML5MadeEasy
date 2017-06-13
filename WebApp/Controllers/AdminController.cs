using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using WebApp.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        string test = "HELLO";


        private void seedDatabase()
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            // get a list of existing application users

            List<ApplicationUser> currentUsers = userManager.Users.ToList();
            if (currentUsers != null)
            {
                var temp = new List<String>();
                temp.Add("START");
                foreach (ApplicationUser currentUser in currentUsers)
                {
                    temp.Add(currentUser.UserName);
                  //  userManager.Delete(currentUser);
                }
                temp.Add("END");
                ViewBag.UserList = temp;
            }

            // get a list of existing application roles
            List<IdentityRole> roles2 = roleManager.Roles.ToList();
            if (roles2 != null)
            {
                foreach (IdentityRole roleuser in roles2)
                {
                 //   roleManager.Delete(roleuser);
                }
            }

        }

        public ActionResult Testing()
        {
            test = "NO LONGER HELLO :P";
            seedDatabase();
            ViewBag.Test = test;
            return View("admin");
        }


        public ActionResult AdminIndex()
        {
            ViewBag.Test = test;
            return View("admin");
        }




    }
}