using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            USER.Add("<" + userEMAIL + ">");    // 2

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

            string connStr = ConfigurationManager.ConnectionStrings["Messaging"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO [Messaging] (ReciverID, SenderID, Title, Message, DateTime) Values (@rid, @sid, @title, @msg, @datetime)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@rid", SqlDbType.NVarChar);
                cmd.Parameters.Add("@sid", SqlDbType.NVarChar);
                cmd.Parameters.Add("@title", SqlDbType.NVarChar);
                cmd.Parameters.Add("@msg", SqlDbType.NVarChar);
                cmd.Parameters.Add("@datetime", SqlDbType.DateTime);

                cmd.Parameters["@rid"].Value = "reciever";
                cmd.Parameters["@sid"].Value = "sender";
                cmd.Parameters["@title"].Value = "Title";
                cmd.Parameters["@msg"].Value = "this is my message";
                cmd.Parameters["@datetime"].Value = DateTime.Now;

                //uncomment line below to execute the query
                    cmd.ExecuteNonQuery();
                conn.Close();

            }
            return View("index");
        }
    }
}