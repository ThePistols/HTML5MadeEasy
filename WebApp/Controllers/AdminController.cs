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

        string teststring = "HELLO";


        private void getUserRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            // get a list of existing application users

            List<ApplicationUser> currentUsers = userManager.Users.ToList();
            List<IdentityRole> roles2 = roleManager.Roles.ToList();
            if (currentUsers != null)
            {
                var USER = new List<String>();
                var USERid = new List<String>();
                var UserROLES = new List<String>();

                foreach (ApplicationUser currentUser in currentUsers)
                {
                    USER.Add(currentUser.UserName);
                    USERid.Add(currentUser.Id);

                    var currentUserRoles = currentUser.Roles.ToList();

                    foreach (IdentityRole roleuser in roles2)
                    {
                        for (int i = 0; i < currentUserRoles.Count; i++)
                        {
                            if (roleuser.Id == currentUserRoles[i].RoleId)
                            {
                                UserROLES.Add(roleuser.Name);
                            }
                        }
                    }
                }
                ViewBag.user = USER;
                ViewBag.userID = USERid;
                ViewBag.userROLE = UserROLES;
            }           


        }

        public ActionResult UserRoles()
        {
            teststring = "NO LONGER HELLO :P";
            getUserRoles();
            ViewBag.teststring = teststring;
            return View("editroles");
        }


        public ActionResult AdminIndex()
        {
            ViewBag.teststring = teststring;
            return View("admin");
        }




    }
}