﻿using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using WebApp.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Web.UI;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            seedDatabase();


        }



        private void seedDatabase()
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            // get a list of existing application users and delete 
            List<ApplicationUser> currentUsers = userManager.Users.ToList();
            if (currentUsers != null)
            {
                foreach (ApplicationUser currentUser in currentUsers)
                {
                    userManager.Delete(currentUser);
                }
            }

            // get a list of existing application roles and delete them
            List<IdentityRole> roles2 = roleManager.Roles.ToList();
            if(roles2 != null)
            {
                foreach(IdentityRole roleuser in roles2)
                {
                    roleManager.Delete(roleuser);
                }
            }

            // add new roles and users

            var roles = new List<IdentityRole> {
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "User" },
                new IdentityRole { Name = "Teacher" }
            };

            // online guid generator for obtaining guid values - https://guidgenerator.com/online-guid-generator.aspx

            var users = new List<ApplicationUser>
            {
                new ApplicationUser{ UserName="Jamie", Email="jamie@gmail.com", Id="b2cfcc69-1959-4913-ae78-070d5e60af05" },
                new ApplicationUser{ UserName="Ben", Email="bweake@hotmail.com", Id="8b7efdb4-e0c8-40d0-ac17-4ab34c9da983" },
                new ApplicationUser{ UserName="Regan", Email="Regan@gmail.com", Id="92f20888-702a-4b64-aad0-ffbd32462e2e" }
            };

            foreach (IdentityRole role in roles)
            {
                var result = roleManager.Create(role);
            }

            // asp.net identity default password policy is required length of 6
            foreach (ApplicationUser user in users)
            {
                var result = userManager.Create(user, "password_1");
                if (result.Succeeded) userManager.AddToRole(user.Id, "User");
            }

            var admin = userManager.FindByName("Jamie");
            userManager.AddToRole(admin.Id, "Admin");
            userManager.RemoveFromRole(admin.Id, "User");

            var User = userManager.FindByName("Regan");
            userManager.AddToRole(User.Id, "User");

            var teacher = userManager.FindByName("Ben");
            userManager.AddToRole(teacher.Id, "teacher");
            userManager.RemoveFromRole(teacher.Id, "User");
        }

    }
}
