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
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        string teststring = "TEACHER VIEW ONLY";

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
                var temp2 = new List<String>();
                //    temp.Add("START");
                foreach (ApplicationUser currentUser in currentUsers)
                {
                    temp.Add(currentUser.UserName);
                    //  temp2.Add(roleManager.FindById(currentUser.Id).ToString());
                    //  roleManager.FindById(currentUser.Id).ToString();

                }
                //    temp.Add("END");
                ViewBag.UserList = temp;
                ViewBag.RoleList = temp2;
                // ViewBag.UserRole = Userrole;
            }

            // get a list of existing application roles
            List<IdentityRole> roles2 = roleManager.Roles.ToList();
            if (roles2 != null)
            {
                foreach (IdentityRole roleuser in roles2)
                {
                    //  roleManager.FindById
                    //   roleManager.Delete(roleuser);
                }
            }

        }
        public ActionResult Testing()
        {
            teststring = "NO LONGER HELLO :P";
            seedDatabase();
            ViewBag.teststring = teststring;
            return View("teacher");
        }


        public ActionResult TeacherIndex()
        {
            ViewBag.teststring = teststring;
            return View("teacher");
        }
 
    }
}