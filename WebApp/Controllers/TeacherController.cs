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
using System.Configuration;
using System.Data.SqlClient;

namespace WebApp.Controllers
{
    public class TeacherController : Controller
    {
        string teststring = "TEACHER VIEW ONLY";


        public ActionResult TeacherIndex()
        {
            ViewBag.teststring = teststring;


            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            var result = new List<String>();

            string connStr = ConfigurationManager.ConnectionStrings["Questions"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var temp = userManager.FindByName(User.Identity.Name);
                string userID = temp.Id;
                string sql = "SELECT * FROM [quiz]";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                // cmd.Parameters.AddWithValue("@ID", userID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var userid1 = reader.GetString(1);
                        var username1 = userManager.FindById(userid1);

                        result.Add(username1.UserName);
                        result.Add(reader.GetSqlDateTime(2).ToString());
                        result.Add(reader.GetString(3)); //ans 1
                        result.Add(reader.GetString(4)); //ans 2
                        result.Add(reader.GetString(5)); //ans 3
                        result.Add(reader.GetString(6)); //ans 4
                        result.Add(reader.GetString(7)); //ans 5
                        result.Add(reader.GetString(8)); //ans 6
                        result.Add(reader.GetString(9)); //ans 7
                        result.Add(reader.GetString(10)); //ans 8
                        result.Add(reader.GetString(11)); //ans 9
                        result.Add(reader.GetString(12)); //ans 10
                        result.Add(reader.GetString(13)); //ans 11
                        result.Add(reader.GetString(14)); //ans 12
                        result.Add(reader.GetString(15)); //ans 13
                        result.Add(reader.GetString(16)); //ans 14
                        result.Add(reader.GetString(17)); //ans 15
                        result.Add(reader.GetString(18)); //ans 16
                        result.Add(reader.GetString(19)); //ans 17
                        

                    }
                }

                conn.Close();
            }
            ViewBag.answers = result;


            return View("teacher");
        }

    }
}