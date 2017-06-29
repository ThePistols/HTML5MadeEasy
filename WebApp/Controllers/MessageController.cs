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
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            var result = new List<String>();

            string connStr = ConfigurationManager.ConnectionStrings["Messaging"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var temp = userManager.FindByName(User.Identity.Name);
                string userID = temp.Id;
                string sql = "SELECT * FROM [Messaging]";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
               // cmd.Parameters.AddWithValue("@ID", userID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //result.Add(reader.GetInt32(0).ToString());

                        if (reader.GetString(1) == userID)
                        {
                            var reciverid = reader.GetString(1);
                            var senderid = reader.GetString(2);

                            var recivername = userManager.FindById(reciverid);
                            var sendername = userManager.FindById(senderid);

                            result.Add(recivername.UserName);
                            result.Add(sendername.UserName);
                            result.Add(reader.GetString(3));
                            result.Add(reader.GetString(4));
                            result.Add(reader.GetSqlDateTime(5).ToString());
                        }
                    }
                }

                    conn.Close();
            }
            ViewBag.result = result;

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
                    USERNAME.Add(current.UserName);
                    USEREMAIL.Add(current.Email);
                }
            }

            ViewBag.senduserID = USERID;
            ViewBag.senduserNAME = USERNAME;
            ViewBag.senduserEMAIL = USEREMAIL;


            return View();
        }



        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Submit(string fromID, string replyname, string selecteduser, string subject, string message)
        {

            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

                     

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

                if (replyname == null)
                {
                    var temp = userManager.FindByName(selecteduser);
                    cmd.Parameters["@rid"].Value = temp.Id;
                }
                else
                {
                    var temp = userManager.FindByName(replyname);
                    cmd.Parameters["@rid"].Value = temp.Id;
                }
                cmd.Parameters["@sid"].Value = fromID;
                cmd.Parameters["@title"].Value = subject;
                cmd.Parameters["@msg"].Value = message;
                cmd.Parameters["@datetime"].Value = DateTime.Now;

                //uncomment line below to execute the query
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            Index();
            return View("index");
        }













        public ActionResult Reply(String message)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            List<ApplicationUser> currentUsers = userManager.Users.ToList();


            List<String> result = System.Web.Helpers.Json.Decode<List<String>>(message);
            ViewBag.message = result;

            string reply = "From: " + result[0] + "\nTo: " + result[3] + "\nSubject: " + result[1] + "\nMessage: " + result[2];

            ViewBag.replymessage1 = reply;

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
                    USERNAME.Add(current.UserName);
                    USEREMAIL.Add(current.Email);
                }
            }

            ViewBag.senduserID = USERID;
            ViewBag.senduserNAME = USERNAME;
            ViewBag.senduserEMAIL = USEREMAIL;


            return View("NewMessage");
        }
    }
}