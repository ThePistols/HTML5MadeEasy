using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewMessage()
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            List<ApplicationUser> currentUsers = userManager.Users.ToList();

            string userNAME = User.Identity.Name;
            string userID = User.Identity.GetUserId();

            var temp = userManager.FindById(userID);
            string userEMAIL = temp.Email;

            var USER = new List<String>();

            USER.Add(userNAME);     // 0
            USER.Add(userID);       // 1
            USER.Add(userEMAIL);    // 2

            ViewBag.userdetails = USER;

            var USERID = new List<String>();
            var USERNAME = new List<String>();
            var USEREMAIL = new List<String>();

            foreach (ApplicationUser current in currentUsers)
            {
                if (current.Id != userID)
                {
                    USERID.Add(current.Id);
                    USERNAME.Add(current.UserName + " <" + current.Email + ">");
                }
            }

            ViewBag.senduserID = USERID;
            ViewBag.senduserNAME = USERNAME;


            return View();
        }

        public ActionResult Submit()
        {

            //         string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //         using (SqlConnection conn = new SqlConnection(connStr))
            //         {
            //             string sql = "INSERT INTO AspNetMessages (MessageText) Values (@msg)";
            //             conn.Open();
            //             SqlCommand cmd = new SqlCommand(sql, conn);
            //             cmd.Parameters.Add("@msg", SqlDbType.NVarChar);
            //             cmd.Parameters["@msg"].Value = "this is my message";
            //
            //             //uncomment line below to execute the query
            //         //    cmd.ExecuteNonQuery();
            //             conn.Close();
            //
            //         }
            return View("index");
        }
    }
}