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

                   var temp = userManager.GetRoles(currentUser.Id);

                    for (int i = 0; i < temp.Count; i++)
                    {
                        UserROLES.Add(temp[i]);
                    }
                }
                ViewBag.user = USER;
                ViewBag.userID = USERid;
                ViewBag.userROLE = UserROLES;
            }           
        }

        public void changerole(string userID, string currentRole, string newRole)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            userManager.RemoveFromRole(userID, currentRole);
            userManager.AddToRole(userID, newRole);
        }

        public ActionResult UserRoles()
        {
            getUserRoles();
            return View("editroles");
        }
        [HttpPost]
        public ActionResult ProcessRoleChange(string userID, string currentrole, string selectedrole)
        {
            changerole(userID, currentrole, selectedrole);
            getUserRoles();
            return View("editrolestest");
        }

        [HttpPost]
        public ActionResult ProcessRoleChange2(string userID, string currentrole, string selectedrole2)
        {
            changerole(userID, currentrole, selectedrole2);
            getUserRoles();
            return View("editroles");
        }




        public ActionResult AdminIndex()
        {
            return View("admin");
        }






    }
}