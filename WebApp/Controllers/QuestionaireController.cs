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
    public class QuestionaireController : Controller
    {
        // GET: Questionaire
        [HttpGet]
        public ActionResult Questionaire()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Teacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessQuestionaire(string Answer1, string Answer2, string Answer3, string Answer4, string Answer5, string Answer6, string Answer7, string Answer8, string Answer9, string Answer10, string Answer11, string Answer12, string Answer13, string Answer14, string Answer15, string Answer16, string Answer17)
        {
            ViewData["Answer1"] = Answer1;
            if (Answer1 == "C")
            {
                ViewData["Answer1Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer1Result"] = "/Content/Images/x mark.png";

            }

            ViewData["Answer2"] = Answer2;
            if (Answer2 == "A")
            {
                ViewData["Answer2Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer2Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer3"] = Answer3;
            if (Answer3 == "B")
            {
                ViewData["Answer3Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer3Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer4"] = Answer4;
            if (Answer4 == "A")
            {
                ViewData["Answer4Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer4Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer5"] = Answer5;
            if (Answer5 == "A")
            {
                ViewData["Answer5Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer5Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer6"] = Answer6;
            if (Answer6 == "A")
            {
                ViewData["Answer6Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer6Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer7"] = Answer7;
            if (Answer7 == "B")
            {
                ViewData["Answer7Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer7Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer8"] = Answer8;
            if (Answer8 == "C")
            {
                ViewData["Answer8Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer8Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer9"] = Answer9;
            if (Answer9 == "B")
            {
                ViewData["Answer9Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer9Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer10"] = Answer10;
            if (Answer10 == "A")
            {
                ViewData["Answer10Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer10Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer11"] = Answer11;
            if (Answer11 == "A")
            {
                ViewData["Answer11Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer11Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer12"] = Answer12;
            if (Answer12 == "C")
            {
                ViewData["Answer12Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer12Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer13"] = Answer13;
            if (Answer13 == "C")
            {
                ViewData["Answer13Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer13Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer14"] = Answer14;
            if (Answer14 == "C")
            {
                ViewData["Answer14Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer14Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer15"] = Answer15;
            if (Answer15 == "B")
            {
                ViewData["Answer15Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer15Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer16"] = Answer16;
            if (Answer16 == "B")
            {
                ViewData["Answer16Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer16Result"] = "/Content/Images/x mark.png";

            }
            ViewData["Answer17"] = Answer17;
            if (Answer17 == "A")
            {
                ViewData["Answer17Result"] = "/Content/Images/checkmark.png";
            }
            else
            {
                ViewData["Answer17Result"] = "/Content/Images/x mark.png";

            }

            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            var temp = userManager.FindByName(User.Identity.Name);
            var userID = temp.Id;


            string connStr = ConfigurationManager.ConnectionStrings["Questions"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO [quiz] (UserID, DateTime, answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer12, answer13, answer14, answer15, answer16, answer17) Values (@userid, @datetime, @ans1, @ans2, @ans3, @ans4, @ans5, @ans6, @ans7, @ans8, @ans9, @ans10, @ans11, @ans12, @ans13, @ans14, @ans15, @ans16, @ans17)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@userid", SqlDbType.NVarChar);
                cmd.Parameters.Add("@datetime", SqlDbType.DateTime);
                cmd.Parameters.Add("@ans1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans2", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans3", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans4", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans5", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans6", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans7", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans8", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans9", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans10", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans11", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans12", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans13", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans14", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans15", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans16", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ans17", SqlDbType.NVarChar);

                cmd.Parameters["@userid"].Value = userID;
                cmd.Parameters["@datetime"].Value = DateTime.Now;
                if (Answer1 != null)
                {
                    cmd.Parameters["@ans1"].Value = Answer1;
                }
                else
                {
                    cmd.Parameters["@ans1"].Value = "";
                }

                if (Answer2 != null)
                {
                    cmd.Parameters["@ans2"].Value = Answer2;
                }
                else
                {
                    cmd.Parameters["@ans2"].Value = "";
                }

                if (Answer3 != null)
                {
                    cmd.Parameters["@ans3"].Value = Answer3;

                }
                else
                {
                    cmd.Parameters["@ans3"].Value = "";

                }

                if (Answer4 != null)
                {
                    cmd.Parameters["@ans4"].Value = Answer4;

                }
                else
                {
                    cmd.Parameters["@ans4"].Value = "";

                }

                if (Answer5 != null)
                {
                    cmd.Parameters["@ans5"].Value = Answer5;

                }
                else
                {
                    cmd.Parameters["@ans5"].Value = "";

                }

                if (Answer6 != null)
                {
                    cmd.Parameters["@ans6"].Value = Answer6;

                }
                else
                {
                    cmd.Parameters["@ans6"].Value = "";

                }

                if (Answer7 != null)
                {
                    cmd.Parameters["@ans7"].Value = Answer7;

                }
                else
                {
                    cmd.Parameters["@ans7"].Value = "";

                }

                if (Answer8 != null)
                {
                    cmd.Parameters["@ans8"].Value = Answer8;

                }
                else
                {
                    cmd.Parameters["@ans8"].Value = "";

                }

                if (Answer9 != null)
                {
                    cmd.Parameters["@ans9"].Value = Answer9;

                }
                else
                {
                    cmd.Parameters["@ans9"].Value = "";

                }

                if (Answer10 != null)
                {
                    cmd.Parameters["@ans10"].Value = Answer10;

                }
                else
                {
                    cmd.Parameters["@ans10"].Value = "";

                }

                if (Answer11 != null)
                {
                    cmd.Parameters["@ans11"].Value = Answer11;

                }
                else
                {
                    cmd.Parameters["@ans11"].Value = "";

                }

                if (Answer12 != null)
                {
                    cmd.Parameters["@ans12"].Value = Answer12;

                }
                else
                {
                    cmd.Parameters["@ans12"].Value = "";

                }

                if (Answer13 != null)
                {
                    cmd.Parameters["@ans13"].Value = Answer13;

                }
                else
                {
                    cmd.Parameters["@ans13"].Value = "";

                }

                if (Answer14 != null)
                {
                    cmd.Parameters["@ans14"].Value = Answer14;

                }
                else
                {
                    cmd.Parameters["@ans14"].Value = "";

                }

                if (Answer15 != null)
                {
                    cmd.Parameters["@ans15"].Value = Answer15;

                }
                else
                {
                    cmd.Parameters["@ans15"].Value = "";

                }

                if (Answer16 != null)
                {
                    cmd.Parameters["@ans16"].Value = Answer16;

                }
                else
                {
                    cmd.Parameters["@ans16"].Value = "";
    
                }

                if (Answer17 != null)
                {
                    cmd.Parameters["@ans17"].Value = Answer17;
                }
                else
                {
                    cmd.Parameters["@ans17"].Value = "";
                }



                //uncomment line below to execute the query
                cmd.ExecuteNonQuery();
                conn.Close();

            }


            return View();
        }


    }
}